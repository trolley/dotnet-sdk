using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Trolley.Types;
using Trolley.Types.Supporting;

namespace Trolley
{
    public class BatchGateway
    {
        Gateway gateway;

        public BatchGateway(Gateway gateway)
        {
            this.gateway = gateway;
        }

        public Batch Get(string batchId)
        {
            string endPoint = "/v1/batches/" + batchId;
            string response = this.gateway.client.Get(endPoint);

            return BatchFactory(response);
        }

        /// <summary>
        /// List all batches with auto pagination.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns>IEnumerable<Batch></returns>
        public IEnumerable<Batch> ListAllBatches(string searchTerm = null)
        {
            int page = 1;
            bool shouldPaginate = true;
            while (shouldPaginate)
            {
                Batches b = ListAllBatches(searchTerm, page, 10);
                foreach (Batch batch in b.batches)
                {
                    yield return batch;
                }

                page++;
                if (page > b.meta.pages)
                {
                    shouldPaginate = false;
                }
            }
        }

        /// <summary>
        /// List all batches. Optionally provide a search term to search through tags. Allows manual pagination.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Batches ListAllBatches(string searchTerm = null, int page = 1, int pageSize = 10)
        {
            string endPoint = $"/v1/batches?page={page}&pageSize={pageSize}";
            if (searchTerm != null && searchTerm.Length > 0)
            {
                endPoint += $"&search={searchTerm}";
            }
            string response = this.gateway.client.Get(endPoint);

            return BatchListFactory(response);
        }

        public Batch Create(Batch body)
        {
            string endPoint = "/v1/batches/";
            string response = this.gateway.client.Post(endPoint, body);

            return BatchFactory(response);
        }

        public bool Update(Batch batch)
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

        /// <summary>
        /// Delete multiple batches whose IDs you provide
        /// </summary>
        /// <param name="batchIds">An array of string containing IDs of batches you want to delete</param>
        /// <returns>True if the delete operation succeeded</returns>
        public bool Delete(params string[] batchIds)
        {
            var deleteBody = new Dictionary<string, string[]>
            {
                { "ids", batchIds }
            };

            string body = JsonConvert.SerializeObject(deleteBody);            
            string endPoint = "/v1/batches/";
            string response = this.gateway.client.Delete(endPoint, body);
            return true;
        }

        public Batches Search(int page, int pageNumber)
        {
            return Search("", page, pageNumber);
        }

        public Batches Search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/?&search={0}&page={1}&pageSize={2}", term,page,pageSize);
            string endPoint = builder.ToString();

            string response = this.gateway.client.Get(endPoint);

            return BatchListFactory(response);
        }

        public Batch GenerateQuote(string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/generate-quote", batchId);
            string endPoint = builder.ToString();

            Batch batch = new Batch(null, null, null, 0);
            string response = this.gateway.client.Post(endPoint, batch);
            return BatchFactory(response);
        }

        public Batch ProcessBatch(string batchId)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/start-processing", batchId);
            string endPoint = builder.ToString();

            Batch batch = new Batch(null, null, null, 0);
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

        private Batch BatchFactory(string response)
        {
            Batch batch = JsonHelpers.BatchHelper.JsonToBatch(response);
            return batch;
        }

        private Batches BatchListFactory(string response)
        {
            var tempData = JObject.Parse(response)["batches"];
            List<Batch> batches = JsonConvert.DeserializeObject<List<Batch>>(tempData.ToString());

            tempData = JObject.Parse(response)["meta"];
            Meta meta= JsonConvert.DeserializeObject<Meta>(tempData.ToString());
            return new Batches(batches, meta);
        }
    }
}
