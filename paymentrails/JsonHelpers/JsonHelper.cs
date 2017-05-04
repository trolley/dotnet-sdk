using System;
using System.Collections.Generic;
using paymentrails.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.JsonHelpers
{
    public abstract class JsonHelper
    {
        #region Helper to type Mapping functions
        protected static Payout PayoutJsonHelperToPayout(PayoutJsonHelper helper)
        {
            return new Types.Payout(helper.AutoSwitch.Limit, helper.AutoSwitch.Active, helper.Holdup.Limit, helper.Holdup.Active, helper.Method, helper.Primary.Currency.Currency.Code, helper.Accounts.Bank, helper.Accounts.Paypal);
        }

        protected static Recipient RecipientJsonHelperToRecipient(RecipientJsonHelper helper)
        {
            Payout payout = PayoutJsonHelperToPayout(helper.Payout);
            Recipient recipient = new Recipient(helper.Id, helper.ReferenceId, helper.Email, helper.Name,
                helper.FirstName, helper.LastName, helper.Type, helper.Status, helper.TimeZone, helper.Language,
                helper.Dob, helper.GravatarUrl, helper.Compliance, payout, helper.Address);

            return recipient;
        }
        #endregion

        #region Recipient classes
        protected class RecipientResponseHelper
        {
            private bool ok;
            private RecipientJsonHelper recipient;

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

            public RecipientJsonHelper Recipient
            {
                get
                {
                    return recipient;
                }

                set
                {
                    recipient = value;
                }
            }

            public RecipientResponseHelper(bool ok, RecipientJsonHelper recipient)
            {
                this.ok = ok;
                this.recipient = recipient;
            }

            public RecipientResponseHelper()
            {

            }
        }

        protected class RecipientJsonHelper
        {
            private string id;
            private string referenceId;
            private string email;
            private string name;
            private string firstName;
            private string lastName;
            private string type;
            private string status;
            private string timeZone;
            private string language;
            private string dob;
            private string gravatarUrl;

            private Compliance compliance;
            private PayoutJsonHelper payout;
            private Address address;

            #region properties
            public string Id
            {
                get
                {
                    return id;
                }

                set
                {
                    id = value;
                }
            }

            public string ReferenceId
            {
                get
                {
                    return referenceId;
                }

                set
                {
                    referenceId = value;
                }
            }

            public string Email
            {
                get
                {
                    return email;
                }

                set
                {
                    email = value;
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

            public string FirstName
            {
                get
                {
                    return firstName;
                }

                set
                {
                    firstName = value;
                }
            }

            public string LastName
            {
                get
                {
                    return lastName;
                }

                set
                {
                    lastName = value;
                }
            }

            public string Type
            {
                get
                {
                    return type;
                }

                set
                {
                    type = value;
                }
            }

            public string Status
            {
                get
                {
                    return status;
                }

                set
                {
                    status = value;
                }
            }

            public string TimeZone
            {
                get
                {
                    return timeZone;
                }

                set
                {
                    timeZone = value;
                }
            }

            public string Language
            {
                get
                {
                    return language;
                }

                set
                {
                    language = value;
                }
            }

            public string Dob
            {
                get
                {
                    return dob;
                }

                set
                {
                    dob = value;
                }
            }

            public string GravatarUrl
            {
                get
                {
                    return gravatarUrl;
                }

                set
                {
                    gravatarUrl = value;
                }
            }

            public Compliance Compliance
            {
                get
                {
                    return compliance;
                }

                set
                {
                    compliance = value;
                }
            }

            public PayoutJsonHelper Payout
            {
                get
                {
                    return payout;
                }

                set
                {
                    payout = value;
                }
            }

            public Address Address
            {
                get
                {
                    return address;
                }

                set
                {
                    address = value;
                }
            }
            #endregion

            public RecipientJsonHelper(string id, string referenceId, string email, string name, string firstName, string lastName, string type, string status, string timeZone, string language, string dob, string gravatarUrl, Compliance compliance, PayoutJsonHelper payout, Address address)
            {
                this.id = id;
                this.referenceId = referenceId;
                this.email = email;
                this.name = name;
                this.firstName = firstName;
                this.lastName = lastName;
                this.type = type;
                this.status = status;
                this.timeZone = timeZone;
                this.language = language;
                this.dob = dob;
                this.gravatarUrl = gravatarUrl;
                this.compliance = compliance;
                this.payout = payout;
                this.address = address;
            }

            public RecipientJsonHelper()
            {

            }


        }

        protected class RecipientListJsonHelper
        {
            private bool ok;
            private List<RecipientJsonHelper> recipients;
            #region properties
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

            public List<RecipientJsonHelper> Recipients
            {
                get
                {
                    return recipients;
                }

                set
                {
                    recipients = value;
                }
            }
            #endregion
            public RecipientListJsonHelper(bool ok, List<RecipientJsonHelper> recipients)
            {
                this.ok = ok;
                this.recipients = recipients;
            }

            public RecipientListJsonHelper()
            {

            }
        }
        #endregion
        #region Balance classes
        protected struct JsonBalancesHelper
        {
            public Boolean ok { get; set; }
            public Dictionary<String, Types.Balance> balances { get; set; }

            public JsonBalancesHelper(bool ok, Dictionary<string, Types.Balance> balances) : this()
            {
                this.ok = ok;
                this.balances = balances;
            }
        }
        #endregion
        #region Payout classes
        protected struct PayoutJsonHelper
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

        protected class AccountsHelper
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

        protected struct PrimaryHelper
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

        protected struct OuterCurrencyHelper
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

        protected struct InnerCurrencyHelper
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

        protected struct LimitActiveHelper
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
