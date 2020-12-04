using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using PaymentRails.Types;

namespace PaymentRails
{
    public class BalancesGateway
    {
        Gateway gateway;

        public BalancesGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public List<Balance> find()
        {
            string endPoint = "/v1/balances/";
            Console.WriteLine("fart");

            string response = this.gateway.client.get(endPoint);

            return balanceListFactory(response);
        }

        private List<Balance> balanceListFactory(string response)
        {
            var tempData = JObject.Parse(response)["balances"];
            List<Balance> balances = JsonConvert.DeserializeObject<List<Balance>>(tempData.ToString());
            return balances;
        }
    }
}
