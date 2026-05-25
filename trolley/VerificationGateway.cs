using Newtonsoft.Json;

namespace Trolley
{
    public class VerificationGateway
    {
        Gateway gateway;

        public VerificationGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public string Search(string verificationType = null, int page = 1, int pageSize = 10)
        {
            string endPoint = $"/v1/verifications?page={page}&pageSize={pageSize}";
            if (verificationType != null && verificationType.Length > 0)
            {
                endPoint += $"&verificationType={verificationType}";
            }
            return this.gateway.client.Get(endPoint);
        }

        public string Expire(object body)
        {
            string endPoint = "/v1/verifications/expire";
            return this.gateway.client.Patch(endPoint, JsonConvert.SerializeObject(body));
        }

        public string Trigger(string verificationType, object body)
        {
            string endPoint = $"/v1/verifications/{verificationType}/trigger";
            return this.gateway.client.Post(endPoint, JsonConvert.SerializeObject(body));
        }

        public string TriggerWatchlist(object body)
        {
            string endPoint = "/v1/verifications/watchlist/trigger";
            return this.gateway.client.Post(endPoint, JsonConvert.SerializeObject(body));
        }
    }
}
