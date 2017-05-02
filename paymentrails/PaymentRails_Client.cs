using System;
using System.Text;
using System.Net.Http;
using System.Net;
using paymentrails.Exceptions;

namespace paymentrails
{
    class PaymentRails_Client
    {
        private static readonly HttpClient client = new HttpClient();


        String apiKey;
        String apiBase;

        public PaymentRails_Client(String apiKey)
        {
            this.apiKey = apiKey;
            this.apiBase = PaymentRails_Configuration.apiBase;
        }
        /// <summary>
        /// Factory method to create an instance
        /// </summary>
        /// <returns>The instance of PaymentRails_Client</returns>
        public static PaymentRails_Client create()
        {
            return new PaymentRails_Client(PaymentRails_Configuration.apiKey);
        }


        /// <summary>
        /// Makes a GET request to API
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns>The response</returns>
        public String get(String endPoint)
        {
            string result = "";
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    client.BaseAddress = new Uri(this.apiBase);
                    client.DefaultRequestHeaders.Add("x-api-key", this.apiKey);
                    HttpResponseMessage response = client.GetAsync(endPoint).Result;
                    response.EnsureSuccessStatusCode();
                    result = response.Content.ReadAsStringAsync().Result;
                }

            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }
            return result;
        }
        /// <summary>
        /// Makes a POST request to API
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="stringBody"></param>
        /// <returns>The Response</returns>
        public String post(String endPoint, String stringBody)
        {
            HttpContent body = convertBody(stringBody);
            string result = "";
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    client.BaseAddress = new Uri(this.apiBase);
                    client.DefaultRequestHeaders.Add("x-api-key", this.apiKey);
                    HttpResponseMessage response = client.PostAsync(endPoint, body).Result;
                    response.EnsureSuccessStatusCode();
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }
            return result;
        }
        /// <summary>
        /// Makes a POST request to API
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="stringBody"></param>
        /// <returns>The response</returns>
        public String patch(String endPoint, String stringBody)
        {
            HttpContent body = convertBody(stringBody);
            string result = "";
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    client.BaseAddress = new Uri(this.apiBase);
                    client.DefaultRequestHeaders.Add("x-api-key", this.apiKey);

                    //  HttpResponseMessage response = client.PatchAsync(endPoint, body).Result;
                    var request = new HttpRequestMessage(new HttpMethod("PATCH"), endPoint) { Content = body };
                    System.Threading.Tasks.Task<HttpResponseMessage> responseTask = client.SendAsync(request);

                    HttpResponseMessage response = responseTask.Result;
                    response.EnsureSuccessStatusCode();
                    result = response.Content.ReadAsStringAsync().Result;

                }
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }
            return result;

        }
        /// <summary>
        /// Makes A DELETE request to API
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns>The response</returns>
        public String delete(String endPoint)
        {
            string result = "";
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    client.BaseAddress = new Uri(this.apiBase);
                    client.DefaultRequestHeaders.Add("x-api-key", this.apiKey);
                    HttpResponseMessage response = client.DeleteAsync(endPoint).Result;
                    response.EnsureSuccessStatusCode();
                    result = response.Content.ReadAsStringAsync().Result;
                }


            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }
            return result;
        }
        /// <summary>
        /// Converts String into HTTPContent
        /// </summary>
        /// <param name="body"></param>
        /// <returns>The response</returns>
        private HttpContent convertBody(String body)
        {
            HttpContent content = new StringContent(body, UTF8Encoding.UTF8, "application/json");
            return content;
        }
    }

}
