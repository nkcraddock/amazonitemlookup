using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NKCraddock.AmazonItemLookup.Client
{
    internal class AwsItemLookupResponse
    {
        const string NAMESPACE_ALIAS = "aws";
        string xml;
        XmlDocument doc;
        XmlNamespaceManager namespaceManager;

        public AwsItemLookupResponse(string responseXml)
        {
            xml = responseXml;

            doc = new XmlDocument();
            doc.LoadXml(responseXml);

            namespaceManager = new XmlNamespaceManager(doc.NameTable);
            namespaceManager.AddNamespace(NAMESPACE_ALIAS, doc.DocumentElement.NamespaceURI);
        }

        public string SelectNodeValue(string path)
        {
            XmlNode node = SelectNode(path);
            if (node == null)
                return null;
            return node.Value ?? node.InnerText;
        }

        public XmlNodeList SelectNodes(string path)
        {
            string xpath = BuildXPath(path);
            return doc.SelectNodes(xpath, namespaceManager);
        }

        public XmlNode SelectNode(string path)
        {
            string xpath = BuildXPath(path);
            return doc.SelectSingleNode(xpath, namespaceManager);
        }

        public AwsItem ToAwsItem()
        {
            var item = new AwsItem
            {
                ASIN = SelectNodeValue(NodePath.ASIN),
                DetailPageURL = SelectNodeValue(NodePath.DetailPageUrl),
                SalesRank = XmlHelper.GetInt(SelectNodeValue(NodePath.SalesRank)),
                ReviewIFrameUrl = SelectNodeValue(NodePath.ReviewIFrameUrl),
                Links = GetLinks(),
                ImageSets = GetImageSets(),
                ItemAttributes = GetItemAttributes(),
                Reviews = GetReviews(),
                SimilarProducts = GetSimilarProducts(),
                OfferPrice = XmlHelper.GetDollars(SelectNode("Offers/Offer/OfferListing/Price/Amount")),
                ListPrice = XmlHelper.GetDollars(SelectNode("ItemAttributes/ListPrice/Amount")),
                LowestOfferPrice = XmlHelper.GetDollars(SelectNode("OfferSummary/LowestNewPrice/Amount"))
            };

            return item;
        }

        private IDictionary<string, string> GetItemAttributes()
        {
            var attr = new Dictionary<string, string>();

            foreach (XmlNode node in SelectNode(NodePath.ItemAttributes).ChildNodes)
                attr[node.Name] = XmlHelper.GetValue(node);

            return attr;
        }

        private IList<AwsReview> GetReviews()
        {
            var reviews = new List<AwsReview>();
            foreach (XmlNode reviewNode in SelectNodes(NodePath.Reviews))
                reviews.Add(AwsReview.FromXmlNode(reviewNode));
            return reviews;
        }

        private IList<AwsSimilarProduct> GetSimilarProducts()
        {
            var similarProducts = new List<AwsSimilarProduct>();
            foreach (XmlNode node in SelectNodes(NodePath.SimilarProducts))
                similarProducts.Add(AwsSimilarProduct.FromXmlNode(node));
            return similarProducts;
        }

        private IList<AwsImageSet> GetImageSets()
        {
            var imageSets = new List<AwsImageSet>();
            foreach (XmlNode imageSetNode in SelectNodes(NodePath.ImageSets))
                imageSets.Add(AwsImageSet.FromXmlNode(imageSetNode));
            return imageSets;
        }

        private IList<AwsLink> GetLinks()
        {
            var links = new List<AwsLink>();
            foreach (XmlNode linkNode in SelectNodes(NodePath.ItemLinks))
                links.Add(AwsLink.FromXmlNode(linkNode));
            return links;
        }

        private string BuildXPath(string path)
        {
            const string DEFAULT_ROOT_ELEMENT = NodePath.ItemPath;
            path = DEFAULT_ROOT_ELEMENT + "/" + path;

            string[] elementNames = path.Split('/');
            var sb = new StringBuilder();
            foreach (string elementName in elementNames)
                sb.AppendFormat("/{0}:{1}", NAMESPACE_ALIAS, elementName);

            return sb.ToString();
        }
    }
}