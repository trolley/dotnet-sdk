using System;
namespace Trolley.Types.Supporting
{
	public class Meta
	{
        public int page;

        /**
         * How many pages are there in the current result set.
         * Note: This will depend on <c>pageSize</c> parameter given to the API.
         */
        public int pages;

        /**
         * How many records in total are present in the current result set.
         */
        public int records;

        public Meta()
		{
		}

        public Meta(int page, int pages, int records)
        {
            this.page = page;
            this.pages = pages;
            this.records = records;
        }
    }
}

