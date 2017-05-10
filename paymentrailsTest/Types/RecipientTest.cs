using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using paymentrails.Types;
using paymentrails.Exceptions;

namespace paymentrailsTest
{
    [TestClass]
    public class RecipientTest
    {
        [TestMethod]
        public void TestRecipientBusiness()
        {
            Recipient r = new Recipient(null, "business", null, "email", "name", null,null, null, null, null, null, null, null, null, null);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestRecipientIndividual()
        {
            Recipient r = new Recipient(null, "individual", null, "email", null, "firstName", "lastName", null, null, null, null, null, null, null, null);
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Email must be provided.")]
        public void TestRecipientInvalidEmail()
        {
            Recipient r = new Recipient(null,"type",null,null,null,"firstName","lastName",null,null,null,null,null,null,null,null);

        }

        [TestMethod]
        public void TestRecipientInvalidId()
        {
            Recipient r = new Recipient("R-fhfh", "type", null, null, null, "firstName", "lastName", null, null, null, null, null, null, null, null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Type must be provided.")]
        public void TestRecipientInvalidType()
        {
            Recipient r = new Recipient(null, null, null, "email", null, "firstName", "lastName", null, null, null, null, null, null, null, null);

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Name must be provided if type is business.")]
        public void TestRecipientInvalidName()
        {
            Recipient r = new Recipient(null, "business", null, "email", null, null, null, null, null, null, null, null, null, null, null);

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "First name must be provided if type is individual.")]
        public void TestRecipientInvalilFirstName()
        {
            Recipient r = new Recipient(null, "individual", null, null, "email",null, null, "lastname", null, null, null, null, null, null, null);

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidFieldException), "Last name must be provided if type is individual.")]
        public void TestRecipientInvalidLastName()
        {
            Recipient r = new Recipient(null, "individual", null, null, "email", "firstName", null, null, null, null, null, null, null, null, null);

        }
    }
}
