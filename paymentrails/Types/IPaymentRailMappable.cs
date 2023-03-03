namespace PaymentRails.Types
{
    /// <summary>
    /// This interface represents an object that can be POSTed or PATCHed to the Trolley API
    /// </summary>
    public interface IPaymentRailsMappable
    {
        /// <summary>
        /// Returns a JSON string representation of the object formatted to be compliant with
        /// the Trolley API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
        string ToJson();

        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Trolley API</returns>
        bool IsMappable();
    }
}
