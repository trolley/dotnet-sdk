using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;

namespace PaymentRails
{
    public class PaymentRails_Recipient_Gateway
    {
        PaymentRails_Gateway gateway;
        PaymentRails_Configuration config;

        public PaymentRails_Recipient_Gateway(PaymentRails_Gateway gateway)
        {
            this.gateway = gateway;
            this.config = gateway.config;  
        }
        public List<Recipient> all()
        {
            string endPoint = "/v1/recipients";
            string response = this.gateway.client.get(endPoint);
            List<Recipient> recipients = JsonHelpers.RecipientHelper.JsonToRecipientList(response);
            return recipients;
        }

        public Recipient find(string recipient_id)
        {
            string endPoint = "/v1/recipients/" + recipient_id;
            string response = this.gateway.client.get(endPoint);
            Recipient createdRecipient = JsonHelpers.RecipientHelper.JsonToRecipient(response);
            return createdRecipient;
        }

        public Recipient create(Recipient recipient)
        {
            string endPoint = "/v1/recipients";
            string response = this.gateway.client.post(endPoint, recipient);
            Recipient createdRecipient = JsonHelpers.RecipientHelper.JsonToRecipient(response);
            return createdRecipient;
        }

        public bool update(Recipient recipient)
        {
            string endPoint = "/v1/recipients/" + recipient.Id;
            string response = this.gateway.client.patch(endPoint, recipient);
            return true;
        }

        public bool delete(string recipient_id)
        {
            string endPoint = "/v1/recipients/" + recipient_id;
            string response = this.gateway.client.delete(endPoint);
            return true;
        }

        public bool delete(Recipient recipient)
        {
            return delete(recipient.Id);
        }

        public List<Recipient> search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("/v1/recipients/?&search={0}&page={1}&pageSize={2}", term, page, pageSize);
            string endPoint = builder.ToString();

            string jsonResponse = this.gateway.client.get(endPoint);
            List<Recipient> recipients = JsonHelpers.RecipientHelper.JsonToRecipientList(jsonResponse);
            return recipients;
        }

        public List<Recipient> search(int page, int pageNumber)
        {
            return search("", page, pageNumber);
        }

    }
}
