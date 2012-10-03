using System;
using System.Xml;

namespace NKCraddock.AmazonItemLookup
{
    public class AwsImage
    {
        public AwsImageType Type { get; set; }
        public string URL { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }

        internal static AwsImage FromXmlNode(XmlNode node)
        {
            AwsImageType imageType;
            Enum.TryParse<AwsImageType>(node.Name, out imageType);

            string url = null;
            string height = null;
            string width = null;

            foreach (XmlNode child in node.ChildNodes)
                if (child.Name.Equals("URL", StringComparison.CurrentCultureIgnoreCase))
                    url = child.Value ?? child.InnerText;
                else if (child.Name.Equals("Height", StringComparison.CurrentCultureIgnoreCase))
                    height = child.Value ?? child.InnerText;
                else if (child.Name.Equals("Width", StringComparison.CurrentCultureIgnoreCase))
                    width = child.Value ?? child.InnerText;

            var image = new AwsImage
            {
                Type = imageType,
                URL = url,
                Height = XmlHelper.GetInt(height),
                Width = XmlHelper.GetInt(width)
            };

            return image;
        }
    }
}