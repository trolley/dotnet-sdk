using Newtonsoft.Json;
using System;
using Trolley.Types;
using System.Collections.Generic;

namespace Trolley.JsonHelpers
{
    public class RecipientHelper : JsonHelper
    {
        /// <summary>
        /// Method that converts a JSON string to a List of Recipients objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The List of Recipients that the JSON object represented</returns>
        public static List<Types.Recipient> JsonToRecipientList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            RecipientListJsonHelper helper = JsonConvert.DeserializeObject<RecipientListJsonHelper>(jsonResponse);
            List<Types.Recipient> recipients = new List<Types.Recipient>();
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
        public static Types.Recipient JsonToRecipient(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            RecipientResponseHelper helper = JsonConvert.DeserializeObject<RecipientResponseHelper>(jsonResponse);
            if (helper.Ok)
            {
                return RecipientJsonHelperToRecipient(helper.Recipient);
            }
            return new Types.Recipient();
        }
    }
}
