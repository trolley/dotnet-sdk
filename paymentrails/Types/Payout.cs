using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public struct Payout
    {
        private double autoswitchLimit;
        private bool autoswitchActive;
        private double holdupLimit;
        private bool holdupActive;
        private string primaryMethod;
        private string primaryCurrency;
        private BankAccount bank;
        private PaypalAccount paypal;

        public double AutoswitchLimit
        {
            get
            {
                return autoswitchLimit;
            }

            set
            {
                autoswitchLimit = value;
            }
        }

        public bool AutoswitchActive
        {
            get
            {
                return autoswitchActive;
            }

            set
            {
                autoswitchActive = value;
            }
        }

        public double HoldupLimit
        {
            get
            {
                return holdupLimit;
            }

            set
            {
                holdupLimit = value;
            }
        }

        public bool HoldupActive
        {
            get
            {
                return holdupActive;
            }

            set
            {
                holdupActive = value;
            }
        }

        public string PrimaryMethod
        {
            get
            {
                return primaryMethod;
            }

            set
            {
                primaryMethod = value;
            }
        }

        public string PrimaryCurrency
        {
            get
            {
                return primaryCurrency;
            }

            set
            {
                primaryCurrency = value;
            }
        }

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

        public Payout(double autoswitchLimit, bool autoswitchActive, double holdupLimit, bool holdupActive, string primaryMethod, string primaryCurrency, BankAccount bank, PaypalAccount paypal)
        {
            this.autoswitchLimit = autoswitchLimit;
            this.autoswitchActive = autoswitchActive;
            this.holdupLimit = holdupLimit;
            this.holdupActive = holdupActive;
            this.primaryMethod = primaryMethod;
            this.primaryCurrency = primaryCurrency;
            this.bank = bank;
            this.paypal = paypal;
        }
    }
}
