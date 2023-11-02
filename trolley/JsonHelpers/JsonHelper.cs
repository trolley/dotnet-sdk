using System;
using System.Collections.Generic;
using Trolley.Types;
using System.Linq;

namespace Trolley.JsonHelpers
{
    public abstract class JsonHelper
    {
        #region Helper to type Mapping functions
        protected static Types.Recipient RecipientJsonHelperToRecipient(RecipientJsonHelper helper)
        {
            List<Types.RecipientAccount> accounts = null;

            if (helper.Accounts != null)
            {
                accounts = new List<Types.RecipientAccount>();
                foreach (Types.RecipientAccount p in helper.Accounts)
                {
                    accounts.Add(p);
                }
            }

            Types.Recipient recipient = new Types.Recipient(helper.Type, helper.Email, helper.Name, helper.FirstName, helper.LastName, helper.Id, helper.ReferenceId, helper.Status, helper.TimeZone, helper.Language, helper.Dob, helper.GravatarUrl, helper.RouteType, helper.RouteMinimum, helper.Compliance, accounts, helper.Address);
            return recipient;
        }

        protected static Types.RecipientAccount RecipientAccountJsonHelperToRecipientAccount(RecipientAccountJsonHelper helper)
        {
            Types.RecipientAccount recipientAccount = new Types.RecipientAccount(helper.Type, helper.Currency, helper.Id, helper.Primary, helper.Country, helper.Iban, helper.AccountNum, helper.RecipientAccountId, helper.RouteType, helper.RecipientFees, helper.EmailAddress, helper.AccountHolderName, helper.SwiftBic, helper.BranchId, helper.BankName, helper.BankId, helper.BankAddress, helper.BankCity, helper.BankRegionCode, helper.BankPostalCode);
            return recipientAccount;
        }

        protected static Types.Payment PaymentJsonHelperToPayment(PaymentJsonHelper helper)
        {
            string batchId = null;
            if (helper.Batch != null)
            {
                batchId = helper.Batch.Id;
            }
            Types.Recipient recipient = RecipientJsonHelperToRecipient(helper.Recipient);

            Types.Payment payment = new Types.Payment(recipient, helper.SourceAmount, helper.SourceCurrency, helper.TargetAmount, helper.TargetCurrency, helper.Id, helper.Memo, helper.ExchangeRate, helper.Fees, helper.RecipientFees, helper.FxRate, helper.ProcessedAt, helper.CreatedAt, helper.UpdatedAt, helper.MerchantFees, batchId, helper.Status, helper.Compliance);
            return payment;
        }

        protected static Types.Batch BatchJsonHelperToBatch(BatchJsonHelper helper)
        {
            List<Types.Payment> payments = null;
            if (helper.Payments != null)
            {
                payments = new List<Types.Payment>();
                foreach (PaymentJsonHelper p in helper.Payments.Payments)
                {
                    payments.Add(PaymentJsonHelperToPayment(p));
                    payments.Last().batchId = helper.Id;
                }
            }
            Types.Batch batch = new Types.Batch(helper.Description, payments, helper.Currency, helper.Amount, helper.TotalPayments, helper.Status,
                helper.SentAt, helper.CompletedAt, helper.CreatedAt, helper.UpdatedAt, helper.Id);
            return batch;
        }

