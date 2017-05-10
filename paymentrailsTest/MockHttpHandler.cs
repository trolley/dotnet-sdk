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
            message.Content = new StringContent("");
            this.apiKey = this.GetApiKey(request);
            if (this.apiKey == null || (!this.apiKey.ToUpper().Contains("PK_TEST") && !this.apiKey.ToUpper().Contains("PK_LIVE")))
            {
                message.StatusCode = HttpStatusCode.Forbidden;
                message.Content = new StringContent(MockResponseContent.INVALID_UNAUTHORISED);
            }
            else
            {
                this.method = request.Method.Method;
                switch (method)
                {
                    case "GET":
                        HandleGet(request, message);
                        break;
                    case "POST":
                        HandlePost(request, message);
                        break;
                    case "PATCH":
                        HandlePatch(request, message);
                        break;
                    case "DELETE":
                        HandleDelete(request, message);
                        break;
                }

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
            endpoint = endpoint.Replace("/","");
            switch (endpoint)
            {
                case "payments":
                    PaymentGet(request, message);
                    break;
                case "batches":
                    BatchesGet(request, message);
                    break;
                case "recipients":
                    break;
                case "profile":
                    ProfileGet(request, message);
                    break;
            }
        }

        private void ProfileGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments[3].Replace("/", "") == "balances")
            {
                if(request.RequestUri.Segments.Length >= 5 )
                {
                    if (request.RequestUri.Segments[4].Contains("paypal"))
                    {
                        message.StatusCode = HttpStatusCode.OK;
                        message.Content = new StringContent(MockResponseContent.VALID_BALANCE_PAYPAL);
                    }
                    else if (request.RequestUri.Segments[4].Contains("paymentrails"))
                    {
                        message.StatusCode = HttpStatusCode.OK;
                        message.Content = new StringContent(MockResponseContent.VALID_BALANCE_PAYMENTRAILS);
                    }
                }
                else
                {
                    message.StatusCode = HttpStatusCode.OK;
                    message.Content = new StringContent(MockResponseContent.VALID_BALANCE);
                }
                
            }
            else
            {
                message.StatusCode = HttpStatusCode.NotFound;
                message.Content = new StringContent(MockResponseContent.INVALID_NOT_FOUND);
            }
        }

        private void BatchesGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments.Length >= 4)
            {
                if (request.RequestUri.Segments[3].Contains("B-"))
                {
                    message.StatusCode = HttpStatusCode.OK;
                    message.Content = new StringContent(MockResponseContent.VALID_BATCH);
                    return;
                }
                else
                {
                    message.StatusCode = HttpStatusCode.NotFound;
                    message.Content = new StringContent(MockResponseContent.INVALID_NOT_FOUND);
                    return;
                }

            }
            else
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(MockResponseContent.VALID_BATCH_LIST);
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
            message.StatusCode = HttpStatusCode.OK;
            message.Content = new StringContent(MockResponseContent.VALID_PAYMENT_LIST);
        }

        private void SinglePaymentGet(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments[3].ToUpper().Contains("P-"))
            {
                message.Content = new StringContent(MockResponseContent.VALID_PAYMENT, Encoding.UTF8, "application/json");
            }
            else
            {
                message.StatusCode = HttpStatusCode.NotAcceptable;
            }
        }
        #endregion

        #endregion
        #region post
        private void HandlePost(HttpRequestMessage request, HttpResponseMessage message)
        {
            string[] segments = request.RequestUri.Segments;
            string endpoint = segments[2];
            switch (endpoint)
            {
                case "payments/":
                    PaymentPost(request, message);
                    break;
                case "batches/":
                    BatchPost(request, message);
                    break;
                case "recipients/":
                    break;
                case "balances/":
                    break;
            }
        }

        private void BatchPost(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments.Length >= 4 && !request.RequestUri.Segments[3].ToUpper().Contains("B-"))
            {
                message.StatusCode = HttpStatusCode.NotAcceptable;
                message.Content = new StringContent(MockResponseContent.INVALID_NOT_FOUND);
                return;
            }
            else
            {
                string content = request.Content.ReadAsStringAsync().Result;
                if (content.Contains("INVALID"))
                {
                    message.StatusCode = HttpStatusCode.NotAcceptable;
                    message.Content = new StringContent(MockResponseContent.INVALID_BAD_DATA);
                }
                else
                {
                    message.StatusCode = HttpStatusCode.OK;
                    message.Content = new StringContent(MockResponseContent.VALID_BATCH);
                }
            }
            if (request.RequestUri.Segments.Length >= 5)
            {
                PaymentPost(request, message);
                return;
            }
        }

        private void PaymentPost(HttpRequestMessage request, HttpResponseMessage message)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            if (!content.Contains("INVALID"))
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(MockResponseContent.VALID_PAYMENT);
            }else
            {
                message.StatusCode = HttpStatusCode.NotAcceptable;
                message.Content = new StringContent(MockResponseContent.INVALID_BAD_DATA);
            }
        }
        #endregion
        #region patch
        private void HandlePatch(HttpRequestMessage request, HttpResponseMessage message)
        {
            string[] segments = request.RequestUri.Segments;
            string endpoint = segments[2];
            switch (endpoint)
            {
                case "batches/":
                    BatchPatch(request, message);
                    break;
                case "recipients/":
                    break;
                case "balances/":
                    break;
            }
        }

        private void BatchPatch(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments.Length >= 4 && !request.RequestUri.Segments[3].ToUpper().Contains("B-"))
            {
                message.StatusCode = HttpStatusCode.NotFound;
                message.Content = new StringContent(MockResponseContent.INVALID_NOT_FOUND);
                return;
            }
            if(request.RequestUri.Segments.Length == 4)
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(MockResponseContent.VALID_POST);
            }
            if (request.RequestUri.Segments.Length >= 5)
            {
                PaymentPatch(request, message);
                return;
            }
        }

        private void PaymentPatch(HttpRequestMessage request, HttpResponseMessage message)
        {
            string content = request.Content.ReadAsStringAsync().Result;
            if (!content.Contains("INVALID"))
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(MockResponseContent.VALID_POST);
            }
            else
            {
                message.StatusCode = HttpStatusCode.NotAcceptable;
                message.Content = new StringContent(MockResponseContent.INVALID_BAD_DATA);
            }
        }

        #endregion
        #region delete
        private void HandleDelete(HttpRequestMessage request, HttpResponseMessage message)
        {
            string[] segments = request.RequestUri.Segments;
            string endpoint = segments[2];
            switch (endpoint)
            {
                case "batches/":
                    BatchDelete(request, message);
                    break;
                case "recipients/":
                    break;
                case "balances/":
                    break;
            }
        }

        private void BatchDelete(HttpRequestMessage request, HttpResponseMessage message)
        {
            if (request.RequestUri.Segments.Length >= 4 && !request.RequestUri.Segments[3].ToUpper().Contains("B-"))
            {
                message.StatusCode = HttpStatusCode.NotFound;
                message.Content = new StringContent(MockResponseContent.INVALID_NOT_FOUND);
                return;
            }
            if (request.RequestUri.Segments.Length == 4)
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(MockResponseContent.VALID_POST);
            }
            if (request.RequestUri.Segments.Length >= 5)
            {
                PaymentDelete(request, message);
                return;
            }
        }

        private void PaymentDelete(HttpRequestMessage request, HttpResponseMessage message)
        {
            if(request.RequestUri.Segments.Length >= 6 && request.RequestUri.Segments[5].ToUpper().Contains("P-"))
            {
                message.StatusCode = HttpStatusCode.OK;
                message.Content = new StringContent(MockResponseContent.VALID_POST);
            }
            else
            {
                message.StatusCode = HttpStatusCode.NotFound;
                message.Content = new StringContent(MockResponseContent.INVALID_NOT_FOUND);
            }
        }
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
