using System;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsLink
    {
        public string Description { get; set; }
        public string URL { get; set; }

        internal static AwsLink FromXmlNode(XmlNode linkNode)
        {
            var link = new AwsLink();
            foreach (XmlNode node in linkNode.ChildNodes)
                if (node.Name.Equals("description", StringComparison.CurrentCultureIgnoreCase))
                    link.Description = node.Value ?? node.InnerText;
                else if (node.Name.Equals("url", StringComparison.CurrentCultureIgnoreCase))
                    link.URL = node.Value ?? node.InnerText;
            return link;
        }
    }
}