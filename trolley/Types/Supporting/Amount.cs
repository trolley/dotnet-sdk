using System;
namespace Trolley.Types.Supporting
{
	public class Amount
	{
        public string value;
        public string currency;

        public Amount(string value, string currency)
        {
            this.value = value;
            this.currency = currency;
        }
    }
}

