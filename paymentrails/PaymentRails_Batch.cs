using System;
using PaymentRails.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Batches.
    /// </summary>
    public class PaymentRails_Batch
    {
        /// <summary>
        /// Retrieves the batch based on the batch_id
        /// </summary>
        /// <param name="batch_id">A batch id belonging the a batch object </param>
        /// <returns>A batch object that the batch id belongs to</returns>
        public static Batch get(String batch_id)
        {
            String endPoint = "/v1/batches/" + batch_id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            Batch batch = JsonHelpers.BatchHelper.JsonToBatch(response);
            
            return batch;
        }
        /// <summary>
        /// Retries a list of batches based on the page and page number
        /// </summary>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageNumber">Number of records in a page (default: 10)</param>
        /// <returns>A list of batches</returns>
        public static List<Batch> get(int page, int pageNumber)
        {
            return PaymentRails_Batch.query("", page, pageNumber);

        }
        /// <summary>
        /// Creates a batch based on the body or
        /// Genereates a quote based on batch_id or
        /// Starts processing the batch based on the batch_id
        /// or this does way too many things for a single method
        /// </summary>
        /// <param name="body">A batch object</param>
        /// <returns>The newly created batch object</returns>
        public static Batch post(Batch body)
        {
            String endPoint = "/v1/batches/";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.post(endPoint, body);
            Batch createdBatch = JsonHelpers.BatchHelper.JsonToBatch(response);

            return createdBatch;
        }
        /// <summary>
        /// Updates a batch based on batch id and the body
        /// </summary>
        /// <param name="body">A batch object that will be updated</param>
        /// <returns>The response</returns>
        public static String patch(Batch batch)
        {
            String endPoint = "/v1/batches/" + batch.Id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.patch(endPoint, batch);
            return response;
        }
        /// <summary>
        /// Deletes a batch based on the batch id
        /// </summary>
        /// <param name="batch_id">A batch id beloning to a batch object</param>
        /// <returns>The response</returns>
        public static String delete(String batch_id)
        {
            String endPoint = "/v1/batches/" + batch_id;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.delete(endPoint);
            return response;
        }
        /// <summary>
        /// Deletes a batch based on a batch object
        /// </summary>
        /// <param name="batch">A batch object that will be deleted</param>
        /// <returns></returns>
        public static string delete(Batch batch)
        {
            return delete(batch.Id);
        }
        /// <summary>
        /// Lists all batches based on queries
        /// </summary>
        /// <param name="term">Wildcard search of the batch-id</param>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageSize">Number of records in a page (default: 10)</param>
        /// <returns>A list of batches</returns>
        public static List<Batch> query(String term = "", int page = 1, int pageSize = 10)
        {
            String endPoint = "/v1/batches/?" + "&search=" + term + "&page=" + page + "&pageSize=" + pageSize;
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            List<Batch> batches = JsonHelpers.BatchHelper.JsonToBatchList(response);
            return batches;
        }
        /// <summary>
        /// Generates a quote based on batch id
        /// </summary>
        /// <param name="batch_id">A batch id belonging to a batch oject</param>
        /// <returns>The response</returns>
        public static String generateQuote(String batch_id)
        {
            String endPoint = batch_id + "/generate-quote";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.PostEmpty(endPoint);
            return response;
        }
        /// <summary>
        /// Generates a quote based on a batch object
        /// </summary>
        /// <param name="batch">A batch object that will have a quote generated </param>
        /// <returns></returns>
        public static String generateQuote(Batch batch)
        {
            return generateQuote(batch.Id);
        }
        /// <summary>
        /// Starts Processing a batch based on the batch id
        /// </summary>
        /// <param name="batch_id">A batch id belonging to a batch object</param>
        /// <returns>The response</returns>
        public static String processBatch(String batch_id)
        {
            String endPoint = batch_id + "/start-processing";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.PostEmpty(endPoint);
            return response;
        }
        /// <summary>
        /// Starts Processing a batch based on the batch object
        /// </summary>
        /// <param name="batch">A batch object that will be processed</param>
        /// <returns>The response</returns>
        public static String proccessBatch(Batch batch)
        {
            return processBatch(batch.Id);
        }
        /// <summary>
        /// Retrieves a summary based on the batch id
        /// </summary>
        /// <param name="batch_id">A batch id belonging to a batch object</param>
        /// <returns>The response</returns>
        public static String summary(String batch_id)
        {
            String endPoint = batch_id + "/summary";
            PaymentRails_Client client = PaymentRails_Client.CreateClient();
            String response = client.get(endPoint);
            return response;

        }

        

    }
}
