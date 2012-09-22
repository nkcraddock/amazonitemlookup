using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NKCraddock.AmazonItemLookup;
using NKCraddock.AmazonItemLookup.Client;

namespace NKCraddock.AmazonItemLookupTests.Client
{
    [TestClass]
    public class ProductApiTest
    {
        AwsProductApiClient api;

        public ProductApiTest()
        {
            api = new AwsProductApiClient(GetConnectionInfo());
        }

        [TestMethod]
        public void CanLookupKnr()
        {
            const string ASIN = "0131103628";

            var item = api.LookupByAsin(ASIN);
            string imageUrl = item.GetImageUrl(AwsImageType.LargeImage);
        }

        private ProductApiConnectionInfo GetConnectionInfo()
        {
            return new ProductApiConnectionInfo
            {
                AWSAccessKey = "Sorry you'll have to ",
                AWSSecretKey = "put your own aws information",
                AWSAssociateTag = "in here if you want to run the tests."
            };
        }
    }
}