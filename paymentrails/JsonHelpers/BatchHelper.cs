using System;
using paymentrails.Types;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.JsonHelpers
{
    public class BatchHelper : JsonHelper
    {

        public static List<Batch> JsonToBatchList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            BatchListJsonHelper helper = new JavaScriptSerializer().Deserialize<BatchListJsonHelper>(jsonResponse);
            List<Batch> batches = new List<Batch>();
            if (helper.Ok)
            {
                foreach (BatchJsonHelper b in helper.Batches)
                {
                    batches.Add(BatchJsonHelperToBatch(b));
                }
            }
            return batches;
        }

        public static Batch JsonToBatch(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            BatchResponseJsonHelper helper = new JavaScriptSerializer().Deserialize<BatchResponseJsonHelper>(jsonResponse);
            if (helper.Ok)
            {
                return BatchJsonHelperToBatch(helper.Batch);
            }
            return null; // exception?
        }
    }
}
