using System;
using Newtonsoft.Json;

namespace Trolley
{
    public class PartnerGateway
    {
        private readonly Gateway gateway;

        public PartnerGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public string GetFees(string currency = null)
        {
            string endPoint = "/v1/fees";
            if (!string.IsNullOrEmpty(currency))
            {
                endPoint += $"?currency={Uri.EscapeDataString(currency)}";
            }
            return this.gateway.client.Get(endPoint);
        }

        public string UpdateFees(object body)
        {
            return this.gateway.client.Patch("/v1/fees", Json(body));
        }

        public string ListPayoutMethods()
        {
            return this.gateway.client.Get("/v1/payout-methods");
        }

        public string GetPayoutMethod(string payoutMethod)
        {
            return this.gateway.client.Get($"/v1/payout-methods/{Uri.EscapeDataString(payoutMethod)}");
        }

        public string UpdatePayoutMethod(string payoutMethod, object body)
        {
            return this.gateway.client.Patch(
                $"/v1/payout-methods/{Uri.EscapeDataString(payoutMethod)}",
                Json(body)
            );
        }

        public string GetProcessingSettings()
        {
            return this.gateway.client.Get("/v1/processing-settings");
        }

        public string UpdateProcessingSettings(object body)
        {
            return this.gateway.client.Patch("/v1/processing-settings", Json(body));
        }

        public string GetWhiteLabelDnsRecords()
        {
            return this.gateway.client.Get("/v1/white-label/dns-records");
        }

        public string VerifyWhiteLabelDnsRecords()
        {
            return this.gateway.client.Post("/v1/white-label/dns-records/verify", "{}");
        }

        public string DeleteWhiteLabelEmail()
        {
            return this.gateway.client.Delete("/v1/white-label/email");
        }

        public string UpdateWhiteLabelIcon(object body)
        {
            return this.gateway.client.Patch("/v1/white-label/icon", Json(body));
        }

        public string GetWhiteLabelSettings()
        {
            return this.gateway.client.Get("/v1/white-label");
        }

        public string UpdateWhiteLabelSettings(object body)
        {
            return this.gateway.client.Patch("/v1/white-label", Json(body));
        }

        public string GetWidgetConfiguration()
        {
            return this.gateway.client.Get("/v1/iframe/config");
        }

        public string UpdateWidgetConfiguration(object body = null)
        {
            return this.gateway.client.Post("/v1/iframe/config", Json(body));
        }

        private static string Json(object body)
        {
            if (body is string)
            {
                return (string)body;
            }
            return JsonConvert.SerializeObject(body ?? new object());
        }
    }
}