        protected static Balance BalanceJsonHelperToBalance(BalanceJsonHelper helper)
        {

            //List<Balance> balances = new List<Balance>();
            //foreach (BalanceJsonHelper b in helper.Payments.Payments)
            //{
            //    payments.Add(PaymentJsonHelperToPayment(p));
            //    payments.Last().batchId = helper.Id;
            //}
            Balance helperBalance = helper.Balance;
            Balance balance = helperBalance;
            return balance;
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

        protected class RecipientRecipientAccountPaginationJsonHelper
        {
            //private List<RecipientAccountJsonHelper> recipientAccounts;

            public List<RecipientAccountJsonHelper> RecipientAccounts
            {
                get
                {
                    return RecipientAccounts;
                }
                set
                {
                    RecipientAccounts = value;
                }
            }
            public RecipientRecipientAccountPaginationJsonHelper()
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
            private string routeType;
            private string routeMinium;

            private Compliance compliance;
            private List<Types.RecipientAccount> accounts;
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

            public string RouteType
            {
                get
                {
                    return routeType;
                }

                set
                {
                    routeType = value;
                }
            }

            public string RouteMinimum
            {
                get
                {
                    return routeMinium;
                }

                set
                {
                    routeMinium = value;
                }
            }

            public List<Types.RecipientAccount> Accounts
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

            public RecipientJsonHelper(string id, string referenceId, string email, string name, string firstName, string lastName, string type, string status, string timeZone, string language, string dob, string gravatarUrl, Compliance compliance, List<Types.RecipientAccount> accounts, Address address)
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
                this.accounts = accounts;
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
        #region RecipientAccount classes
        protected class RecipientAccountResponseHelper
        {
            private bool ok;
            private RecipientAccountJsonHelper recipientAccount;

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

            public RecipientAccountJsonHelper Account
            {
                get
                {
                    return recipientAccount;
                }

                set
                {
                    recipientAccount = value;
                }
            }

            public RecipientAccountResponseHelper(bool ok, RecipientAccountJsonHelper recipientAccount)
            {
                this.ok = ok;
                this.recipientAccount = recipientAccount;
            }

            public RecipientAccountResponseHelper()
            {

            }
        }

        protected class RecipientAccountJsonHelper
        {
            private string id;
            private bool primary;
            private string currency;
            private string recipientAccountId;
            private string routeType;
            private string recipientFees;
            private string emailAddress;
            private string country;
            private string type;
            private string iban;
            private string accountNum;
            private string accountHolderName;
            private string swiftBic;
            private string branchId;
            private string bankName;
            private string bankId;
            private string bankAddress;
            private string bankCity;
            private string bankRegionCode;
            private string bankPostalCode;

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

            public bool Primary
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

            public string RecipientAccountId
            {
                get
                {
                    return recipientAccountId;
                }

                set
                {
                    recipientAccountId = value;
                }
            }

            public string RouteType
            {
                get
                {
                    return routeType;
                }

                set
                {
                    routeType = value;
                }
            }

            public string RecipientFees
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

            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }

                set
                {
                    emailAddress = value;
                }
            }

            public string Country
            {
                get
                {
                    return country;
                }

                set
                {
                    country = value;
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

            public string Iban
            {
                get
                {
                    return iban;
                }

                set
                {
                    iban = value;
                }
            }

            public string AccountNum
            {
                get
                {
                    return accountNum;
                }

                set
                {
                    accountNum = value;
                }
            }

            public string AccountHolderName
            {
                get
                {
                    return accountHolderName;
                }

                set
                {
                    accountHolderName = value;
                }
            }

            public string SwiftBic
            {
                get
                {
                    return swiftBic;
                }

                set
                {
                    swiftBic = value;
                }
            }

            public string BranchId
            {
                get
                {
                    return branchId;
                }

                set
                {
                    branchId = value;
                }
            }

            public string BankName
            {
                get
                {
                    return bankName;
                }

                set
                {
                    bankName = value;
                }
            }

            public string BankId
            {
                get
                {
                    return bankId;
                }

                set
                {
                    bankId = value;
                }
            }

            public string BankAddress
            {
                get
                {
                    return bankAddress;
                }

                set
                {
                    bankAddress = value;
                }
            }

            public string BankCity
            {
                get
                {
                    return bankCity;
                }

                set
                {
                    bankCity = value;
                }
            }

            public string BankRegionCode
            {
                get
                {
                    return bankRegionCode;
                }

                set
                {
                    bankRegionCode = value;
                }
            }

            public string BankPostalCode
            {
                get
                {
                    return bankPostalCode;
                }

                set
                {
                    bankPostalCode = value;
                }
            }
            #endregion

            public RecipientAccountJsonHelper(string id, bool primary, string currency, string recipientAccountId, string routeType, string recipientFees, string emailAddress, string country, string type, string iban, string accountNum, string accountHolderName, string swiftBic, string branchId, string bankName, string bankId, string bankAddress, string bankCity, string bankRegionCode, string bankPostalCode)
            {
                this.Id = id;
                this.Primary = primary;
                this.Currency = currency;
                this.RecipientAccountId = recipientAccountId;
                this.RouteType = routeType;
                this.RecipientFees = recipientFees;
                this.EmailAddress = emailAddress;
                this.Country = country;
                this.Type = type;
                this.Iban = iban;
                this.AccountNum = accountNum;
                this.AccountHolderName = accountHolderName;
                this.SwiftBic = swiftBic;
                this.BranchId = branchId;
                this.BankName = bankName;
                this.BankId = bankId;
                this.BankAddress = bankAddress;
                this.BankCity = bankCity;
                this.BankRegionCode = bankRegionCode;
                this.BankPostalCode = bankPostalCode;
            }

            public RecipientAccountJsonHelper()
            {

            }


        }

        protected class RecipientAccountListJsonHelper
        {
            private bool ok;
            private List<RecipientAccountJsonHelper> recipientAccounts;
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

            public List<RecipientAccountJsonHelper> Accounts
            {
                get
                {
                    return recipientAccounts;
                }

                set
                {
                    recipientAccounts = value;
                }
            }
            #endregion
            public RecipientAccountListJsonHelper(bool ok, List<RecipientAccountJsonHelper> recipientAccounts)
            {
                this.ok = ok;
                this.recipientAccounts = recipientAccounts;
            }

            public RecipientAccountListJsonHelper()
            {

            }
        }
        #endregion
        #region Balance classes
        protected struct BalanceJsonHelper
        {
            public Boolean Ok { get; set; }
            public Balance Balance { get; set; }

            public BalanceJsonHelper(bool ok, Balance balance) : this()
            {
                this.Ok = ok;
                this.Balance = balance;
            }
        }

        protected struct BalanceListJsonHelper
        {
            public Boolean Ok { get; set; }
            public List<BalanceJsonHelper> Balances { get; set; }

            public BalanceListJsonHelper(bool ok, List<BalanceJsonHelper> balances) : this()
            {
                this.Ok = ok;
                this.Balances = balances;
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
            private BankAccountHelper bank;
            private Types.PaypalAccount paypal;

            public BankAccountHelper Bank
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

            public AccountsHelper(BankAccountHelper bank, PaypalAccount paypal)
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

        protected class BankAccountHelper
        {
            private string institution;
            private string branchNum;
            private string currency;
            private string country;
            private string name;
            private string accountNum;
            private string routing;
            private string iban;
            private string swiftBic;
            private string governmentID;
            private string bankAddress;
            private string bankCity;
            private string bankRegion;
            private string bankPostalCode;
            private string bankProvince;

            public string Institution
            {
                get
                {
                    return institution;
                }

                set
                {
                    institution = value;
                }
            }

            public string BranchNum
            {
                get
                {
                    return branchNum;
                }

                set
                {
                    branchNum = value;
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

            public string Country
            {
                get
                {
                    return country;
                }

                set
                {
                    country = value;
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

            public string AccountNum
            {
                get
                {
                    return accountNum;
                }

                set
                {
                    accountNum = value;
                }
            }

            public string Routing
            {
                get
                {
                    return routing;
                }

                set
                {
                    routing = value;
                }
            }

            public string Iban
            {
                get
                {
                    return iban;
                }

                set
                {
                    iban = value;
                }
            }

            public string SwiftBic
            {
                get
                {
                    return swiftBic;
                }

                set
                {
                    swiftBic = value;
                }
            }

            public string GovernmentID
            {
                get
                {
                    return governmentID;
                }

                set
                {
                    governmentID = value;
                }
            }

            public string BankAddress
            {
                get
                {
                    return bankAddress;
                }

                set
                {
                    bankAddress = value;
                }
            }

            public string BankCity
            {
                get
                {
                    return bankCity;
                }

                set
                {
                    bankCity = value;
                }
            }

            public string BankRegion
            {
                get
                {
                    return bankRegion;
                }

                set
                {
                    bankRegion = value;
                }
            }

            public string BankPostalCode
            {
                get
                {
                    return bankPostalCode;
                }

                set
                {
                    bankPostalCode = value;
                }
            }

            public string BankProvince
            {
                get
                {
                    return bankProvince;
                }

                set
                {
                    bankProvince = value;
                }
            }

            public BankAccountHelper()
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
