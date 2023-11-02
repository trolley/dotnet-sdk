using System.Collections.Generic;

namespace Trolley
{
    /// <summary>
    /// A Class that facilitates HTTP Requests to the API in regards to Payments.
    /// </summary>
    internal class Payment
    {
        /// <summary>
        /// Retrieves a ist of payments based on the page and page number
        /// </summary>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageNumber">Number of records in a page (default: 10)</param>
        /// <returns>A list of all payments</returns>
        public static List<Types.Payment> search(int page, int pageNumber)
        {
            return search("",page,pageNumber,"");
        }

        /// <summary>
        /// Retrieves the Payment based on the payment id and batch id
        /// </summary>
        /// <param name="payment_id">A payment id belonging to a payment object</param>
        /// <returns>The response</returns>
        public static Types.Payment find(string payment_id)
        {
            return Configuration.gateway().payment.find(payment_id);
        }

        /// <summary>
        /// Creates a payment based on the body and batch id
        /// </summary>
        /// <param name="payment">A payment object that will be created</param>
        /// <returns>A newley created payment object</returns>
        public static Types.Payment create(Types.Payment payment)
        {
            return Configuration.gateway().payment.create(payment);
        }
        /// <summary>
        /// Updates a payment based on the payment id and batch id and body
        /// </summary>
        /// <param name="payment">A payment object that will be updated</param>
        /// <returns>The response</returns>
        public static bool update(Types.Payment payment)
        {
            return Configuration.gateway().payment.update(payment);
        }
        /// <summary>
        /// Deletes a payment based on the payment id and batch id
        /// </summary>
        /// <param name="paymentId">A payment id that belongs to a payment object</param>
        /// <param name="batchId">A batch id that belongs to a payment object</param>
        /// <returns>The response</returns>
        public static bool delete(string paymentId, string batchId)
        {
            return Configuration.gateway().payment.delete(paymentId, batchId);
        }
        /// <summary>
        /// Deletes a payment based on a payment object
        /// </summary>
        /// <param name="payment">A payment object that will be deleted</param>
        /// <returns>The response</returns>
        public static bool delete(Types.Payment payment)
        {
            return delete(payment.id, payment.batchId);
        }

        /// <summary>
        /// Lists all the payments based on and batch id
        /// </summary>
        /// <param name="term">The search term</param>
        /// <param name="page">The page number (default: 1)</param>
        /// <param name="pageSize">Number of records in a page (default: 10)</param>
        /// <param name="batchId">A batch id that will have its payments returned</param>
        /// <returns>A list of payments</returns>
        public static List<Types.Payment> search(string term = "", int page = 1, int pageSize = 10, string batchId = "")
        {
            return Configuration.gateway().payment.search(term,page,pageSize, batchId);
          
        }




    }
}
