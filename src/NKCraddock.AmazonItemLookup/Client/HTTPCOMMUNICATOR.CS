using System.IO;
using System.Net;

namespace NKCraddock.AmazonItemLookup.Client
{
    public class HttpCommunicator : ICommunicator
    {
        public string GetResponseFromUrl(string url)
        {
            var request = WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
    }
}