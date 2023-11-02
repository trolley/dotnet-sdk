using System;
using System.Text;
using System.Net.Http;
using Trolley.Exceptions;
using Trolley.Types;
using System.Security.Cryptography;
using Newtonsoft.Json;

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
        public string get(string endPoint)
        {
            string result = "";
            try {
                httpClient = createRequest(endPoint, "GET");
                HttpResponseMessage response = httpClient.GetAsync(endPoint).Result;

                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    throwStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);
            }

            return result;
        }

        /// <summary>
        /// Makes a POST request to API
        /// </summary>
        /// <param name="endPoint">The api endPoint</param>
        /// <param name="stringBody">The request payload</param>
        /// <returns>The Response</returns>
        public string post(string endPoint, ITrolleyMappable body)
        {
            body.IsMappable();
            HttpContent jsonBody = convertBody(body.ToJson());
            string result= "";
            try
            {
                httpClient = createRequest(endPoint, "POST", body);
                HttpResponseMessage response = httpClient.PostAsync(endPoint, jsonBody).Result;
                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    throwStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }

            }
            catch (System.Net.Http.HttpRequestException)
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
        public string patch(string endPoint, ITrolleyMappable body)
        {
            body.IsMappable();
            HttpContent jsonBody = convertBody(body.ToJson());
            string result = "";
            try
            {
                httpClient = createRequest(endPoint, "PATCH", body);

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), endPoint) { Content = jsonBody };
                System.Threading.Tasks.Task<HttpResponseMessage> responseTask = httpClient.SendAsync(request);

                HttpResponseMessage response = responseTask.Result;
                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    throwStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);
            }
            return result;

        }

        /// <summary>
        /// Makes A DELETE request to API
        /// </summary>
        /// <param name="endPoint">The api endPoint</param>
        /// <returns>The response</returns>
        public string delete(string endPoint)
        {
            string result = "";
            try
            {
                httpClient = createRequest(endPoint, "DELETE");
                HttpResponseMessage response = httpClient.DeleteAsync(endPoint).Result;
                result = response.Content.ReadAsStringAsync().Result;
                if ((int)response.StatusCode != 200)
                {
                    throwStatusCodeException((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw new InvalidStatusCodeException(result);
            }

            return result;
        }


        private HttpContent convertBody(string body)
        {
            HttpContent content = new StringContent(body, UTF8Encoding.UTF8, "application/json");
            return content;
        }

        private HttpClient createRequest(string endPoint, string method, ITrolleyMappable body = null)
        {
            try
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(this.config.ApiBase);

                TimeSpan epochTicks = new TimeSpan(new DateTime(1970, 1, 1).Ticks);
                TimeSpan unixTicks = new TimeSpan(DateTime.UtcNow.Ticks) - epochTicks;
                int unixTime = (int)unixTicks.TotalSeconds;

                var authorization = generateAuthorization(unixTime + "", endPoint, method, body);

                httpClient.DefaultRequestHeaders.Add("Authorization", authorization);
                httpClient.DefaultRequestHeaders.Add("X-PR-Timestamp", unixTime + "");
                httpClient.DefaultRequestHeaders.Add("Trolley-Source", "dotnet-sdk_1.0.10");
                return httpClient;

            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw new InvalidStatusCodeException(e.Message);
            }

        }

        private string generateAuthorization(string timeStamp, string endPoint, string method, ITrolleyMappable body)
        {
            string newBody = "";
            if (body != null)
            {
                newBody = body.ToJson();
            }

            string message = timeStamp + "\n" + method + "\n" + endPoint + "\n" + newBody + "\n";

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

        private void throwStatusCodeException(int statusCode, string message = "")
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
