using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using System.Collections.Generic;
using paymentrails;
using System.Net.Http;
using System.Text;

namespace paymentrailsTest.JsonHelper
{
    [TestClass]
    public class RecipientHelperTest
    {
        [TestMethod]
        public void TestJsonToRecipient()
        {

            Compliance compliance = new Compliance("pending", null);
            Address address = new Address(null,null,null,null,null,null,null);
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, null, address);
 
            String response = @"{""ok"":true,""recipient"":{""id"":""R-91XQ4VKD39C3P"",""referenceId"":""tess@example.com"",""email"":""tess@example.com"",""name"":""John Smith"",""lastName"":""Smith"",""firstName"":""John"",""type"":""individual"",""status"":""incomplete"",""language"":""en"",""complianceStatus"":""pending"",""dob"":null,""payoutMethod"":null,""updatedAt"":""2017-05-09T19:11:37.647Z"",""createdAt"":""2017-05-09T19:11:37.647Z"",""gravatarUrl"":""https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg"",""compliance"":{""status"":""pending"",""checkedAt"":null},""payout"":{""method"":null},""address"":{""street1"":null,""street2"":null,""city"":null,""postalCode"":null,""country"":null,""region"":null,""phone"":null}}}";
            Recipient newRecipient = paymentrails.JsonHelpers.RecipientHelper.JsonToRecipient(response);

            Assert.AreEqual(recipient, newRecipient);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void TestJsonToRecipientInvalidJson()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address(null, null, null, null, null, null, null);
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, null, address);

            String response = "";
            Recipient newRecipient = paymentrails.JsonHelpers.RecipientHelper.JsonToRecipient(response);

            Assert.AreEqual(recipient, newRecipient);
        }

        [TestMethod]
        public void TestJsonToRecipientList()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address(null, null, null, null, null, null, null);
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, null, address);

            String response = @"{""ok"":true,""recipients"":[{""id"":""R-91XQ4VKD39C3P"",""referenceId"":""tess@example.com"",""email"":""tess@example.com"",""name"":""John Smith"",""lastName"":""Smith"",""firstName"":""John"",""type"":""individual"",""status"":""incomplete"",""language"":""en"",""complianceStatus"":""pending"",""dob"":null,""payoutMethod"":null,""updatedAt"":""2017-05-09T19:11:37.647Z"",""createdAt"":""2017-05-09T19:11:37.647Z"",""gravatarUrl"":""https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg"",""compliance"":{""status"":""pending"",""checkedAt"":null},""payout"":{""method"":null},""address"":{""street1"":null,""street2"":null,""city"":null,""postalCode"":null,""country"":null,""region"":null,""phone"":null}}]}";
            List<Recipient> newRecipient = paymentrails.JsonHelpers.RecipientHelper.JsonToRecipientList(response);

            Assert.AreEqual(recipient, newRecipient[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "JSON must be provided.")]
        public void TestJsonToRecipientListInvalidJson()
        {
            Compliance compliance = new Compliance("pending", null);
            Address address = new Address(null, null, null, null, null, null, null);
            Recipient recipient = new Recipient("R-91XQ4VKD39C3P", "individual", "tess@example.com", "tess@example.com", "John Smith", "John", "Smith", "incomplete", null, "en", null, "https://s3.amazonaws.com/static.api.paymentrails.com/icon_user.svg", compliance, null, address);

            String response = @"";
            List<Recipient> newRecipient = paymentrails.JsonHelpers.RecipientHelper.JsonToRecipientList(response);

            Assert.AreEqual(recipient, newRecipient[0]);
        }

    }
}
