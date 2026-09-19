using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public class PartnerGatewayTest
    {
        [TestMethod]
        public void DedicatedMethodsCallDocumentedPartnerEndpoints()
        {
            var body = new { enabled = true };

            AssertRequest("GET", "/v1/fees", null, partner => partner.GetFees());
            AssertRequest("GET", "/v1/fees?currency=USD", null, partner => partner.GetFees("USD"));
            AssertRequest("PATCH", "/v1/fees", "{\"enabled\":true}", partner => partner.UpdateFees(body));
            AssertRequest("GET", "/v1/payout-methods", null, partner => partner.ListPayoutMethods());
            AssertRequest("GET", "/v1/payout-methods/bank-transfer", null, partner => partner.GetPayoutMethod("bank-transfer"));
            AssertRequest("PATCH", "/v1/payout-methods/bank-transfer", "{\"enabled\":true}", partner => partner.UpdatePayoutMethod("bank-transfer", body));
            AssertRequest("GET", "/v1/processing-settings", null, partner => partner.GetProcessingSettings());
            AssertRequest("PATCH", "/v1/processing-settings", "{\"enabled\":true}", partner => partner.UpdateProcessingSettings(body));
            AssertRequest("GET", "/v1/white-label/dns-records", null, partner => partner.GetWhiteLabelDnsRecords());
            AssertRequest("POST", "/v1/white-label/dns-records/verify", "{}", partner => partner.VerifyWhiteLabelDnsRecords());
            AssertRequest("DELETE", "/v1/white-label/email", null, partner => partner.DeleteWhiteLabelEmail());
            AssertRequest("PATCH", "/v1/white-label/icon", "{\"enabled\":true}", partner => partner.UpdateWhiteLabelIcon(body));
            AssertRequest("GET", "/v1/white-label", null, partner => partner.GetWhiteLabelSettings());
            AssertRequest("PATCH", "/v1/white-label", "{\"enabled\":true}", partner => partner.UpdateWhiteLabelSettings(body));
            AssertRequest("GET", "/v1/iframe/config", null, partner => partner.GetWidgetConfiguration());
            AssertRequest("POST", "/v1/iframe/config", "{\"enabled\":true}", partner => partner.UpdateWidgetConfiguration(body));
        }

        private static void AssertRequest(
            string expectedMethod,
            string expectedPath,
            string expectedBody,
            Func<Trolley.PartnerGateway, string> request)
        {
            string method = null;
            string path = null;
            string body = null;

            WithServer(async context =>
            {
                method = context.Request.HttpMethod;
                path = context.Request.Url.PathAndQuery;
                using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                {
                    body = await reader.ReadToEndAsync();
                }

                byte[] response = Encoding.UTF8.GetBytes("{\"ok\":true}");
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                context.Response.OutputStream.Write(response, 0, response.Length);
                context.Response.Close();
            }, baseUrl =>
            {
                var partner = new Trolley.Gateway("access", "secret", baseUrl).partner;
                Assert.AreEqual("{\"ok\":true}", request(partner));
            });

            Assert.AreEqual(expectedMethod, method);
            Assert.AreEqual(expectedPath, path);
            Assert.AreEqual(expectedBody ?? "", body);
        }

        private static void WithServer(Func<HttpListenerContext, Task> handler, Action<string> test)
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

                test(baseUrl);
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
