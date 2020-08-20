using System;
using PaymentRails.Types;
using System.Collections.Generic;
// using System.Web.Script.Serialization;
using System.Text.Json;

namespace PaymentRails.JsonHelpers
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
            RecipientListJsonHelper helper = JsonSerializer.Deserialize<RecipientListJsonHelper>(jsonResponse);
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

            RecipientResponseHelper helper = JsonSerializer.Deserialize<RecipientResponseHelper>(jsonResponse);
            if (helper.Ok)
            {
                return RecipientJsonHelperToRecipient(helper.Recipient);
            }
            return new Recipient();
        }
    }
}
