using NKCraddock.AmazonItemLookup.Client;

namespace NKCraddock.AmazonItemLookupTests.TestHelpers
{
    public static class AwsTestHelper
    {
        public static ProductApiConnectionInfo GetConnectionInfo()
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