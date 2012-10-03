using System;
using System.Collections.Generic;
using System.Linq;
using NKCraddock.AmazonItemLookup.Client.Operations;

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

        public T Get<T>(IAwsOperation<T> operation)
        {
            var requestArgs = GetRequestArguments(operation.GetRequestArguments());

            string requestUrl = SignRequest(requestArgs);

            string responseText = communicator.GetResponseFromUrl(requestUrl);

            return operation.GetResultsFromXml(responseText);
        }

        public AwsItem ItemLookupByAsin(string asin)
        {
            var operation = new ItemLookupOperation(asin);
            return Get<AwsItem>(operation);
        }

        private Dictionary<string, string> GetRequestArguments(Dictionary<string, string> operationArguments)
        {
            var requestArgs = new Dictionary<string, string>();
            requestArgs["Service"] = AWS_SERVICE;
            requestArgs["Version"] = AWS_VERSION;
            requestArgs["AssociateTag"] = connectionInfo.AWSAssociateTag;
            foreach (string key in operationArguments.Keys)
                requestArgs[key] = operationArguments[key];
            return requestArgs;
        }

        //private Dictionary<string, string> GetRequestArgumentsForOperation(AwsProductApiOperation operation)
        //{
        //    var requestArgs = new Dictionary<string, string>();
        //    requestArgs["Service"] = AWS_SERVICE;
        //    requestArgs["Version"] = AWS_VERSION;
        //    requestArgs["Operation"] = operation.ToString();
        //    requestArgs["ResponseGroup"] = "Large";
        //    requestArgs["AssociateTag"] = connectionInfo.AWSAssociateTag;
        //    return requestArgs;
        //}

        protected virtual string SignRequest(Dictionary<string, String> requestArgs)
        {
            var signer = new SignedRequestHelper(connectionInfo.AWSAccessKey, connectionInfo.AWSSecretKey, AWS_DESTINATION);
            return signer.Sign(requestArgs);
        }
    }
}