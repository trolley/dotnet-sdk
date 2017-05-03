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
            PaymentRails_Configuration.setApiBase("http://api.local.dev:3000");
            PaymentRails_Configuration.apiKey = "pk_test_91XPUY8D8GAGA";

            var val = PaymentRails_Balances.get("");
            Console.WriteLine(val);
            Console.Read();
            //recipient();
            //payoutMethods();
            //    payment();
            //     batches();
            //balances();

        }

        static void recipient()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_Recipient.get("R-91XPMEHZ44RMP");
            //String response = PaymentRails_Recipient.delete("R-91XPM8233T710");
            //String response = PaymentRails_Recipient.query();

            //String body =  @"{ ""type"": ""individual"", ""firstName"": ""Barry"", ""lastName"": ""Allen"", ""email"": ""theflash@justiceleague.com""}";
            // String response = PaymentRails_Recipient.post(body);

            //String body = @"{""firstName"": ""Bart""}";
            // String response = PaymentRails_Recipient.patch("R-91XPU407CRNGR", body);

            Console.WriteLine(response);
            Console.ReadLine();
        }

        static void payoutMethods()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            String response = PaymentRails_PayoutMethods.get("R-91XPET3C8WBJJ");
            //String body = @"{""primary"": {""method"":""bank"", ""currency"": ""CAD""}, ""accounts"":{""bank"":{""country"":""CA"", ""accountNum"": ""6022847"", ""institution"": ""123"", ""branchNum"": ""47261"", ""currency"": ""CAD"", ""name"":""TD""}}}";

            //String response = PaymentRails_PayoutMethods.post("R-91XPU407CRNGR", body);


            //String body = @"{""primary"": {""method"":""paypal"", ""currency"": ""CAD""}, ""accounts"":{""paypal"": {""address"": ""testpaypal@example.com""}}}";
            //String response = PaymentRails_PayoutMethods.patch("R-91XPU407CRNGR",body);

            Console.WriteLine(response);
            Console.ReadLine();
        }

        static void payment()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            PaymentRails_Payment.batchId = "";
            String response = PaymentRails_Payment.get("P-91XPMEHZ44RMP");
        }

        static void batches()
        {

        }
        static void balances()
        {
            PaymentRails_Configuration.apiKey = "pk_live_91XNJFBD19ZQ6";
            //String response = PaymentRails_Balances.get();
            //String response = PaymentRails_Balances.get("paymentrails");
            //String response = PaymentRails_Balances.get("paypal");
            //Console.WriteLine(response);
            //Console.ReadLine();
        }
    }
}