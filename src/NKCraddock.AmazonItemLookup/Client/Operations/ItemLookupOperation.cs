using System.Collections.Generic;
using NKCraddock.AmazonItemLookup.Client.Responses;

namespace NKCraddock.AmazonItemLookup.Client.Operations
{
    public class ItemLookupOperation : IAwsOperation<AwsItem>
    {
        Dictionary<string, string> requestArgs;

        public ItemLookupOperation(string asin)
        {
            requestArgs = new Dictionary<string, string>
            {
                { "Operation", "ItemLookup" },
                { "ResponseGroup", "Large" },
                { "ItemId", asin }
            };
        }

        public Dictionary<string, string> GetRequestArguments()
        {
            return requestArgs;
        }

        public AwsItem GetResultsFromXml(string xml)
        {
            var itemLookupResponse = new ItemLookupResponse(xml);
            return itemLookupResponse.ToAwsItem();
        }
    }
}