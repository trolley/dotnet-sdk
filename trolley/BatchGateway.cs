using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Trolley
{
    public class BatchGateway
    {
        Gateway gateway;

        public BatchGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public Types.Batch Get(string batchId)
        {
            string endPoint = "/v1/batches/" + batchId;
            string response = this.gateway.client.Get(endPoint);

            return BatchFactory(response);
        }

        public List<Types.Batch> Search(int page, int pageNumber)
        {
            return Batch.search("", page, pageNumber);
        }

        public Types.Batch Create(Types.Batch body)
        {
            string endPoint = "/v1/batches/";
            string response = this.gateway.client.Post(endPoint, body);

            return BatchFactory(response);
        }

        public bool Update(Types.Batch batch)
        {
            string endPoint = "/v1/batches/" + batch.id;
            string response = this.gateway.client.Patch(endPoint, batch);
            return true;
        }

        public bool Delete(string batchId)
        {
            string endPoint = "/v1/batches/" + batchId;
            string response = this.gateway.client.Delete(endPoint);
            return true;
        }

        public List<Types.Batch> Search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/?&search={0}&page={1}&pageSize={2}", term,page,pageSize);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Get(endPoint);

            return BatchListFactory(response);
        }

        public Types.Batch GenerateQuote(string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/generate-quote", batchId);
            string endPoint = builder.ToString();

            Types.Batch batch = new Types.Batch(null, null, null, 0);
            string response = this.gateway.client.Post(endPoint, batch);
            return BatchFactory(response);
        }

        public Types.Batch ProcessBatch(string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/start-processing", batchId);
            string endPoint = builder.ToString();

            Types.Batch batch = new Types.Batch(null, null, null, 0);
            string response = this.gateway.client.Post(endPoint, batch);
          
            return BatchFactory(response);
        }

        public string Summary(string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/summary", batchId);
            string endPoint = builder.ToString();

            return this.gateway.client.Get(endPoint);
        }

        private Types.Batch BatchFactory(string response)
        {
            Types.Batch batch = JsonHelpers.BatchHelper.JsonToBatch(response);
            return batch;
        }

        private List<Types.Batch> BatchListFactory(string response)
        {
            var tempData = JObject.Parse(response)["batches"];
            List<Types.Batch> batches = JsonConvert.DeserializeObject<List<Types.Batch>>(tempData.ToString());
            return batches;
        }
    }
}
