using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentRails.Types
{
    /// <summary>
    /// This interface represents an object that can be POSTed or PATCHed to the Payment Rails API
    /// </summary>
    public interface IPaymentRailsMappable
    {
        /// <summary>
        /// Returns a JSON string representation of the object formatted to be compliant with
        /// the Payment Rails API post and patch endpoints
        /// </summary>
        /// <returns>JSON string representation of the object</returns>
        String ToJson();

        /// <summary>
        /// Function that checks if a IPaymentRailsMappable object has all required fields to be sent
        /// this function will throw an exception if any of the fields are not properly set.
        /// </summary>
        /// <returns>weather the object is ready to be sent to the Payment Rails API</returns>
        bool IsMappable();
    }
}
