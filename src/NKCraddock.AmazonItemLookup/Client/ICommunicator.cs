namespace NKCraddock.AmazonItemLookup.Client
{
    public interface ICommunicator
    {
        string GetResponseFromUrl(string url);
    }
}