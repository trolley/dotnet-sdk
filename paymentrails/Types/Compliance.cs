using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    /// <summary>
    /// This class shows whether the associated object is compliant with are variety of background checks.
    /// This data type is read only and can not be modified over the API
    /// </summary>
    public class Compliance
    {
        private string status;
        private string checkedAt;

        #region Properties
        /// <summary>
        /// The status of the compliance check
        /// </summary>
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
        /// <summary>
        /// When compliance checks were last ran
        /// </summary>
        public string CheckedAt
        {
            get
            {
                return checkedAt;
            }

            set
            {
                checkedAt = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructor to instantiate a Compliance object, you should never have to use this as
        /// compliance is a read only field
        /// </summary>
        /// <param name="status"></param>
        /// <param name="active"></param>
        public Compliance(string status, string active)
        {
            this.status = status;
            this.checkedAt = active;
        }

        public Compliance()
        {

        }

        public static bool operator ==(Compliance a, Compliance b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Compliance a, Compliance b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks whether the fields in this Compliance are equivalent to the ones in the 
        /// object being compared
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>whether the two are equivalent</returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == this.GetType())
            {
                Compliance other = (Compliance)obj;
                if (other.status == this.status && other.checkedAt == this.checkedAt)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
