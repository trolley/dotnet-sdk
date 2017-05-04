using System;
using paymentrails.Types;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.JsonHelpers
{
    class AccountHelper
    {
        public static String BankAccountToJson(BankAccount bank)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (bank.AccountNum != null)
            {
                builder.AppendFormat("\"accountNum\": \"{0}\",\n", bank.AccountNum);
            }
            if (bank.BranchNum != null)
            {
                builder.AppendFormat("\"branchNum\": \"{0}\",\n", bank.BranchNum);
            }
            if (bank.Country != null)
            {
                builder.AppendFormat("\"country\": \"{0}\",\n", bank.Country);
            }
            if (bank.Currency != null)
            {
                builder.AppendFormat("\"currency\": \"{0}\",\n", bank.Currency);
            }
            if (bank.Institution != null)
            {
                builder.AppendFormat("\"institution\": \"{0}\",\n", bank.Institution);
            }
            if (bank.Name != null)
            {
                builder.AppendFormat("\"name\": \"{0}\",\n", bank.Name);
            }
            builder.Append("}");
            return builder.ToString();
        }

        public static String PaypalToJson(PaypalAccount paypal)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (paypal.Email != null)
            {
                builder.AppendFormat("\"email\": \"{0}\",\n", paypal.Email);
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
