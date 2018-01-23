using PaymentRails.Types;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace PaymentRails.JsonHelpers
{
    public class RecipientAccountHelper : JsonHelper
    {
        /// <summary>
        /// Method that converts a JSON string to a List of Recipients objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The List of Recipients that the JSON object represented</returns>
        public static List<RecipientAccount> JsonToRecipientList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            RecipientAccountListJsonHelper helper = new JavaScriptSerializer().Deserialize<RecipientAccountListJsonHelper>(jsonResponse);
            List<RecipientAccount> recipientAccounts = new List<RecipientAccount>();
            if (helper.Ok)
            {
                foreach (RecipientAccountJsonHelper r in helper.RecipientAccounts)
                {
                    recipientAccounts.Add(RecipientAccountJsonHelperToRecipientAccount(r));
                }
            }
            return recipientAccounts;
        }
        /// <summary>
        /// Method that converts a JSON string to a RecipientAccount objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The RecipientAccount that the JSON object represented</returns>
        public static RecipientAccount JsonToRecipientAccount(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            RecipientAccountResponseHelper helper = new JavaScriptSerializer().Deserialize<RecipientAccountResponseHelper>(jsonResponse);
            if (helper.Ok)
            {
                return RecipientAccountJsonHelperToRecipientAccount(helper.RecipientAccount);
            }
            return new RecipientAccount();
        }
    }
}

