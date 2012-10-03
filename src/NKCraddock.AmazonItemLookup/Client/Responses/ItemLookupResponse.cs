using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace NKCraddock.AmazonItemLookup.Client.Responses
{
    internal class ItemLookupResponse
    {
        AwsXmlParser parser;
        string xml;

        public ItemLookupResponse(string responseXml)
        {
            xml = responseXml;
            parser = new AwsXmlParser(xml);
        }

        public AwsItem ToAwsItem()
        {
            var item = new AwsItem
            {
                ASIN = parser.SelectNodeValue(NodePath.ASIN),
                DetailPageURL = parser.SelectNodeValue(NodePath.DetailPageUrl),
                SalesRank = XmlHelper.GetInt(parser.SelectNodeValue(NodePath.SalesRank)),
                ReviewIFrameUrl = parser.SelectNodeValue(NodePath.ReviewIFrameUrl),
                Links = GetLinks(),
                ImageSets = GetImageSets(),
                ItemAttributes = GetItemAttributes(),
                Reviews = GetReviews(),
                SimilarProducts = GetSimilarProducts(),
                OfferPrice = XmlHelper.GetDollars(parser.SelectNode(NodePath.OfferPrice)),
                ListPrice = XmlHelper.GetDollars(parser.SelectNode(NodePath.ListPrice)),
                LowestOfferPrice = XmlHelper.GetDollars(parser.SelectNode(NodePath.LowestOfferPrice))
            };

            return item;
        }

        private IDictionary<string, string> GetItemAttributes()
        {
            var attr = new Dictionary<string, string>();

            foreach (XmlNode node in parser.SelectNode(NodePath.ItemAttributes).ChildNodes)
                attr[node.Name] = XmlHelper.GetValue(node);

            return attr;
        }

        private IList<AwsReview> GetReviews()
        {
            var reviews = new List<AwsReview>();
            foreach (XmlNode reviewNode in parser.SelectNodes(NodePath.Reviews))
                reviews.Add(AwsReview.FromXmlNode(reviewNode));
            return reviews;
        }

        private IList<AwsSimilarProduct> GetSimilarProducts()
        {
            var similarProducts = new List<AwsSimilarProduct>();
            foreach (XmlNode node in parser.SelectNodes(NodePath.SimilarProducts))
                similarProducts.Add(AwsSimilarProduct.FromXmlNode(node));
            return similarProducts;
        }

        private IList<AwsImageSet> GetImageSets()
        {
            var imageSets = new List<AwsImageSet>();
            foreach (XmlNode imageSetNode in parser.SelectNodes(NodePath.ImageSets))
                imageSets.Add(AwsImageSet.FromXmlNode(imageSetNode));
            return imageSets;
        }

        private IList<AwsLink> GetLinks()
        {
            var links = new List<AwsLink>();
            foreach (XmlNode linkNode in parser.SelectNodes(NodePath.ItemLinks))
                links.Add(AwsLink.FromXmlNode(linkNode));
            return links;
        }
    }
}