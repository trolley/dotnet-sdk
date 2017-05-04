using System;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Web;
namespace paymentrails
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            PaymentRails_Configuration.setApiBase("http://api.railz.io");
            PaymentRails_Configuration.apiKey = "pk_test_5E9CB6C692DE5EE62712760B7F7D9FDF";

            //var val = PaymentRails_Recipient.get("R-91XQ00KM0CPMR");

            var recipients = PaymentRails_Recipient.get();
            Console.WriteLine(recipients);
            
            //val.Bank = new Types.BankAccount("CAD", "abc bank", "123412", "1231", "CAD", "CA", "abc bank");
            
            //Console.WriteLine(val);
            Console.Read();

        }       
    }
}