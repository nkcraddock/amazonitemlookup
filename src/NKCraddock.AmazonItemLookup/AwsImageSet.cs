using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsImageSet
    {
        public AwsImageSet()
        {
            Images = new List<AwsImage>();
        }

        public AwsImage this[AwsImageType type]
        {
            get
            {
                return Images.Where(x => x.Type == type).FirstOrDefault();
            }
        }

        public AwsImageSetCategory Category { get; set; }

        public IList<AwsImage> Images { get; set; }

        internal static AwsImageSet FromXmlNode(XmlNode node)
        {
            var imageSet = new AwsImageSet();

            AwsImageSetCategory category;
            if (Enum.TryParse<AwsImageSetCategory>(XmlHelper.GetAttributeValue(node, "Category"), out category))
                imageSet.Category = category;

            foreach (XmlNode imageNode in node.ChildNodes)
                imageSet.Images.Add(AwsImage.FromXmlNode(imageNode));

            return imageSet;
        }
    }
}