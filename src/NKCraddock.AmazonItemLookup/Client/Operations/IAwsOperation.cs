using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NKCraddock.AmazonItemLookup.Client.Operations
{
    public interface IAwsOperation<T>
    {
        Dictionary<string, string> GetRequestArguments();

        T GetResultsFromXml(string xml);
    }
}