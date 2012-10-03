using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NKCraddock.AmazonItemLookup.Client
{
    public class AwsXmlParser
    {
        const string NAMESPACE_ALIAS = "aws";
        XmlDocument doc;
        XmlNamespaceManager namespaceManager;

        public AwsXmlParser(string xml)
        {
            doc = new XmlDocument();
            doc.LoadXml(xml);

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

        private string BuildXPath(string path)
        {
            string[] elementNames = path.Split('/');
            var sb = new StringBuilder();
            foreach (string elementName in elementNames)
                sb.AppendFormat("/{0}:{1}", NAMESPACE_ALIAS, elementName);

            return sb.ToString();
        }
    }
}