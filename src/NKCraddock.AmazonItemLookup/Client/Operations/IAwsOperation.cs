using System.Collections.Generic;

namespace NKCraddock.AmazonItemLookup.Client.Operations
{
    public interface IAwsOperation<T>
    {
        Dictionary<string, string> GetRequestArguments();
        T GetResultsFromXml(string xml);
    }
}