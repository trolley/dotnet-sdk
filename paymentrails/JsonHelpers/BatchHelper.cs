using System;
using paymentrails.Types;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.JsonHelpers
{
    class BatchHelper : JsonHelper
    {
        public static Batch JsonToBatch(string JsonResponse)
        {
            BatchResponseJsonHelper helper = new JavaScriptSerializer().Deserialize<BatchResponseJsonHelper>(JsonResponse);
            if (helper.Ok)
            {
                return BatchJsonHelperToBatch(helper.Batch);
            }
            return null; // exception?
        }
    }
}
