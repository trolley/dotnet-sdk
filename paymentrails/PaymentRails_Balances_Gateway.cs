using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentRails
{
    public class PaymentRails_Balances_Gateway
    {
        PaymentRails_Gateway gateway;
        PaymentRails_Configuration config;

        public PaymentRails_Balances_Gateway(PaymentRails_Gateway gateway)
        {
            this.gateway = gateway;
            this.config = gateway.config;
        }

        public Dictionary<String, Types.Balance> find(string type = "")
        {
            string endPoint = "/v1/profile/balances/" + type;
            string response = this.gateway.client.get(endPoint);
            Dictionary<String, Types.Balance> balanceDictionary = JsonHelpers.BalanceHelper.JsonToBalanceDictionary(response);
            return balanceDictionary;
        }
    }
}
