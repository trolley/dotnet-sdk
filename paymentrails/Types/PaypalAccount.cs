using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public struct PaypalAccount
    {
        private string email;

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

        public PaypalAccount(string email)
        {
            this.email = email;
        }
    }
}
