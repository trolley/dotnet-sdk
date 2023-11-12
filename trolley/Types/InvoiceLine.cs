using Newtonsoft.Json;
using Trolley.Exceptions;
using Trolley.Converters;
using System.Collections.Generic;
using System;
using Trolley.Types.Supporting;

namespace Trolley.Types
{
    public class InvoiceLine : ITrolleyMappable
    {
        public bool IsMappable()
        {
            return true;
        }

        public string ToJson()
        {
            return "";
        }
    }
}
