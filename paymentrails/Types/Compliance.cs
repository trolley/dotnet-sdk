using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public struct Compliance
    {
        private string status;
        private string active;

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

        public string Active
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

        public Compliance(string status, string active)
        {
            this.status = status;
            this.active = active;
        }
    }
}
