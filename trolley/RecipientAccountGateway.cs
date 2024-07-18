using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Trolley
{
    public class RecipientAccountGateway
    {

        Gateway gateway;

        public RecipientAccountGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public List<Types.RecipientAccount> findAll(string recipient_id)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("/v1/recipients/{0}/accounts", recipient_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Get(endPoint);

            return recipientListFactory(response);
        }

        public Types.RecipientAccount find(string recipient_id, string recipient_account_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id,recipient_account_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Get(endPoint);

            return recipientFactory(response);
        }

        public Types.RecipientAccount create(string recipient_id, Types.RecipientAccount recipientAccount)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts", recipient_id);
            string endPoint = builder.ToString();
            string response = this.gateway.client.Post(endPoint, recipientAccount);

            return recipientFactory(response);
        }

        public Types.RecipientAccount update(string recipient_id, Types.RecipientAccount recipientAccount)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id,recipientAccount.id);
            string endPoint = builder.ToString();

            // Remove values unnecessary for RecipientAccount Update
            recipientAccount.id=null;
            recipientAccount.recipientAccountId=null;
            recipientAccount.setAction("UPDATE");

            string response = this.gateway.client.Patch(endPoint, recipientAccount);

            return recipientFactory(response);
        }

       
        public bool delete(string recipient_id, string recipient_account_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id, recipient_account_id);
            string endPoint = builder.ToString();

            gateway.client.Delete(endPoint);
            return true;
        }

        private Types.RecipientAccount recipientFactory(string response)
        {
            var tempData = JObject.Parse(response)["account"];
            Types.RecipientAccount recipientAccount = JsonConvert.DeserializeObject<Types.RecipientAccount>(tempData.ToString());
            return recipientAccount;
        }
        private List<Types.RecipientAccount> recipientListFactory(string response)
        {
            var tempData = JObject.Parse(response)["accounts"];
            List<Types.RecipientAccount> recipientAccounts = JsonConvert.DeserializeObject<List<Types.RecipientAccount>>(tempData.ToString());
            return recipientAccounts;
        }
    }
}
