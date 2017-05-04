using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using paymentrails.Types;
using System.Web.Script.Serialization;

namespace paymentrails.JsonHelpers
{
    class PayoutHelper
    {
        /// <summary>
        /// Function to convert Payout object into JSON string. 
        /// 
        /// This string can be sent to the post and patch endpoints of the API.
        /// </summary>
        /// <param name="payout">the payout object to be converted</param>
        /// <param name="withAutoSwitch">weather to include the autoswitch fields in the JSON object</param>
        /// <param name="withHoldup">weather to include the holdup fields in the JSON object</param>
        /// <returns>a JSON string representation of payout</returns>
        public static string PayoutToJson(Payout payout, bool withAutoSwitch = true, bool withHoldup = true)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{\n");
            if (withAutoSwitch)
                builder.AppendFormat("\"autoSwitch\": {{\n\t \"limit\": {0},\n\t \"active\": {1}\n}}\n",
                    payout.AutoswitchLimit, payout.AutoswitchActive);
            if (withHoldup)
                builder.AppendFormat("\"holdup\": {{\n\t \"limit\": {0},\n\t \"active\": {1}\n}}\n",
                    payout.HoldupLimit, payout.HoldupActive);
            if (payout.PrimaryCurrency != null)
            {
                builder.AppendFormat("\"currency\": {{\n\t \"code\": {0}\n}},\n", payout.PrimaryCurrency);
            }
            if (payout.PrimaryMethod != null)
            {
                builder.AppendFormat("\"primary\": {0},\n", payout.PrimaryMethod);
            }
            if (payout.Paypal != null || payout.Bank != null)
            {
                builder.Append("\n\"accounts\": {\n");
                if (payout.Bank != null)
                {
                    builder.AppendFormat("\"bank\": {0},\n", AccountHelper.BankAccountToJson(payout.Bank));
                }
                if (payout.Paypal != null)
                {
                    builder.AppendFormat("\"paypal\": {0},\n", AccountHelper.PaypalToJson(payout.Paypal));
                }
                builder.Append("}\n");
            }
            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Function to convert the json results of a query to the PaymentRails payout method API into a 
        /// Payout object for use within c#
        /// </summary>
        /// <param name="jsonResponse">String returned by the API</param>
        /// <returns>Payout object with the values from the API</returns>
        public static Types.Payout JsonToPayout(string jsonResponse)
        {
            PayoutJsonHelper helper = new JavaScriptSerializer().Deserialize<PayoutJsonHelper>(jsonResponse);
            if (helper.Ok)
            {
                return new Types.Payout(helper.AutoSwitch.Limit, helper.AutoSwitch.Active, helper.Holdup.Limit, helper.Holdup.Active, helper.Method, helper.Primary.Currency.Currency.Code, helper.Accounts.Bank, helper.Accounts.Paypal);
            }
            return new Types.Payout();
        }

        public static List<Types.Payout> JsonToPayoutList(string jsonResponse)
        {
            return null;
        }

        #region Structs and classes for JavaScriptSerializer
        private struct PayoutJsonHelper
        {
            private bool ok;
            private LimitActiveHelper autoSwitch;
            private LimitActiveHelper holdup;
            private PrimaryHelper primary;
            private string method;
            private AccountsHelper accounts;

            public bool Ok
            {
                get
                {
                    return ok;
                }

                set
                {
                    ok = value;
                }
            }

            public LimitActiveHelper AutoSwitch
            {
                get
                {
                    return autoSwitch;
                }

                set
                {
                    autoSwitch = value;
                }
            }

            public LimitActiveHelper Holdup
            {
                get
                {
                    return holdup;
                }

                set
                {
                    holdup = value;
                }
            }

            public PrimaryHelper Primary
            {
                get
                {
                    return primary;
                }

                set
                {
                    primary = value;
                }
            }

            public string Method
            {
                get
                {
                    return method;
                }

                set
                {
                    method = value;
                }
            }

            public AccountsHelper Accounts
            {
                get
                {
                    return accounts;
                }

                set
                {
                    accounts = value;
                }
            }

            public PayoutJsonHelper(bool ok, LimitActiveHelper autoSwitch, LimitActiveHelper holdup, PrimaryHelper primary, string method, AccountsHelper accounts)
            {
                this.ok = ok;
                this.autoSwitch = autoSwitch;
                this.holdup = holdup;
                this.primary = primary;
                this.method = method;
                this.accounts = accounts;
            }
        }

        private class AccountsHelper
        {
            private Types.BankAccount bank;
            private Types.PaypalAccount paypal;

            public BankAccount Bank
            {
                get
                {
                    return bank;
                }

                set
                {
                    bank = value;
                }
            }

            public PaypalAccount Paypal
            {
                get
                {
                    return paypal;
                }

                set
                {
                    paypal = value;
                }
            }

            public AccountsHelper(BankAccount bank, PaypalAccount paypal)
            {
                this.bank = bank;
                this.paypal = paypal;
            }

            public AccountsHelper()
            {

            }
        }

        private struct PrimaryHelper
        {
            string method;
            private OuterCurrencyHelper currency;

            public string Method
            {
                get
                {
                    return method;
                }

                set
                {
                    method = value;
                }
            }

            public OuterCurrencyHelper Currency
            {
                get
                {
                    return currency;
                }

                set
                {
                    currency = value;
                }
            }

            public PrimaryHelper(string method, OuterCurrencyHelper currency)
            {
                this.method = method;
                this.currency = currency;
            }
        }

        private struct OuterCurrencyHelper
        {
            private InnerCurrencyHelper currency;

            public OuterCurrencyHelper(InnerCurrencyHelper currency)
            {
                this.currency = currency;
            }

            public InnerCurrencyHelper Currency
            {
                get
                {
                    return currency;
                }

                set
                {
                    currency = value;
                }
            }
        }

        private struct InnerCurrencyHelper
        {
            private string code;
            private string name;

            public InnerCurrencyHelper(string code, string name)
            {
                this.code = code;
                this.name = name;
            }

            public string Code
            {
                get
                {
                    return code;
                }

                set
                {
                    code = value;
                }
            }

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }
        }

        private struct LimitActiveHelper
        {
            private float limit;
            private bool active;

            public float Limit
            {
                get
                {
                    return limit;
                }

                set
                {
                    limit = value;
                }
            }

            public bool Active
            {
                get
                {
                    return active;
                }

                set
                {
                    active = value;
                }
            }

            public LimitActiveHelper(float limit, bool active)
            {
                this.limit = limit;
                this.active = active;
            }
        }
        #endregion
    }
}
