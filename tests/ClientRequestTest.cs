using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestClass]
    public class ClientRequestTest
    {
        [TestMethod]
        public void GetAcceptsSuccessfulStatusCodes()
        {
            WithServer(async context =>
            {
                context.Response.StatusCode = 204;
                context.Response.Close();
                await Task.CompletedTask;
            }, baseUrl =>
            {
                var client = new Trolley.Client(new Trolley.Configuration("access", "secret", baseUrl));

                string response = client.Get("/success");

                Assert.AreEqual("", response);
            });
        }

        [TestMethod]
        public void GatewayRequestDispatchesPatch()
        {
            string method = null;
            string body = null;

            WithServer(async context =>
            {
                method = context.Request.HttpMethod;
                using (var reader = new System.IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
                {
                    body = await reader.ReadToEndAsync();
                }

                byte[] response = Encoding.UTF8.GetBytes("{\"ok\":true}");
                context.Response.StatusCode = 202;
                context.Response.ContentType = "application/json";
                context.Response.OutputStream.Write(response, 0, response.Length);
                context.Response.Close();
            }, baseUrl =>
            {
                var gateway = new Trolley.Gateway("access", "secret", baseUrl);

                string response = gateway.Request("PATCH", "/patch", "{\"enabled\":true}");

                Assert.AreEqual("PATCH", method);
                Assert.AreEqual("{\"enabled\":true}", body);
                Assert.AreEqual("{\"ok\":true}", response);
            });
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
