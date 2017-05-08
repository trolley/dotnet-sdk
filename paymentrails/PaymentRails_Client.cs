using System;
using System.Text;
using System.Net.Http;
using System.Net;
using paymentrails.Exceptions;
using paymentrails.Types;

namespace paymentrails
{
    public class PaymentRails_Client
    {
        private static PaymentRails_Client clientInstance;


        private HttpClient httpClient;

        public static PaymentRails_Client ClientInstance
        {
            get
            {
                if (clientInstance == null)
                {
                    clientInstance = new PaymentRails_Client(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
                }
                return clientInstance;
            }
        }

        public static HttpMessageHandler HttpMessageHandler
        {
            set
            { 
                clientInstance.httpClient.Dispose();
                clientInstance.httpClient = new HttpClient(value);
            }
        }

        private PaymentRails_Client(HttpMessageHandler handler)
        {
            this.httpClient = new HttpClient(handler);
        }
        /// <summary>
        /// Factory method to create an instance
        /// 
        /// Kept for the sake of not breaking everything while transitioning to singleton
        /// </summary>
        /// <returns>The instance of PaymentRails_Client</returns>
        public static PaymentRails_Client create()
        {
            return ClientInstance;
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
                httpClient.BaseAddress = new Uri(PaymentRails_Configuration.ApiBase);
                httpClient.DefaultRequestHeaders.Add("x-api-key", PaymentRails_Configuration.ApiKey);
                HttpResponseMessage response = httpClient.GetAsync(endPoint).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;

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
        public String post(String endPoint, IPaymentRailsMappable body) // change body to accept IJsonMappable objects
        {
            HttpContent jsonBody = convertBody(body.ToJson());
            string result = "";
            try
            {

                httpClient.BaseAddress = new Uri(PaymentRails_Configuration.ApiBase);
                httpClient.DefaultRequestHeaders.Add("x-api-key", PaymentRails_Configuration.ApiKey);
                HttpResponseMessage response = httpClient.PostAsync(endPoint, jsonBody).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;

            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }
            return result;
        }

        /// <summary>
        /// Method used to post to endpoints with no data, this is used for endpoints such as
        /// batch/:batch_id/generate_quote
        /// </summary>
        /// <param name="endpoint">Endpoint to post to</param>
        /// <returns></returns>
        public string PostEmpty(String endPoint)
        {
            HttpContent jsonBody = convertBody("");
            string result = "";
            try
            {

                httpClient.BaseAddress = new Uri(PaymentRails_Configuration.ApiBase);
                httpClient.DefaultRequestHeaders.Add("x-api-key", PaymentRails_Configuration.ApiKey);
                HttpResponseMessage response = httpClient.PostAsync(endPoint, jsonBody).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;

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
        public String patch(String endPoint, IPaymentRailsMappable body) // change body to accept IJsonMappable objects
        {
            HttpContent jsonBody = convertBody(body.ToJson());
            string result = "";
            try
            {
                httpClient.BaseAddress = new Uri(PaymentRails_Configuration.ApiBase);
                httpClient.DefaultRequestHeaders.Add("x-api-key", PaymentRails_Configuration.ApiKey);

                //  HttpResponseMessage response = client.PatchAsync(endPoint, body).Result;
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), endPoint) { Content = jsonBody };
                System.Threading.Tasks.Task<HttpResponseMessage> responseTask = httpClient.SendAsync(request);

                HttpResponseMessage response = responseTask.Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;

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
                httpClient.BaseAddress = new Uri(PaymentRails_Configuration.ApiBase);
                httpClient.DefaultRequestHeaders.Add("x-api-key", PaymentRails_Configuration.ApiKey);
                HttpResponseMessage response = httpClient.DeleteAsync(endPoint).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
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
