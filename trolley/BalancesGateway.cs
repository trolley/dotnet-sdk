using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Trolley.Types;

namespace Trolley
{
    public class BalancesGateway
    {
        Gateway gateway;

        public BalancesGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public List<Balance> find(string type = "all")
        {
            if (type == "all")
            {
                return all();
            }

            string endPoint = "/v1/balances/" + type;

            string response = this.gateway.client.get(endPoint);

            return balanceListFactory(response);

        }
            

        public List<Balance> all()
        {
            string endPoint = "/v1/balances/";

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
