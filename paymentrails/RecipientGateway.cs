using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;

namespace PaymentRails
{
    public class RecipientGateway
    {
        Gateway gateway;
        Configuration config;

        public RecipientGateway(Gateway gateway)
        {
            this.gateway = gateway;
            this.config = gateway.config;  
        }
        public List<Types.Recipient> all()
        {
            string endPoint = "/v1/recipients";
            string response = this.gateway.client.get(endPoint);

            return recipientListFactory(response);
        }

        public Types.Recipient find(string recipient_id)
        {
            string endPoint = "/v1/recipients/" + recipient_id;
            string response = this.gateway.client.get(endPoint);

            return recipientFactory(response);
        }
        
        public Types.Recipient create(Types.Recipient recipient)
        {
            string endPoint = "/v1/recipients";
            string response = this.gateway.client.post(endPoint, recipient);

            return recipientFactory(response);
        }

        public bool update(Types.Recipient recipient)
        {
            string endPoint = "/v1/recipients/" + recipient.id;
            string response = this.gateway.client.patch(endPoint, recipient);
            return true;
        }

        public bool delete(string recipient_id)
        {
            string endPoint = "/v1/recipients/" + recipient_id;
            string response = this.gateway.client.delete(endPoint);
            return true;
        }

        public bool delete(Types.Recipient recipient)
        {
            return delete(recipient.id);
        }

        public List<Types.Recipient> search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("/v1/recipients/?&search={0}&page={1}&pageSize={2}", term, page, pageSize);
            string endPoint = builder.ToString();

            string jsonResponse = this.gateway.client.get(endPoint);

            return recipientListFactory(jsonResponse);
        }

        public List<Types.Recipient> search(int page, int pageNumber)
        {
            return search("", page, pageNumber);
        }

        private Types.Recipient recipientFactory(string response)
        {
            var tempData = JObject.Parse(response)["recipient"];
            Types.Recipient recipient = JsonConvert.DeserializeObject<Types.Recipient>(tempData.ToString());
            return recipient;
        }
        private List<Types.Recipient> recipientListFactory(string response)
        {
            var tempData = JObject.Parse(response)["recipients"];
            List<Types.Recipient> recipients = JsonConvert.DeserializeObject<List<Types.Recipient>>(tempData.ToString());
            return recipients;
        }
    }
}
