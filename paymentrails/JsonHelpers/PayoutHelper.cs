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
        public static Types.Payout JsonToPayout(string jsonResponse)
        {
            PayoutJsonHelper helper = new JavaScriptSerializer().Deserialize<PayoutJsonHelper>(jsonResponse);
            if (helper.Ok)
                return new Types.Payout(helper.AutoSwitch.Limit, helper.AutoSwitch.Active, helper.Holdup.Limit, helper.AutoSwitch.Active, helper.Method, helper.Primary.Currency.Currency.Code)
            return new Types.Payout();
        }
        public static List<Types.Payout> JsonToPayoutList(string jsonResponse)
        {
            return null;
        }

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

            private AccountsHelper Accounts
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

        private struct AccountsHelper
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
    }
}
