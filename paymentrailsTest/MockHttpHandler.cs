using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace paymentrailsTest
{
    class MockHttpHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = request.Content;
            string contentData = await content.ReadAsStringAsync();
            Console.WriteLine(contentData);
            //contentData

            return null;
        }
    }
}
