using Newtonsoft.Json;
using System;
using Trolley.Types;

namespace Trolley
{
    public class FeesGateway
    {
        private readonly Gateway gateway;

        public FeesGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public RoutePricingSearchResponse SearchRoutePricing(RoutePricingSearchRequest request = null)
        {
            if (request == null)
            {
                request = new RoutePricingSearchRequest();
            }

            string response = gateway.client.Post("/v1/fees/route-pricing/search", request);
            return JsonConvert.DeserializeObject<RoutePricingSearchResponse>(response);
        }

        public RevenueStreamResponse CreateRevenueStream(CreateRevenueStreamRequest request)
        {
            if (request == null)
            {
                throw new MissingFieldException("revenue stream request can not be null.");
            }

            string response = gateway.client.Post("/v1/fees/revenue-stream/create", request);
            return JsonConvert.DeserializeObject<RevenueStreamResponse>(response);
        }

        public RevenueStreamResponse UpdateRevenueStream(UpdateRevenueStreamRequest request)
        {
            if (request == null)
            {
                throw new MissingFieldException("revenue stream request can not be null.");
            }

            string response = gateway.client.Post("/v1/fees/revenue-stream/update", request);
            return JsonConvert.DeserializeObject<RevenueStreamResponse>(response);
        }
    }
}
