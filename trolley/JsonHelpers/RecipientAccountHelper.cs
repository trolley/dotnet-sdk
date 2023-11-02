using Newtonsoft.Json;
using Trolley.Types;
using System;
using System.Collections.Generic;
// using System.Web.Script.Serialization;
// using System.Text.Json;

namespace Trolley.JsonHelpers
{
    public class RecipientAccountHelper : JsonHelper
    {
        /// <summary>
        /// Method that converts a JSON string to a List of RecipientAccounts objects
        /// </summary>
        /// <param name="jsonResponse"></param>
        /// <returns>The List of Recipients that the JSON object represented</returns>
        public static List<Types.RecipientAccount> JsonToRecipientAccountList(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }
            RecipientAccountListJsonHelper helper = JsonConvert.DeserializeObject<RecipientAccountListJsonHelper>(jsonResponse);

            List<Types.RecipientAccount> recipientAccounts = new List<Types.RecipientAccount>();
       

            if (helper.Ok)
            {
                foreach (RecipientAccountJsonHelper r in helper.Accounts)
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
        /// <returns>The Recipient that the JSON object represented</returns>
        public static Types.RecipientAccount JsonToRecipientAccount(string jsonResponse)
        {
            if (jsonResponse == null || jsonResponse == "")
            {
                throw new ArgumentException("JSON must be provided");
            }

            RecipientAccountResponseHelper helper = JsonConvert.DeserializeObject<RecipientAccountResponseHelper>(jsonResponse);
            if (helper.Ok)
            {
                return RecipientAccountJsonHelperToRecipientAccount(helper.Account);
            }
            return new Types.RecipientAccount();
        }
    }
}
