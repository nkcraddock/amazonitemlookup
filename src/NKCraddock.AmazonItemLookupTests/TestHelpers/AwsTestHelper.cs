using System;
using System.IO;
using System.Reflection;
using NKCraddock.AmazonItemLookup.Client;

namespace NKCraddock.AmazonItemLookupTests.TestHelpers
{
    public static class AwsTestHelper
    {
        public static string GetItemLookupResponseLarge()
        {
            return GetTestData("ItemLookupResponse.Large.xml");
        }

        private static string GetTestData(string resourceFilename)
        {
            try
            {
                string manifestResourcePath = GetTestDataPath(resourceFilename);
                var haha = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestResourcePath))
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("You probably didn't set the content type of the file to 'Embedded Resource'", e);
            }
        }

        private static string GetTestDataPath(string name)
        {
            return string.Format("NKCraddock.AmazonItemLookupTests.TestData.{0}", name);
        }
    }
}