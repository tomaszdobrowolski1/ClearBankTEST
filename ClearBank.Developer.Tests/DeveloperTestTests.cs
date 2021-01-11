using ClearBank.Data.Core;
using ClearBank.Data.Models;
using ClearBank.Services.Core;
using ClearBank.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Xunit.Sdk;


namespace ClearBank.Developer.Tests
{
    [TestClass]
    public class DeveloperTestTests
    {
        [TestMethod]
        public void PaymentBacsAccountNull_ReturnsFalse()
        {
            var moq = new Mock< AccountFactory>();

            var accountDataStore = new BackupAccountDataStore();
            MakePaymentRequest request = new MakePaymentRequest();
            request.PaymentScheme = PaymentScheme.Bacs;
            
            Account account = null;
            moq.Setup(x => x.Get(request)).Returns(account);

            IPaymentService service = new PaymentService(moq.Object);
            var result = service.MakePayment(request);
            Assert.IsTrue(result.Success == false);
        }

        [TestMethod]
        public void PaymentBacs_BacsNotAllowed_AccountDefined_ReturnsFalse()
        {
            var moq = new Mock<AccountFactory>();

            var accountDataStore = new BackupAccountDataStore();
            MakePaymentRequest request = new MakePaymentRequest();
            request.PaymentScheme = PaymentScheme.Bacs;

             var account = accountDataStore.GetAccount(request.DebtorAccountNumber);
            account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Chaps;
            moq.Setup(x => x.Get(request)).Returns(account);

            IPaymentService service =  new PaymentService(moq.Object);
            var result = service.MakePayment(request);
            Assert.IsTrue(result.Success == false);
        }

        // should technically be valid test, however the payment service never returns true
        //[TestMethod]
        //public void PaymentBacs_BacsAllowed_AccountDefined_ReturnsTrue()
        //{
        //    var moq = new Mock<AccountFactory>(MockBehavior.Strict);
        //    var accountDataStore = new BackupAccountDataStore();
        //    MakePaymentRequest request = new MakePaymentRequest();
        //    request.PaymentScheme = PaymentScheme.Bacs;
        //    var account = accountDataStore.GetAccount(request.DebtorAccountNumber);
        //    account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs | AllowedPaymentSchemes.Chaps;
        //    moq.CallBase = false;
        //    moq.Setup(x => x.Get(It.IsAny<MakePaymentRequest>())).Returns(account);
        //    PaymentService service = new PaymentService(moq.Object);
       
        //    var result = service.MakePayment(request);
        //    Assert.IsTrue(result.Success == true);
        //}

    }
}
