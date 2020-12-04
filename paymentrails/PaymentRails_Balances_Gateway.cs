using System;
using System.Collections.Generic;
using System.Text;
using PaymentRails.Types;

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

        public List<Balance> find()
        {
            string endPoint = "/v1/balances/";
            Console.WriteLine("fart");
            string response = this.gateway.client.get(endPoint);
            List<Balance> balanceList = JsonHelpers.BalanceHelper.JsonToBalanceList(response);
            return balanceList;
        }
    }
}
