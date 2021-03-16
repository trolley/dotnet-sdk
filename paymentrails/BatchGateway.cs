using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace PaymentRails
{
    public class BatchGateway
    {
        Gateway gateway;

        public BatchGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public Types.Batch find(string batch_id)
        {
            string endPoint = "/v1/batches/" + batch_id;
            string response = this.gateway.client.get(endPoint);

            return batchFactory(response);
        }

        public List<Types.Batch> search(int page, int pageNumber)
        {
            return Batch.search("", page, pageNumber);
        }

        public Types.Batch create(Types.Batch body)
        {
            string endPoint = "/v1/batches/";
            string response = this.gateway.client.post(endPoint, body);

            return batchFactory(response);
        }

        public bool update(Types.Batch batch)
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

        public bool delete(Types.Batch batch)
        {
            return delete(batch.id);
        }

        public List<Types.Batch> search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/?&search={0}&page={1}&pageSize={2}", term,page,pageSize);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);

            return batchListFactory(response);
        }

        public Types.Batch generateQuote(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/generate-quote", batch_id);
            string endPoint = builder.ToString();

            Types.Batch batch = new Types.Batch(null, null, null, 0);
            string response = this.gateway.client.post(endPoint, batch);
            return batchFactory(response);
        }

        public Types.Batch generateQuote(Types.Batch batch)
        {
            return generateQuote(batch.id);
        }

        public Types.Batch processBatch(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/start-processing", batch_id);
            string endPoint = builder.ToString();

            Types.Batch batch = new Types.Batch(null, null, null, 0);
            string response = this.gateway.client.post(endPoint, batch);
          
            return batchFactory(response);
        }

        public Types.Batch proccessBatch(Types.Batch batch)
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
        private Types.Batch batchFactory(string response)
        {
            Types.Batch batch = JsonHelpers.BatchHelper.JsonToBatch(response);
            return batch;
        }
        private List<Types.Batch> batchListFactory(string response)
        {
            var tempData = JObject.Parse(response)["batches"];
            List<Types.Batch> batches = JsonConvert.DeserializeObject<List<Types.Batch>>(tempData.ToString());
            return batches;
        }
    }
}
