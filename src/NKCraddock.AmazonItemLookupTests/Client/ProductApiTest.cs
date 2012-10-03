using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NKCraddock.AmazonItemLookup;
using NKCraddock.AmazonItemLookup.Client;
using NKCraddock.AmazonItemLookup.Client.Operations;
using NKCraddock.AmazonItemLookup.Client.Responses;
using NKCraddock.AmazonItemLookupTests.TestHelpers;

namespace NKCraddock.AmazonItemLookupTests.Client
{
    [TestClass]
    public class ProductApiTest
    {
        AwsProductApiClient api;
        Mock<ICommunicator> communicatorMock;
        const string ASIN = "0131103628";

        [TestInitialize]
        public void Initialize()
        {
            communicatorMock = new Mock<ICommunicator>();
            api = new AwsProductApiClient(new AwsTestConnectionInfo());

            //api = new AwsProductApiClient(new AwsTestConnectionInfo(), communicatorMock.Object);
        }

        [TestMethod]
        public void ItemLookup_WithLargeResponse_RetrievesAFewPropertiesIWillSelectHaphazardly()
        {
            const string ISBN = "0131103628";
            const double LIST_PRICE = 67;
            const string LARGE_IMAGE_URL = "http://ecx.images-amazon.com/images/I/41G0l2eBPNL.jpg";

            WithItemLookupResponseLarge();
            var item = api.ItemLookupByAsin(ASIN);

            Assert.IsNotNull(item);
            Assert.AreEqual<string>(ASIN, item.ASIN);
            Assert.AreEqual<string>(ISBN, item.ItemAttributes["ISBN"]);
            Assert.AreEqual<double>(LIST_PRICE, item.ListPrice.Value);
            Assert.AreEqual<string>(LARGE_IMAGE_URL, item.PrimaryImageSet[AwsImageType.LargeImage].URL);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            CartItem[] items = { new CartItem { Asin = ASIN } };

            var cart = api.Get<CartCreateResponse>(new CartCreateOperation(items));
        }

        private void WithItemLookupResponseLarge()
        {
            string responseText = AwsTestHelper.GetItemLookupResponseLarge();
            communicatorMock.Setup(x => x.GetResponseFromUrl(It.IsAny<string>())).Returns(responseText);
        }
    }
}