using System;
using System.Collections.Generic;
using PaymentRails.Types;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails.JsonHelpers
{
    public abstract class JsonHelper
    {
        #region Helper to type Mapping functions
        protected static Payout PayoutJsonHelperToPayout(PayoutJsonHelper helper)
        {
            if(helper == null)
            {
                return null;
            }
            float autoswitchLimit = 0, holdupLimit = 0;
            bool autoswitchActive = false, holdupActive = false;
            string currency = null;
            BankAccount bank = null;
            PaypalAccount paypal = null;
            if(helper.AutoSwitch == null && helper.Holdup == null)
            {
                return null;
            }
            if(helper.AutoSwitch != null)
            {
                autoswitchLimit = helper.AutoSwitch.Limit;
                autoswitchActive = helper.AutoSwitch.Active;
            }
            if (helper.Holdup != null)
            {
                holdupLimit = helper.Holdup.Limit;
                holdupActive = helper.Holdup.Active;
            }
            if (helper.Primary != null)
            {
                currency = helper.Primary.Currency.Currency.Code;
            }
            if (helper.Accounts != null)
            {
                bank = helper.Accounts.Bank;
                paypal = helper.Accounts.Paypal;
            }
            return new Types.Payout(autoswitchLimit, autoswitchActive, holdupLimit, holdupActive, helper.Method, currency, bank, paypal);
        }

        protected static Recipient RecipientJsonHelperToRecipient(RecipientJsonHelper helper)
        {
            Payout payout = PayoutJsonHelperToPayout(helper.Payout);
            Recipient recipient = new Recipient(helper.Id, helper.Type, helper.ReferenceId, helper.Email, helper.Name,
                helper.FirstName, helper.LastName, helper.Status, helper.TimeZone, helper.Language,
                helper.Dob, helper.GravatarUrl, helper.Compliance, payout, helper.Address);

            return recipient;
        }

        protected static Payment PaymentJsonHelperToPayment(PaymentJsonHelper helper)
        {
            string batchId = null;
            if(helper.Batch != null)
            {
                batchId = helper.Batch.Id;
            }
            Recipient recipient = RecipientJsonHelperToRecipient(helper.Recipient);
            Payment payment = new Payment(recipient, helper.SourceAmount, helper.Memo, helper.TargetAmount, helper.TargetCurrency, helper.ExchangeRate,
                helper.Fees, helper.RecipientFees, helper.FxRate, helper.ProcessedAt, helper.CreatedAt, helper.UpdatedAt, helper.MerchantFees, helper.SourceCurrency,
                batchId, helper.Id, helper.Status, helper.Compliance);
            return payment;
        }

        protected static Batch BatchJsonHelperToBatch(BatchJsonHelper helper)
        {
            List<Payment> payments = null;
            if (helper.Payments != null)
            {
                payments = new List<Payment>();
                foreach (PaymentJsonHelper p in helper.Payments.Payments)
                {
                    payments.Add(PaymentJsonHelperToPayment(p));
                    payments.Last().BatchId = helper.Id;
                }
            }
            Batch batch = new Batch(helper.Description, payments, helper.Currency, helper.Amount, helper.TotalPayments, helper.Status,
                helper.SentAt, helper.CompletedAt, helper.CreatedAt, helper.UpdatedAt, helper.Id);
            return batch;
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
            public Dictionary<String, Balance> balances { get; set; }

            public JsonBalancesHelper(bool ok, Dictionary<string, Balance> balances) : this()
            {
                this.ok = ok;
                this.balances = balances;
            }
        }
        #endregion
        #region Payout classes
        protected class PayoutJsonHelper
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

            public PayoutJsonHelper()
            {

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

        protected class PrimaryHelper
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

            public PrimaryHelper()
            {

            }
        }

        protected class OuterCurrencyHelper
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

            public OuterCurrencyHelper()
            {

            }
        }

        protected class InnerCurrencyHelper
        {
            private string code;
            private string name;

            public InnerCurrencyHelper(string code, string name)
            {
                this.code = code;
                this.name = name;
            }

            public InnerCurrencyHelper()
            {

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

        protected class LimitActiveHelper
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

            public LimitActiveHelper()
            {

            }
        }
        #endregion
        #region Payment classes
        protected class PaymentResponseJsonHelper
        {
            private bool ok;
            private PaymentJsonHelper payment;

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

            public PaymentJsonHelper Payment
            {
                get
                {
                    return payment;
                }

                set
                {
                    payment = value;
                }
            }

            public PaymentResponseJsonHelper()
            {

            }
        }

        protected class PaymentJsonHelper
        {
            private string id;
            private string status;
            private double sourceAmount;
            private double exchangeRate;
            private double fees;
            private double recipientFees;
            private double targetAmount;
            private double fxRate;
            private string memo;
            private string processedAt;
            private string createdAt;
            private string updatedAt;
            private double merchantFees;
            private string sourceCurrency;
            private string targetCurrency;

            private PaymentBatchJsonHelper batch;
            private RecipientJsonHelper recipient;
            private Compliance compliance;

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

            public double SourceAmount
            {
                get
                {
                    return sourceAmount;
                }

                set
                {
                    sourceAmount = value;
                }
            }

            public double ExchangeRate
            {
                get
                {
                    return exchangeRate;
                }

                set
                {
                    exchangeRate = value;
                }
            }

            public double Fees
            {
                get
                {
                    return fees;
                }

                set
                {
                    fees = value;
                }
            }

            public double RecipientFees
            {
                get
                {
                    return recipientFees;
                }

                set
                {
                    recipientFees = value;
                }
            }

            public double TargetAmount
            {
                get
                {
                    return targetAmount;
                }

                set
                {
                    targetAmount = value;
                }
            }

            public double FxRate
            {
                get
                {
                    return fxRate;
                }

                set
                {
                    fxRate = value;
                }
            }

            public string Memo
            {
                get
                {
                    return memo;
                }

                set
                {
                    memo = value;
                }
            }

            public string ProcessedAt
            {
                get
                {
                    return processedAt;
                }

                set
                {
                    processedAt = value;
                }
            }

            public string CreatedAt
            {
                get
                {
                    return createdAt;
                }

                set
                {
                    createdAt = value;
                }
            }

            public string UpdatedAt
            {
                get
                {
                    return updatedAt;
                }

                set
                {
                    updatedAt = value;
                }
            }

            public double MerchantFees
            {
                get
                {
                    return merchantFees;
                }

                set
                {
                    merchantFees = value;
                }
            }

            public string SourceCurrency
            {
                get
                {
                    return sourceCurrency;
                }

                set
                {
                    sourceCurrency = value;
                }
            }

            public string TargetCurrency
            {
                get
                {
                    return targetCurrency;
                }

                set
                {
                    targetCurrency = value;
                }
            }

            public PaymentBatchJsonHelper Batch
            {
                get
                {
                    return batch;
                }

                set
                {
                    batch = value;
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
            #endregion

            public PaymentJsonHelper()
            {

            }
        }

        protected class PaymentBatchJsonHelper
        {
            private string id;
            private string createdAt;
            private string updatedAt;
            private string sentAt;
            private string completedAt;

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

            public string CreatedAt
            {
                get
                {
                    return createdAt;
                }

                set
                {
                    createdAt = value;
                }
            }

            public string UpdatedAt
            {
                get
                {
                    return updatedAt;
                }

                set
                {
                    updatedAt = value;
                }
            }

            public string SentAt
            {
                get
                {
                    return sentAt;
                }

                set
                {
                    sentAt = value;
                }
            }

            public string CompletedAt
            {
                get
                {
                    return completedAt;
                }

                set
                {
                    completedAt = value;
                }
            }
            #endregion

            public PaymentBatchJsonHelper()
            {

            }
        }
       
        protected class PaymentListJsonHelper
        {
            private bool ok;
            private List<PaymentJsonHelper> payments;
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

            public List<PaymentJsonHelper> Payments
            {
                get
                {
                    return payments;
                }

                set
                {
                    payments = value;
                }
            }
            #endregion
            public PaymentListJsonHelper(bool ok, List<PaymentJsonHelper> payments)
            {
                this.ok = ok;
                this.payments = payments;
            }

            public PaymentListJsonHelper()
            {

            }
        }

        #endregion
        #region Batch Classes
        protected class BatchResponseJsonHelper
        {
            private bool ok;
            BatchJsonHelper batch;

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

            public BatchJsonHelper Batch
            {
                get
                {
                    return batch;
                }

                set
                {
                    batch = value;
                }
            }

            public BatchResponseJsonHelper()
            {

            }
        }

        protected class BatchPaymentPaginationJsonHelper
        {
            private List<PaymentJsonHelper> payments;
            private PaginationJsonHelper meta;

            public List<PaymentJsonHelper> Payments
            {
                get
                {
                    return payments;
                }

                set
                {
                    payments = value;
                }
            }

            public PaginationJsonHelper Meta
            {
                get
                {
                    return meta;
                }

                set
                {
                    meta = value;
                }
            }

            public BatchPaymentPaginationJsonHelper()
            {

            }

        }

        protected class BatchJsonHelper
        {
            private string id;
            private string status;
            private double amount;
            private int totalPayments;
            private string currency;
            private string description;
            private string sentAt;
            private string completedAt;
            private string createdAt;
            private string updatedAt;

            private BatchPaymentPaginationJsonHelper payments;

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

            public double Amount
            {
                get
                {
                    return amount;
                }

                set
                {
                    amount = value;
                }
            }

            public int TotalPayments
            {
                get
                {
                    return totalPayments;
                }

                set
                {
                    totalPayments = value;
                }
            }

            public string Currency
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

            public string Description
            {
                get
                {
                    return description;
                }

                set
                {
                    description = value;
                }
            }

            public string SentAt
            {
                get
                {
                    return sentAt;
                }

                set
                {
                    sentAt = value;
                }
            }

            public string CompletedAt
            {
                get
                {
                    return completedAt;
                }

                set
                {
                    completedAt = value;
                }
            }

            public string CreatedAt
            {
                get
                {
                    return createdAt;
                }

                set
                {
                    createdAt = value;
                }
            }

            public string UpdatedAt
            {
                get
                {
                    return updatedAt;
                }

                set
                {
                    updatedAt = value;
                }
            }

            public BatchPaymentPaginationJsonHelper Payments
            {
                get
                {
                    return payments;
                }

                set
                {
                    payments = value;
                }
            }

            public BatchJsonHelper()
            {

            }
        }
        
        protected class BatchListJsonHelper
        {
            private bool ok;
            private List<BatchJsonHelper> batches;
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

            public List<BatchJsonHelper> Batches
            {
                get
                {
                    return batches;
                }

                set
                {
                    batches = value;
                }
            }
            #endregion
            public BatchListJsonHelper(bool ok, List<BatchJsonHelper> batches)
            {
                this.ok = ok;
                this.batches = batches;
            }

            public BatchListJsonHelper()
            {

            }
        }
        
        #endregion

        #region Misc classes
        protected class PaginationJsonHelper
        {
            private string page;
            private string pages;
            private string records;

            #region Properties
            public string Page
            {
                get
                {
                    return page;
                }

                set
                {
                    page = value;
                }
            }

            public string Pages
            {
                get
                {
                    return pages;
                }

                set
                {
                    pages = value;
                }
            }

            public string Records
            {
                get
                {
                    return records;
                }

                set
                {
                    records = value;
                }
            }
            #endregion

            public PaginationJsonHelper()
            {

            }
        }
        #endregion
    }
}
