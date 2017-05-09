using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Threading;

namespace paymentrailsTest
{
    class MockHttpHandler : HttpMessageHandler
    {
        private string apiKey;
        private string method;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            this.apiKey = this.GetApiKey(request);
            if (this.apiKey == null || (!this.apiKey.ToUpper().Contains("PK_TEST") && !this.apiKey.ToUpper().Contains("PK_LIVE")))
            {
                message.StatusCode = HttpStatusCode.Forbidden;
            }
            this.method = request.Method.Method;
            switch (method)
            {
                case "GET":
                    HandleGet(request, message);
                    break;
                case "POST":
                    break;
                case "PATCH":
                    break;
                case "DELETE":
                    break;
            }

            message.RequestMessage = request;
            //contentData
            Task<HttpResponseMessage> t = new Task<HttpResponseMessage>(() => message);
            t.Start();
            return t;
        }
        #region get
        private void HandleGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            string[] segments = request.RequestUri.Segments;
            string endpoint = segments[2];
            switch (endpoint)
            {
                case "payments/":
                    PaymentGet(request, message);
                    break;
                case "batches/":
                    break;
                case "recipients/":
                    break;
                case "balances/":
                    break;
            }
        }

        #region payment
        private void PaymentGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments.Length > 3)
            {
                SinglePaymentGet(request, message);
            }else
            {
                MultiPaymentGet(request, message);
            }
        }

        private void MultiPaymentGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            throw new NotImplementedException();
        }

        private void SinglePaymentGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments[3].ToUpper().Contains("P-"))
            {
                message.Content = new StringContent(MockResponseContent.VALID_PAYMENT, Encoding.UTF8, "application/json");
            }
        }
        #endregion

        #endregion

        private string GetApiKey(HttpRequestMessage message)
        {
            if (message.Headers.Contains("x-api-key"))
            {
                string apiKey = message.Headers.GetValues("x-api-key").First();
                return apiKey;
            }
            return null;
        }
    }
}
