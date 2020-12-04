using Newtonsoft.Json;
using PaymentRails.Types;
using System.Collections.Generic;
using System;

namespace PaymentRails.JsonHelpers
{
    public class BatchHelper : JsonHelper
    {
        /// <summary>
        /// Method that converts a JSON string to a List of Batch objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The List of Batches that the JSON object represented</returns>
        public static List<Types.Batch> JsonToBatchList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            BatchListJsonHelper helper = JsonConvert.DeserializeObject<BatchListJsonHelper>(jsonResponse);
            List<Types.Batch> batches = new List<Types.Batch>();
            if (helper.Ok)
            {
                foreach (BatchJsonHelper b in helper.Batches)
                {
                    batches.Add(BatchJsonHelperToBatch(b));
                }
            }
            return batches;
        }

        /// <summary>
        /// Method that converts a JSON string into a Batch object
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The Batch that the JSON string represented</returns>
        public static Types.Batch JsonToBatch(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            BatchResponseJsonHelper helper = JsonConvert.DeserializeObject<BatchResponseJsonHelper>(jsonResponse);

            if (helper.Ok)
            {
                return BatchJsonHelperToBatch(helper.Batch);
            }
            return null;
        }
    }
}
