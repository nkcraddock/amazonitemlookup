using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NKCraddock.AmazonItemLookup;
using NKCraddock.AmazonItemLookup.Client;
using NKCraddock.AmazonItemLookupTests.TestHelpers;

namespace NKCraddock.AmazonItemLookupTests.Client
{
    [TestClass]
    public class ProductApiTest
    {
        AwsProductApiClient api;

        public ProductApiTest()
        {
            api = new AwsProductApiClient(AwsTestHelper.GetConnectionInfo());
        }

        [TestMethod]
        public void CanLookupKnr()
        {
            const string ASIN = "0131103628";

            var item = api.LookupByAsin(ASIN);
            string imageUrl = item.GetImageUrl(AwsImageType.LargeImage);
        }
    }
}