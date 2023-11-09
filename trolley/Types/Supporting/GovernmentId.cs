using System;
namespace Trolley.Types.Supporting
{
	public class GovernmentId
	{
        public string country;
        public string type;
        public string value;

        public GovernmentId()
		{
		}

        public GovernmentId(string country, string type, string value)
        {
            this.country = country;
            this.type = type;
            this.value = value;
        }
    }
}

