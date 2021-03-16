using PaymentRails.Exceptions;
using Newtonsoft.Json;

namespace PaymentRails.Types
{
  /// <summary>
  /// This class is a representation of a Payment Rails Recipient, it can be used to create or update recipients
  /// over the API
  /// </summary>
  public class RecipientAccount : IPaymentRailsMappable
  {
    public string id;
    public bool primary;
    public string currency;
    public string recipientAccountId;
    public string routeType;
    public string recipientFees;
    public string emailAddress;
    public string country;
    public string type;
    public string iban;
    public string accountNum;
    public string accountHolderName;
    public string swiftBic;
    public string branchId;
    public string bankName;
    public string bankId;
    public string bankAddress;
    public string bankCity;
    public string bankRegionCode;
    public string bankPostalCode;

    public RecipientAccount(string type, string currency, string id, bool primary, string country, string iban = null, string accountNum = null, string recipientAccountId = null, string routeType = null, string recipientFees = null, string emailAddress = null, string accountHolderName = null, string swiftBic = null, string branchId = null, string bankName = null, string bankId = null, string bankAddress = null, string bankCity = null, string bankRegionCode = null, string bankPostalCode = null)

    {
      this.id = id;
      this.primary = primary;
      this.currency = currency;
      this.recipientAccountId = recipientAccountId;
      this.routeType = routeType;
      this.recipientFees = recipientFees;
      this.emailAddress = emailAddress;
      this.country = country;
      this.type = type;
      this.iban = iban;
      this.accountNum = accountNum;
      this.accountHolderName = accountHolderName;
      this.swiftBic = swiftBic;
      this.branchId = branchId;
      this.bankName = bankName;
      this.bankId = bankId;
      this.bankAddress = bankAddress;
      this.bankCity = bankCity;
      this.bankRegionCode = bankRegionCode;
      this.bankPostalCode = bankPostalCode;
    }

    public RecipientAccount()
    {

    }
    public static bool operator ==(RecipientAccount a, RecipientAccount b)
    {
      if (System.Object.ReferenceEquals(a, b))
        return true;
      if ((object)a == null || (object)b == null)
        return false;
      return a.Equals(b);
    }

    public static bool operator !=(RecipientAccount a, RecipientAccount b)
    {
      return !(a == b);
    }
    /// <summary>
    /// Checks whether all fields are equivalent to the object being compared
    /// </summary>
    /// <param name="obj">The object to compare to</param>
    /// <returns>whether the objects are equal</returns>
    public override bool Equals(object obj)
    {
      if (obj != null && obj.GetType() == this.GetType())
      {
        RecipientAccount other = (RecipientAccount)obj;
        if (other.id == this.id && other.primary == this.primary && other.currency == this.currency && other.recipientAccountId == this.recipientAccountId
            && other.routeType == this.routeType && other.recipientFees == this.recipientFees && other.emailAddress == this.emailAddress && other.country == this.country
            && other.type == this.type && other.iban == this.iban && other.accountNum == this.accountNum && other.accountHolderName == this.accountHolderName
            && other.swiftBic == this.swiftBic && other.branchId == this.branchId && other.bankName == this.bankName && other.bankId == this.bankId && other.bankAddress == this.bankAddress
            && other.bankCity == this.bankCity && other.bankRegionCode == this.bankRegionCode && other.bankPostalCode == this.bankPostalCode)
          return true;
      }
      return false;
    }




    /// <summary>
    /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
    /// this function will throw an exception if any of the fields are not properly set.
    /// 
    /// In order to have a valid bank-transfer recipientAccount the type, country, currency, branchId, bankId accountNumber must be set
    /// In order to have a valid paypal recipientAccount the type and email must be set
    /// </summary>
    /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
    public bool IsMappable()
    {
      if (type == null)
      {
        throw new InvalidFieldException("RecipientAccount must have a type");
      }

      if (type == "bank-transfer")
      {
        if (country == null)
        {
          throw new InvalidFieldException("RecipientAccount must have a country if the type is bank-transfer");
        }
        if (currency == null)
        {
          throw new InvalidFieldException("RecipientAccount must have a currency if the type is bank-transfer");
        }
        if (accountNum == null && iban == null)
        {
          throw new InvalidFieldException("RecipientAccount must have an AccountNumber or an IBAN if the type is bank-transfer");
        }
      }

      if (type == "paypal")
        if (emailAddress == null)
        {
          throw new InvalidFieldException("RecipientAccount must have an email if the type is paypal");
        }

      return true;
    }


    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override string ToString()
    {
      return this.ToJson();
    }
    /// <summary>
    /// Returns a JSON string representation of the object formatted to be compliant with
    /// the Payment Rails API post and patch endpoints
    /// </summary>
    /// <returns>JSON string representation of the object</returns>
    public string ToJson()
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };

        return JsonConvert.SerializeObject(this, settings);
    }
  }
}
