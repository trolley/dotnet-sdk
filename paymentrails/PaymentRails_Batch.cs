using PaymentRails.Types;
using System.Collections.Generic;

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
        public static Batch find(string batch_id)
        {
           return  PaymentRails_Configuration.gateway().batch.find(batch_id);
            
        }
        /// <summary>
        /// Retries a list of batches based on the page and page number
        /// </summary>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageNumber">Number of records in a page (default: 10)</param>
        /// <returns>A list of batches</returns>
        public static List<Batch> search(int page, int pageNumber)
        {
            return PaymentRails_Batch.search("", page, pageNumber);

        }
        /// <summary>
        /// Creates a batch based on the body or
        /// Genereates a quote based on batch_id or
        /// Starts processing the batch based on the batch_id
        /// or this does way too many things for a single method
        /// </summary>
        /// <param name="body">A batch object</param>
        /// <returns>The newly created batch object</returns>
        public static Batch create(Batch body)
        {
            return PaymentRails_Configuration.gateway().batch.create(body);
            
        }
        /// <summary>
        /// Updates a batch based on batch id and the body
        /// </summary>
        /// <param name="body">A batch object that will be updated</param>
        /// <returns>The response</returns>
        public static bool update(Batch batch)
        {
            return PaymentRails_Configuration.gateway().batch.update(batch);
        }
        /// <summary>
        /// Deletes a batch based on the batch id
        /// </summary>
        /// <param name="batch_id">A batch id beloning to a batch object</param>
        /// <returns>The response</returns>
        public static bool delete(string batch_id)
        {
            return PaymentRails_Configuration.gateway().batch.delete(batch_id);
        }
        /// <summary>
        /// Deletes a batch based on a batch object
        /// </summary>
        /// <param name="batch">A batch object that will be deleted</param>
        /// <returns></returns>
        public static bool delete(Batch batch)
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
        public static List<Batch> search(string term = "", int page = 1, int pageSize = 10)
        {
            return PaymentRails_Configuration.gateway().batch.search(term, page,pageSize);

        }
        /// <summary>
        /// Generates a quote based on batch id
        /// </summary>
        /// <param name="batch_id">A batch id belonging to a batch oject</param>
        /// <returns>The response</returns>
        public static Batch generateQuote(string batch_id)
        {
            return PaymentRails_Configuration.gateway().batch.generateQuote(batch_id);
        }
        /// <summary>
        /// Generates a quote based on a batch object
        /// </summary>
        /// <param name="batch">A batch object that will have a quote generated </param>
        /// <returns></returns>
        public static Batch generateQuote(Batch batch)
        {
            return generateQuote(batch.Id);
        }
        /// <summary>
        /// Starts Processing a batch based on the batch id
        /// </summary>
        /// <param name="batch_id">A batch id belonging to a batch object</param>
        /// <returns>The response</returns>
        public static Batch processBatch(string batch_id)
        {
            return PaymentRails_Configuration.gateway().batch.processBatch(batch_id);
        }
        /// <summary>
        /// Starts Processing a batch based on the batch object
        /// </summary>
        /// <param name="batch">A batch object that will be processed</param>
        /// <returns>The response</returns>
        public static Batch proccessBatch(Batch batch)
        {
            return processBatch(batch.Id);
        }
        /// <summary>
        /// Retrieves a summary based on the batch id
        /// </summary>
        /// <param name="batch_id">A batch id belonging to a batch object</param>
        /// <returns>The response</returns>
        public static string summary(string batch_id)
        {
            return PaymentRails_Configuration.gateway().batch.summary(batch_id);

        }

        

    }
}
