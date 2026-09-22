using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Trolley.Types;

namespace tests
{
    [TestClass]
    public class FeesTest
    {
        [TestMethod]
        public void SearchRoutePricingPostsRequestAndDeserializesResponse()
        {
            string method = null;
            string path = null;
            string body = null;

            WithServer(
                async context =>
                {
                    method = context.Request.HttpMethod;
                    path = context.Request.RawUrl;
                    body = await ReadBody(context);
                    Respond(context, "{\"ok\":true,\"fees\":[{\"currencyCode\":\"USD\",\"revenueStream\":{\"bankTransfer\":{\"ach\":{\"currencyCode\":\"USD\",\"integration\":\"bank-transfer\",\"routeType\":\"ach\",\"merchantAmountType\":\"percentage\",\"merchantAmount\":\"8.00\",\"guardrails\":{\"fixed\":{\"min\":\"0.00\",\"max\":\"2.00\"},\"percentage\":{\"min\":\"0.00\",\"max\":\"10.00\"}},\"percentCap\":{\"min\":null,\"max\":\"75.00\"},\"revenueShareId\":null}}}}]}");
                },
                gateway =>
                {
                    RoutePricingSearchResponse response = gateway.fees.SearchRoutePricing(
                        new RoutePricingSearchRequest { currency = "USD" });

                    Assert.AreEqual("USD", response.fees[0].currencyCode);
                    RevenueStream route = response.fees[0].revenueStream["bankTransfer"]["ach"];
                    Assert.AreEqual("8.00", route.merchantAmount);
                    Assert.AreEqual("2.00", route.guardrails.fixedAmount.max);
                    Assert.IsNull(route.percentCap.min);
                    Assert.IsNull(route.revenueShareId);
                });

            Assert.AreEqual("POST", method);
            Assert.AreEqual("/v1/fees/route-pricing/search", path);
            Assert.AreEqual("USD", JObject.Parse(body)["currency"]);
        }

        [TestMethod]
        public void CreateRevenueStreamPostsRequestAndDeserializesResponse()
        {
            string path = null;
            string body = null;

            WithServer(
                async context =>
                {
                    path = context.Request.RawUrl;
                    body = await ReadBody(context);
                    Respond(context, "{\"ok\":true,\"revenueStream\":{\"currencyCode\":\"USD\",\"integration\":\"bank-transfer\",\"routeType\":\"ach\",\"merchantAmountType\":\"percentage\",\"merchantAmount\":\"8.00\",\"percentCap\":{\"min\":\"2.00\",\"max\":\"75.00\"},\"revenueShareId\":\"RSRC-1\"}}");
                },
                gateway =>
                {
                    RevenueStreamResponse response = gateway.fees.CreateRevenueStream(
                        new CreateRevenueStreamRequest
                        {
                            currencyCode = "USD",
                            integration = "bank-transfer",
                            routeType = "ach",
                            merchantAmountType = "percentage",
                            merchantAmount = "8.00",
                            minPercentCapAmount = "2.00",
                            maxPercentCapAmount = "75.00"
                        });

                    Assert.AreEqual("RSRC-1", response.revenueStream.revenueShareId);
                    Assert.AreEqual("75.00", response.revenueStream.percentCap.max);
                });

            Assert.AreEqual("/v1/fees/revenue-stream/create", path);
            JObject request = JObject.Parse(body);
            Assert.AreEqual("8.00", request["merchantAmount"]);
            Assert.AreEqual("2.00", request["minPercentCapAmount"]);
        }

        [TestMethod]
        public void UpdateRevenueStreamPreservesOmittedNullAndValueCapStates()
        {
            var omitted = new UpdateRevenueStreamRequest();
            JObject omittedJson = JObject.Parse(omitted.ToJson());
            Assert.IsFalse(omittedJson.ContainsKey("minPercentCapAmount"));
            Assert.IsFalse(omittedJson.ContainsKey("maxPercentCapAmount"));

            var explicitStates = new UpdateRevenueStreamRequest
            {
                minPercentCapAmount = null,
                maxPercentCapAmount = "50.00"
            };
            JObject explicitJson = JObject.Parse(explicitStates.ToJson());
            Assert.IsTrue(explicitJson.ContainsKey("minPercentCapAmount"));
            Assert.AreEqual(JTokenType.Null, explicitJson["minPercentCapAmount"].Type);
            Assert.AreEqual("50.00", explicitJson["maxPercentCapAmount"]);
        }

        [TestMethod]
        public void UpdateRevenueStreamPostsExplicitNullCap()
        {
            string path = null;
            string body = null;

            WithServer(
                async context =>
                {
                    path = context.Request.RawUrl;
                    body = await ReadBody(context);
                    Respond(context, "{\"ok\":true,\"revenueStream\":{\"revenueShareId\":\"RSRC-2\",\"percentCap\":{\"min\":null,\"max\":\"50.00\"}}}");
                },
                gateway =>
                {
                    RevenueStreamResponse response = gateway.fees.UpdateRevenueStream(
                        new UpdateRevenueStreamRequest
                        {
                            revenueShareId = "RSRC-1",
                            currencyCode = "USD",
                            integration = "bank-transfer",
                            routeType = "ach",
                            merchantAmountType = "percentage",
                            merchantAmount = "9.00",
                            minPercentCapAmount = null,
                            maxPercentCapAmount = "50.00"
                        });

                    Assert.AreEqual("RSRC-2", response.revenueStream.revenueShareId);
                });

            Assert.AreEqual("/v1/fees/revenue-stream/update", path);
            JObject request = JObject.Parse(body);
            Assert.IsTrue(request.ContainsKey("minPercentCapAmount"));
            Assert.AreEqual(JTokenType.Null, request["minPercentCapAmount"].Type);
            Assert.AreEqual("50.00", request["maxPercentCapAmount"]);
        }

        private static async Task<string> ReadBody(HttpListenerContext context)
        {
            using (var reader = new System.IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private static void Respond(HttpListenerContext context, string json)
        {
            byte[] response = Encoding.UTF8.GetBytes(json);
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            context.Response.OutputStream.Write(response, 0, response.Length);
            context.Response.Close();
        }

        private static void WithServer(Func<HttpListenerContext, Task> handler, Action<Trolley.Gateway> test)
        {
            int port = GetAvailablePort();
            string baseUrl = $"http://localhost:{port}";

            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add(baseUrl + "/");
                listener.Start();

                Task server = Task.Run(async () =>
                {
                    HttpListenerContext context = await listener.GetContextAsync();
                    await handler(context);
                });

                test(new Trolley.Gateway("access", "secret", baseUrl));
                server.GetAwaiter().GetResult();
            }
        }

        private static int GetAvailablePort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}
