using System;
using System.Collections.Generic;

namespace NKCraddock.AmazonItemLookup.Client
{
    public class AwsProductApiClient
    {
        const string AWS_SERVICE = "AWSECommerceService";
        const string AWS_VERSION = "2009-03-31";
        const string AWS_DESTINATION = "ecs.amazonaws.com";

        ProductApiConnectionInfo connectionInfo;
        ICommunicator communicator;

        public AwsProductApiClient(ProductApiConnectionInfo connectionInfo) : this(connectionInfo, new HttpCommunicator()) { }

        public AwsProductApiClient(ProductApiConnectionInfo connectionInfo, ICommunicator communicator)
        {
            this.connectionInfo = connectionInfo;
            this.communicator = communicator;
        }

        public AwsItem ItemLookupByAsin(string asin)
        {
            var requestArgs = GetRequestArgumentsForOperation(AwsProductApiOperation.ItemLookup);
            requestArgs["ItemId"] = asin;

            string requestUrl = SignRequest(requestArgs);

            string responseText = communicator.GetResponseFromUrl(requestUrl);

            var itemLookupResponse = new AwsItemLookupResponse(responseText);

            return itemLookupResponse.ToAwsItem();
        }

        private Dictionary<string, string> GetRequestArgumentsForOperation(AwsProductApiOperation operation)
        {
            var requestArgs = new Dictionary<string, String>();
            requestArgs["Service"] = AWS_SERVICE;
            requestArgs["Version"] = AWS_VERSION;
            requestArgs["Operation"] = operation.ToString();
            requestArgs["ResponseGroup"] = "Large";
            requestArgs["AssociateTag"] = connectionInfo.AWSAssociateTag;
            return requestArgs;
        }

        protected virtual string SignRequest(Dictionary<string, String> requestArgs)
        {
            var signer = new SignedRequestHelper(connectionInfo.AWSAccessKey, connectionInfo.AWSSecretKey, AWS_DESTINATION);
            return signer.Sign(requestArgs);
        }
    }
}