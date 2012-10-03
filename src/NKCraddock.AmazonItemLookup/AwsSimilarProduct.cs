using System;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsSimilarProduct
    {
        public string ASIN { get; set; }
        public string Title { get; set; }

        internal static AwsSimilarProduct FromXmlNode(XmlNode node)
        {
            var product = new AwsSimilarProduct();
            foreach (XmlNode child in node.ChildNodes)
                if (child.Name.Equals("ASIN", StringComparison.CurrentCultureIgnoreCase))
                    product.ASIN = XmlHelper.GetValue(child);
                else if (child.Name.Equals("Title", StringComparison.CurrentCultureIgnoreCase))
                    product.Title = XmlHelper.GetValue(child);

            return product;
        }
    }
}