using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;
using System.Net;

namespace paymentrailsTest
{
    class MockHttpHandlerForClientTests : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            if (!request.Headers.Contains("x-api-key") || !request.Headers.GetValues("x-api-key").First().ToUpper().Contains("PK_"))
            {
                message.StatusCode = HttpStatusCode.Unauthorized;
                message.Content = new StringContent(MockResponseContent.INVALID_UNAUTHORISED);
            }
            else
            {
                if (!request.RequestUri.Segments[1].Contains("invalid"))
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
            

            Task<HttpResponseMessage> task = new Task<HttpResponseMessage>(() => message);
            task.Start();
            return task;
        }
    }
}
