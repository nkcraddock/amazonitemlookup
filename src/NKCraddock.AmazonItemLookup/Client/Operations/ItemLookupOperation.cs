using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var itemLookupResponse = new AwsItemLookupResponse(xml);
            return itemLookupResponse.ToAwsItem();
        }
    }
}