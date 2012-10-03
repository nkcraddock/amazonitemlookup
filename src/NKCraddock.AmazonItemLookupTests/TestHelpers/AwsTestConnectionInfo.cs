using NKCraddock.AmazonItemLookup.Client;

namespace NKCraddock.AmazonItemLookupTests.TestHelpers
{
    public class AwsTestConnectionInfo : ProductApiConnectionInfo
    {
        public AwsTestConnectionInfo()
        {
            AWSAccessKey = "FOR INTEGRATION TESTS";
            AWSSecretKey = "YOU GOTTA PUT REAL STUFF";
            AWSAssociateTag = "IN HERE AND DONT USE A FAKE ICommunicator";
        }
    }
}