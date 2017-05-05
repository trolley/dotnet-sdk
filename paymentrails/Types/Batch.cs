using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paymentrails.Types
{
    public class Batch : IPaymentRailsMappable
    {
        private string id;
        private string status;
        private double amount;
        private int totalPayments;
        private string currency;
        private string description;
        private string sentAt;
        private string completedAt;
        private string createdAt;
        private string updatedAt;

        private List<Payment> payments;

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
