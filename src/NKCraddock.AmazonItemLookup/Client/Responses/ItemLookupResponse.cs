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
                ASIN = parser.SelectNodeValue(NodePath.ItemLookupResponse.ASIN),
                DetailPageURL = parser.SelectNodeValue(NodePath.ItemLookupResponse.DetailPageUrl),
                SalesRank = XmlHelper.GetInt(parser.SelectNodeValue(NodePath.ItemLookupResponse.SalesRank)),
                ReviewIFrameUrl = parser.SelectNodeValue(NodePath.ItemLookupResponse.ReviewIFrameUrl),
                Links = GetLinks(),
                ImageSets = GetImageSets(),
                ItemAttributes = GetItemAttributes(),
                Reviews = GetReviews(),
                SimilarProducts = GetSimilarProducts(),
                OfferPrice = XmlHelper.GetDollars(parser.SelectNode(NodePath.ItemLookupResponse.OfferPrice)),
                ListPrice = XmlHelper.GetDollars(parser.SelectNode(NodePath.ItemLookupResponse.ListPrice)),
                LowestOfferPrice = XmlHelper.GetDollars(parser.SelectNode(NodePath.ItemLookupResponse.LowestOfferPrice))
            };

            return item;
        }

        private IDictionary<string, string> GetItemAttributes()
        {
            var attr = new Dictionary<string, string>();

            foreach (XmlNode node in parser.SelectNode(NodePath.ItemLookupResponse.ItemAttributes).ChildNodes)
                attr[node.Name] = XmlHelper.GetValue(node);

            return attr;
        }

        private IList<AwsReview> GetReviews()
        {
            var reviews = new List<AwsReview>();
            foreach (XmlNode reviewNode in parser.SelectNodes(NodePath.ItemLookupResponse.Reviews))
                reviews.Add(AwsReview.FromXmlNode(reviewNode));
            return reviews;
        }

        private IList<AwsSimilarProduct> GetSimilarProducts()
        {
            var similarProducts = new List<AwsSimilarProduct>();
            foreach (XmlNode node in parser.SelectNodes(NodePath.ItemLookupResponse.SimilarProducts))
                similarProducts.Add(AwsSimilarProduct.FromXmlNode(node));
            return similarProducts;
        }

        private IList<AwsImageSet> GetImageSets()
        {
            var imageSets = new List<AwsImageSet>();
            foreach (XmlNode imageSetNode in parser.SelectNodes(NodePath.ItemLookupResponse.ImageSets))
                imageSets.Add(AwsImageSet.FromXmlNode(imageSetNode));
            return imageSets;
        }

        private IList<AwsLink> GetLinks()
        {
            var links = new List<AwsLink>();
            foreach (XmlNode linkNode in parser.SelectNodes(NodePath.ItemLookupResponse.ItemLinks))
                links.Add(AwsLink.FromXmlNode(linkNode));
            return links;
        }
    }
}