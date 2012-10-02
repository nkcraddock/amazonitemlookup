using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NKCraddock.AmazonItemLookup;
using NKCraddock.AmazonItemLookup.Client;
using NKCraddock.AmazonItemLookupTests.TestHelpers;

namespace NKCraddock.AmazonItemLookupTests.Client
{
    [TestClass]
    public class ProductApiTest
    {
        AwsProductApiClient api;
        Mock<ICommunicator> communicatorMock;

        public ProductApiTest()
        {
            communicatorMock = new Mock<ICommunicator>();
            api = new AwsProductApiClient(new AwsTestConnectionInfo(), communicatorMock.Object);
        }

        [TestMethod]
        public void CanLookupKnr()
        {
            WithItemLookupRequestLarge();
            const string ASIN = "0131103628";

            var item = api.LookupByAsin(ASIN);
            string imageUrl = item.GetImageUrl(AwsImageType.LargeImage);
            Assert.IsNotNull(item);
            Assert.AreEqual<string>(ASIN, item.ASIN);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            WithItemLookupRequestLarge();
            string haha = AwsTestHelper.GetItemLookupResponseLarge();
        }

        private void WithItemLookupRequestLarge()
        {
            string responseText = AwsTestHelper.GetItemLookupResponseLarge();
            communicatorMock.Setup(x => x.GetResponseFromUrl(It.IsAny<string>())).Returns(responseText);
        }
    }
}