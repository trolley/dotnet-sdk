using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;

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
            List<RecipientAccount> recipientAccounts = JsonHelpers.RecipientAccountHelper.JsonToRecipientAccountList(response);
            return recipientAccounts;
        }

        public RecipientAccount find(string recipient_id, string recipient_account_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id,recipient_account_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);
            RecipientAccount recipientAccount = JsonHelpers.RecipientAccountHelper.JsonToRecipientAccount(response);
            return recipientAccount;
        }

        public RecipientAccount create(string recipient_id, RecipientAccount recipientAccount)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts", recipient_id);
            string endPoint = builder.ToString();
            string response = this.gateway.client.post(endPoint, recipientAccount);

            RecipientAccount createdRecipientAccount = JsonHelpers.RecipientAccountHelper.JsonToRecipientAccount(response);
            return createdRecipientAccount;
        }

        public RecipientAccount update(string recipient_id, RecipientAccount recipientAccount)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id,recipientAccount.Id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.patch(endPoint, recipientAccount);
            RecipientAccount updatedRecipientAccount = JsonHelpers.RecipientAccountHelper.JsonToRecipientAccount(response);
            return updatedRecipientAccount;
        }

       
        public bool delete(string recipient_id, string recipient_account_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/recipients/{0}/accounts/{1}", recipient_id, recipient_account_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.delete(endPoint);
            return true;
        }
    }
}
