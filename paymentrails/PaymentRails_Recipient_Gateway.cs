using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using paymentrails.JsonHelpers;

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

            return recipientListFactory(response);
        }

        public Recipient find(string recipient_id)
        {
            string endPoint = "/v1/recipients/" + recipient_id;
            string response = this.gateway.client.get(endPoint);

            return recipientFactory(response);
        }
        
        public Recipient create(Recipient recipient)
        {
            string endPoint = "/v1/recipients";
            string response = this.gateway.client.post(endPoint, recipient);

            return recipientFactory(response);
        }

        public bool update(Recipient recipient)
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

        public bool delete(Recipient recipient)
        {
            return delete(recipient.id);
        }

        public List<Recipient> search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("/v1/recipients/?&search={0}&page={1}&pageSize={2}", term, page, pageSize);
            string endPoint = builder.ToString();

            string jsonResponse = this.gateway.client.get(endPoint);

            return recipientListFactory(jsonResponse);
        }

        public List<Recipient> search(int page, int pageNumber)
        {
            return search("", page, pageNumber);
        }

        private Recipient recipientFactory(string response)
        {
            var tempData = JObject.Parse(response)["recipient"];
            // JsonDocument rawResponse = JsonDocument.Parse(response);
            // Console.WriteLine(rawResponse);
            // Console.WriteLine(rawResponse.RootElement.GetProperty("recipient"));
            // Console.WriteLine(rawResponse.RootElement.GetProperty("recipient").GetType());


            // string jsonRecipient = rawResponse.RootElement.GetProperty("recipient").ToString();


            // Console.WriteLine("JsonRecipient");
            // Console.WriteLine(jsonRecipient);

            JsonSerializerOptions options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            options.Converters.Add(new JsonCustomConverter());

            // Recipient recipient = JsonSerializer.Deserialize<Recipient>(jsonRecipient, options);

            // Console.WriteLine("Recipient");
            // Console.WriteLine(recipient);

            // Console.WriteLine("Recipient ID");
            // Console.WriteLine(recipient.id);

            // JsonElement element = Json
            Recipient recipient = JsonConvert.DeserializeObject<Recipient>(tempData.ToString());
            return recipient;
        }
        private List<Recipient> recipientListFactory(string response)
        {
            var tempData = JObject.Parse(response)["recipients"];
            // JsonDocument rawResponse = JsonDocument.Parse(response);
            // var jsonRecipients = rawResponse.RootElement.GetProperty("recipients").GetString();
            // List<Recipient> recipients = JsonSerializer.Deserialize<List<Recipient>>(jsonRecipients);
            List<Recipient> recipients = JsonConvert.DeserializeObject<List<Recipient>>(tempData.ToString());
            return recipients;
        }
    }
}
