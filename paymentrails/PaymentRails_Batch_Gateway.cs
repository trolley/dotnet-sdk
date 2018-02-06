using PaymentRails.Types;
using System.Collections.Generic;
using System.Text;

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
            Batch batch = JsonHelpers.BatchHelper.JsonToBatch(response);

            return batch;
        }

        public List<Batch> search(int page, int pageNumber)
        {
            return PaymentRails_Batch.search("", page, pageNumber);
        }

        public Batch create(Batch body)
        {
            string endPoint = "/v1/batches/";
            string response = this.gateway.client.post(endPoint, body);
            Batch createdBatch = JsonHelpers.BatchHelper.JsonToBatch(response);

            return createdBatch;
        }

        public bool update(Batch batch)
        {
            string endPoint = "/v1/batches/" + batch.Id;
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
            return delete(batch.Id);
        }

        public List<Batch> search(string term = "", int page = 1, int pageSize = 10)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/?&search={0}&page={1}&pageSize={2}", term,page,pageSize);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);
            List<Batch> batches = JsonHelpers.BatchHelper.JsonToBatchList(response);
            return batches;
        }

        public Batch generateQuote(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/generate-quote", batch_id);
            string endPoint = builder.ToString();

            Batch batch = new Batch(null, null, null, 0);
            string response = this.gateway.client.post(endPoint, batch);
            Batch createdBatch = JsonHelpers.BatchHelper.JsonToBatch(response);
            return createdBatch;
        }

        public Batch generateQuote(Batch batch)
        {
            return generateQuote(batch.Id);
        }

        public Batch processBatch(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/start-processing", batch_id);
            string endPoint = builder.ToString();

            Batch batch = new Batch(null, null, null, 0);
            string response = this.gateway.client.post(endPoint, batch);
            Batch createdBatch = JsonHelpers.BatchHelper.JsonToBatch(response);
            return createdBatch;
        }

        public Batch proccessBatch(Batch batch)
        {
            return processBatch(batch.Id);
        }

        public string summary(string batch_id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("/v1/batches/{0}/summary", batch_id);
            string endPoint = builder.ToString();

            string response = this.gateway.client.get(endPoint);
            return response;

        }

    }
}
