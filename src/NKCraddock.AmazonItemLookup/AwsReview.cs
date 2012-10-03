using System;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsReview
    {
        public string Source { get; set; }
        public string Content { get; set; }

        internal static AwsReview FromXmlNode(XmlNode node)
        {
            var review = new AwsReview();
            foreach (XmlNode child in node.ChildNodes)
                if (child.Name.Equals("Source", StringComparison.CurrentCultureIgnoreCase))
                    review.Source = XmlHelper.GetValue(child);
                else if (child.Name.Equals("Content", StringComparison.CurrentCultureIgnoreCase))
                    review.Content = XmlHelper.GetValue(child);

            return review;
        }
    }
}