using System;
using System.Collections.Generic;
using NKCraddock.AmazonItemLookup.Client.Operations;

namespace NKCraddock.AmazonItemLookup.Client
{
    public class AwsProductApiClient
    {
        ProductApiConnectionInfo connectionInfo;
        ICommunicator communicator;

        public AwsProductApiClient(ProductApiConnectionInfo connectionInfo) : this(connectionInfo, new HttpCommunicator()) { }

        public AwsProductApiClient(ProductApiConnectionInfo connectionInfo, ICommunicator communicator)
        {
            this.connectionInfo = connectionInfo;
            this.communicator = communicator;
        }

        public T Get<T>(IAwsOperation<T> operation)
        {
            var requestArgs = GetRequestArguments(operation.GetRequestArguments());
            string requestUrl = SignRequest(requestArgs);
            string responseXml = communicator.GetResponseFromUrl(requestUrl);
            return operation.GetResultsFromXml(responseXml);
        }

        public AwsItem ItemLookupByAsin(string asin)
        {
            var operation = new ItemLookupOperation(asin);
            return Get<AwsItem>(operation);
        }

        public AwsCart CreateCart(params CartItem[] items)
        {
            return Get<AwsCart>(new CartCreateOperation(items));
        }

        private Dictionary<string, string> GetRequestArguments(Dictionary<string, string> operationArguments)
        {
            var requestArgs = new Dictionary<string, string>();
            requestArgs["Service"] = "AWSECommerceService";
            requestArgs["Version"] = "2009-03-31";
            requestArgs["AssociateTag"] = connectionInfo.AWSAssociateTag;
            foreach (string key in operationArguments.Keys)
                requestArgs[key] = operationArguments[key];
            return requestArgs;
        }

        protected virtual string SignRequest(Dictionary<string, String> requestArgs)
        {
            const string AWS_DESTINATION = "ecs.amazonaws.com";
            var signer = new SignedRequestHelper(connectionInfo.AWSAccessKey, connectionInfo.AWSSecretKey, AWS_DESTINATION);
            return signer.Sign(requestArgs);
        }
    }
}