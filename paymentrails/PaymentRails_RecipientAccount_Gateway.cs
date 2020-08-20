// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PaymentRails
{
    public class PaymentRails_RecipientAccount_Gateway
    {

        PaymentRails_Gateway gateway;
        PaymentRails_Configuration config;

        public PaymentRails_RecipientAccount_Gateway(PaymentRails_Gateway gateway)
        {
            this.gateway = gateway;
            this.config = gateway.config;
        }

        public List<RecipientAccount> findAll(string recipient_id)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("/v1/recipients/{0}/accounts", recipient_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);

            return recipientListFactory(response);
        }

        public RecipientAccount find(string recipient_id, string recipient_account_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id,recipient_account_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);

            return recipientFactory(response);
        }

        public RecipientAccount create(string recipient_id, RecipientAccount recipientAccount)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts", recipient_id);
            string endPoint = builder.ToString();
            string response = this.gateway.client.post(endPoint, recipientAccount);

            return recipientFactory(response);
        }

        public RecipientAccount update(string recipient_id, RecipientAccount recipientAccount)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id,recipientAccount.id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.patch(endPoint, recipientAccount);

            return recipientFactory(response);
        }

       
        public bool delete(string recipient_id, string recipient_account_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id, recipient_account_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.delete(endPoint);
            return true;
        }

        private RecipientAccount recipientFactory(string response)
        {

            JsonDocument rawResponse = JsonDocument.Parse(response);
            string jsonAccount = rawResponse.RootElement.GetProperty("account").GetString();
            RecipientAccount recipientAccount = JsonSerializer.Deserialize<RecipientAccount>(jsonAccount);

            // var tempData = JObject.Parse(response)["account"];
            // RecipientAccount recipientAccount = JsonConvert.DeserializeObject<RecipientAccount>(tempData.ToString());
            return recipientAccount;
        }
        private List<RecipientAccount> recipientListFactory(string response)
        {
            JsonDocument rawResponse = JsonDocument.Parse(response);
            string jsonAccount = rawResponse.RootElement.GetProperty("account").GetString();
            List<RecipientAccount> recipientAccounts = JsonSerializer.Deserialize<List<RecipientAccount>>(jsonAccount);

            // var tempData = JObject.Parse(response)["accounts"];
            // List<RecipientAccount> recipientsAccounts = JsonConvert.DeserializeObject<List<RecipientAccount>>(tempData.ToString());
            return recipientAccounts;
        }
    }
}
