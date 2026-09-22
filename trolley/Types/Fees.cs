using Newtonsoft.Json;
using System.Collections.Generic;
using Trolley.JsonHelpers;

namespace Trolley.Types
{
    public class RoutePricingSearchRequest : ITrolleyMappable
    {
        public string currency;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, SerializerHelper.GetSerializerSettings());
        }

        public override string ToString()
        {
            return ToJson();
        }

        public bool IsMappable()
        {
            return true;
        }
    }

    public class CreateRevenueStreamRequest : ITrolleyMappable
    {
        public string currencyCode;
        public string integration;
        public string routeType;
        public string merchantAmountType;
        public string merchantAmount;
        public string minPercentCapAmount;
        public string maxPercentCapAmount;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, SerializerHelper.GetSerializerSettings());
        }

        public override string ToString()
        {
            return ToJson();
        }

        public bool IsMappable()
        {
            return true;
        }
    }

    public class UpdateRevenueStreamRequest : ITrolleyMappable
    {
        public string revenueShareId;
        public string currencyCode;
        public string integration;
        public string routeType;
        public string merchantAmountType;
        public string merchantAmount;

        private string minPercentCapAmountValue;
        private string maxPercentCapAmountValue;
        private bool minPercentCapAmountSpecified;
        private bool maxPercentCapAmountSpecified;

        [JsonProperty(
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include)]
        public string minPercentCapAmount
        {
            get { return minPercentCapAmountValue; }
            set
            {
                minPercentCapAmountValue = value;
                minPercentCapAmountSpecified = true;
            }
        }

        [JsonProperty(
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include)]
        public string maxPercentCapAmount
        {
            get { return maxPercentCapAmountValue; }
            set
            {
                maxPercentCapAmountValue = value;
                maxPercentCapAmountSpecified = true;
            }
        }

        public bool ShouldSerializeminPercentCapAmount()
        {
            return minPercentCapAmountSpecified;
        }

        public bool ShouldSerializemaxPercentCapAmount()
        {
            return maxPercentCapAmountSpecified;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, SerializerHelper.GetSerializerSettings());
        }

        public override string ToString()
        {
            return ToJson();
        }

        public bool IsMappable()
        {
            return true;
        }
    }

    public class RoutePricingSearchResponse
    {
        public bool ok;
        public List<RoutePricingFee> fees;
    }

    public class RevenueStreamResponse
    {
        public bool ok;
        public RevenueStream revenueStream;
    }

    public class RoutePricingFee
    {
        public string currencyCode;
        public Dictionary<string, Dictionary<string, RevenueStream>> revenueStream;
    }

    public class RevenueStream
    {
        public string currencyCode;
        public string integration;
        public string routeType;
        public string merchantAmountType;
        public string merchantAmount;
        public RevenueStreamGuardrails guardrails;
        public AmountRange percentCap;
        public string revenueShareId;
    }

    public class RevenueStreamGuardrails
    {
        [JsonProperty("fixed")]
        public AmountRange fixedAmount;
        public AmountRange percentage;
    }

    public class AmountRange
    {
        public string min;
        public string max;
    }
}
