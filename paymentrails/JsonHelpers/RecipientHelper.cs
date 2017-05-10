using System;
using paymentrails.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace paymentrails.JsonHelpers
{
    public class RecipientHelper : JsonHelper
    {
        /// <summary>
        /// Method that converts a JSON string to a List of Recipients objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The List of Recipients that the JSON object represented</returns>
        public static List<Recipient> JsonToRecipientList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            RecipientListJsonHelper helper = new JavaScriptSerializer().Deserialize<RecipientListJsonHelper>(jsonResponse);
            List<Recipient> recipients = new List<Recipient>();
            if (helper.Ok)
            {
                foreach (RecipientJsonHelper r in helper.Recipients)
                {
                    recipients.Add(RecipientJsonHelperToRecipient(r));
                }
            }
            return recipients;
        }
        /// <summary>
        /// Method that converts a JSON string to a Recipient objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The Recipient that the JSON object represented</returns>
        public static Recipient JsonToRecipient(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            RecipientResponseHelper helper = new JavaScriptSerializer().Deserialize<RecipientResponseHelper>(jsonResponse);
            if (helper.Ok)
            {
                return RecipientJsonHelperToRecipient(helper.Recipient);
            }
            return new Recipient();
        }
    }
}
