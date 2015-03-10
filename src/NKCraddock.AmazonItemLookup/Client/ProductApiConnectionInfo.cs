namespace NKCraddock.AmazonItemLookup.Client
{
    public class ProductApiConnectionInfo
    {
        public ProductApiConnectionInfo()
        {
            AWSServerUri = "webservices.amazon.com";
        }

        public string AWSAccessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string AWSAssociateTag { get; set; }
        public string AWSServerUri { get; set; }
    }
}