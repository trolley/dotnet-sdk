using System;
namespace Trolley.Types.Supporting
{
	public class Amount
	{
        public string value;
        public string currency;

        public Amount(string value, string currency, int page, int pages, int records)
        {
            this.value = value;
            this.currency = currency;
        }
    }
}

