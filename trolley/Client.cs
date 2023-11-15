using System;
using System.Text;
using System.Net.Http;
using Trolley.Exceptions;
using Trolley.Types;
using Trolley.Types.Supporting;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Trolley
{
    /// <summary>
    /// A Class that makes HTTP Requests to the API.
    /// </summary>
    public class Client
    {
        public Configuration config;

        private HttpClient httpClient;

        public Client(Configuration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Makes a GET request to API
        /// </summary>
        /// <param name="endPoint">The api endPoint</param>
        /// <returns>The response</returns>
        public string Get(string endPoint)
        {
            string result = "";
            try {
                httpClient = CreateRequest(endPoint, "GET");
                HttpResponseMessage response = httpClient.GetAsync(endPoint).Result;

                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    ThrowStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);
            }

            return result;
        }

        /// <summary>
        /// Makes a POST request to API
        /// </summary>
        /// <param name="endPoint">The api endPoint</param>
        /// <param name="body">The request payload</param>
        /// <returns>The Response</returns>
        public string Post(string endPoint, ITrolleyMappable body)
        {
            if (body.IsMappable())
            {
                return Post(endPoint, body.ToString());
            }
            else
            {
                throw new InvalidFieldException("Provided ITrolleyMappable object is not Mappable.");
            }
        }

        /// <summary>
        /// Post method with string body
        /// </summary>
        /// <param name="endPoint"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="InvalidStatusCodeException"></exception>
        public string Post(string endPoint, string body)
        {
            if (body == null)
            {
                body = "";
            }

            HttpContent jsonBody = ConvertBody(body);
            string result = "";
            try
            {
                httpClient = CreateRequest(endPoint, "POST", null, body);
                HttpResponseMessage response = httpClient.PostAsync(endPoint, jsonBody).Result;
                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    ThrowStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);

            }

            return result;
        }

        /// <summary>
        /// Makes a PATCH request to API
        /// </summary>
        /// <param name="endPoint">The api endPoint</param>
        /// <param name="stringBody">The request payload</param>
        /// <returns>The response</returns>
        public string Patch(string endPoint, ITrolleyMappable body)
        {
            body.IsMappable();
            HttpContent jsonBody = ConvertBody(body.ToJson());
            string result = "";
            try
            {
                httpClient = CreateRequest(endPoint, "PATCH", body);

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), endPoint) { Content = jsonBody };
                Task<HttpResponseMessage> responseTask = httpClient.SendAsync(request);

                HttpResponseMessage response = responseTask.Result;
                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    ThrowStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);
            }
            return result;

        }

        /// <summary>
        /// Makes A DELETE request with body to API
        /// </summary>
        /// <param name="endPoint">The api endPoint</param>
        /// <param name="body">The request body</param>
        /// <returns>The response</returns>
        public string Delete(string endPoint, string body = null)
        {
            string result = "";
            HttpResponseMessage response = null;
            try
            {
                if(body == null)
                {
                    httpClient = CreateRequest(endPoint, "DELETE");
                    response = httpClient.DeleteAsync(endPoint).Result;
                }
                else
                {
                    httpClient = CreateRequest(endPoint, "DELETE", null, body);
                    HttpContent jsonBody = ConvertBody(body);

                    var request = new HttpRequestMessage(new HttpMethod("DELETE"), endPoint) { Content = jsonBody };
                    Task<HttpResponseMessage> responseTask = httpClient.SendAsync(request);

                    response = responseTask.Result;
                }
                
                
                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    ThrowStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);
            }

            return result;
        }


        private HttpContent ConvertBody(string body)
        {
            HttpContent content = new StringContent(body, UTF8Encoding.UTF8, "application/json");
            return content;
        }

        private HttpClient CreateRequest(string endPoint, string method, ITrolleyMappable body = null, string bodyStr = null)
        {
            try
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(this.config.ApiBase);

                TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
                TimeSpan unixTicks = new TimeSpan(DateTime.UtcNow.Ticks) - epochTicks;
                int unixTime = (int)unixTicks.TotalSeconds;

                if (body != null)
                {
                    bodyStr = body.ToJson();
                }

                var authorization = GenerateAuthorization(unixTime + "", endPoint, method, bodyStr);

                httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
                httpClient.DefaultRequestHeaders.Add("X-PR-Timestamp", unixTime + "");
                httpClient.DefaultRequestHeaders.Add("Trolley-Source", $"dotnet-sdk_{SemVer.MAJOR}.{SemVer.PATCH}.{SemVer.MINOR}");
                return httpClient;

            }
            catch (HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }

        }

        private string GenerateAuthorization(string timeStamp, string endPoint, string method, string body)
        {

            string message = timeStamp + "\n" + method + "\n" + endPoint + "\n" + body + "\n";

            if (this.config.ApiSecret == null || this.config.ApiSecret == "")
            {
                throw new InvalidCredentialsException("API Secret must be provided.");
            }
            if (this.config.ApiKey == null || this.config.ApiKey == "")
            {
                throw new InvalidCredentialsException("API Key must be provided.");
            }
            var signature = GetHash(message, this.config.ApiSecret);

            return "prsign " + this.config.ApiKey + ":" + signature;
        }

        private string GetHash(string text, string key)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            HMACSHA256 hash = new HMACSHA256(keyBytes);
            Byte[] hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        private void ThrowStatusCodeException(int statusCode, string message = "")
        {
            switch (statusCode)
            {
                case 400:
                    throw new MalformedUrlException(message);
                case 401:
                    throw new AuthenticationException(message);
                case 403:
                    throw new AuthorizationException(message);
                case 404:
                    throw new NotFoundException(message);
                case 429:
                    throw new TooManyRequestsException(message);
                case 500:
                    throw new ServerErrorException(message);
                case 503:
                    throw new DownForMaintenanceException(message);
                default:
                    throw new UnexpectedException(message);
            }
        }
    }

}
