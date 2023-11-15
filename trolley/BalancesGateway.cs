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

        /// <summary>
        /// Get all accounts' balances.
        /// </summary>
        /// <returns></returns>
        public List<Balance> GetAllBalances()
        {
            return Get();
        }

        /// <summary>
        /// Get Trolley account's balances.
        /// </summary>
        /// <returns></returns>
        public List<Balance> GetTrolleyBalances()
        {
            return Get("paymentrails");
        }

        /// <summary>
        /// Get PayPal account's balances.
        /// </summary>
        /// <returns></returns>
        public List<Balance> GetPaypalBalances()
        {
            return Get("paypal");
        }

        /// <summary>
        /// Private method to make the final network calls.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private List<Balance> Get(string type = null)
        {
            string endPoint = "";

            if (type == null )
            {
                endPoint = "/v1/balances";
            }
            else
            {
                endPoint = "/v1/balances/" + type;
            }


            string response = this.gateway.client.Get(endPoint);

            return balanceListFactory(response);

        }

        /// <summary>
        /// Factory method to generate Balance objects from JSON responses.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private List<Balance> balanceListFactory(string response)
        {
            var tempData = JObject.Parse(response)["balances"];
            List<Balance> balances = JsonConvert.DeserializeObject<List<Balance>>(tempData.ToString());
            return balances;
        }
    }
}
