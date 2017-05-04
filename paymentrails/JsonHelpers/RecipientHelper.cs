using System;
using paymentrails.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace paymentrails.JsonHelpers
{
    class RecipientHelper : JsonHelper
    {
        public static List<Recipient> JsonToRecipientList(string jsonResponse)
        {
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

        public static Recipient JsonToRecipient(string jsonResponse)
        {
            RecipientResponseHelper helper = new JavaScriptSerializer().Deserialize<RecipientResponseHelper>(jsonResponse);
            if (helper.Ok)
            {
                return RecipientJsonHelperToRecipient(helper.Recipient);
            }
            return new Recipient();
        }
    }
}
