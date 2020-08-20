// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PaymentRails
{
    public class PaymentRails_Batch_Gateway
    {
        PaymentRails_Gateway gateway;
        PaymentRails_Configuration config;

        public PaymentRails_Batch_Gateway(PaymentRails_Gateway gateway)
        {
            this.gateway = gateway;
            this.config = gateway.config;
        }

        public Batch find(string batch_id)
        {
            string endPoint = "/v1/batches/" + batch_id;
            string response = this.gateway.client.get(endPoint);

            return batchFactory(response);
        }

        public List<Batch> search(int page, int pageNumber)
        {
            return PaymentRails_Batch.search("", page, pageNumber);
        }

        public Batch create(Batch body)
        {
            string endPoint = "/v1/batches/";
            string response = this.gateway.client.post(endPoint, body);

            return batchFactory(response);
        }

        public bool update(Batch batch)
        {
            string endPoint = "/v1/batches/" + batch.id;
            string response = this.gateway.client.patch(endPoint, batch);
            return true;
        }

        public bool delete(string batch_id)
        {
            string endPoint = "/v1/batches/" + batch_id;
            string response = this.gateway.client.delete(endPoint);
            return true;
        }

        public bool delete(Batch batch)
        {
            return delete(batch.id);
        }

        public List<Batch> search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/?&search={0}&page={1}&pageSize={2}", term,page,pageSize);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);

            return batchListFactory(response);
        }

        public Batch generateQuote(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/generate-quote", batch_id);
            string endPoint = builder.ToString();

            Batch batch = new Batch(null, null, null, 0);
            string response = this.gateway.client.post(endPoint, batch);
            return batchFactory(response);
        }

        public Batch generateQuote(Batch batch)
        {
            return generateQuote(batch.id);
        }

        public Batch processBatch(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/start-processing", batch_id);
            string endPoint = builder.ToString();

            Batch batch = new Batch(null, null, null, 0);
            string response = this.gateway.client.post(endPoint, batch);
          
            return batchFactory(response);
        }

        public Batch proccessBatch(Batch batch)
        {
            return processBatch(batch.id);
        }

        public string summary(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/summary", batch_id);
            string endPoint = builder.ToString();

            return this.gateway.client.get(endPoint);
        }
        private Batch batchFactory(string response)
        {
            Batch batch = JsonHelpers.BatchHelper.JsonToBatch(response);
            return batch;
        }
        private List<Batch> batchListFactory(string response)
        {
            JsonDocument rawResponse = JsonDocument.Parse(response);
            string jsonBatches = rawResponse.RootElement.GetProperty("batches").GetString();
            List<Batch> batches = JsonSerializer.Deserialize<List<Batch>>(jsonBatches);
            // var tempData = JObject.Parse(response)["batches"];
            // List<Batch> batches = JsonConvert.DeserializeObject<List<Batch>>(tempData.ToString());
            return batches;
        }
    }
}
