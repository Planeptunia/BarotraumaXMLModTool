using System.Xml;

namespace BXMT
{
    public class Parser
    {
        public static List<XmlElement>? GetItemsFromXML(string filepath)
        {
            List<XmlElement> items = new List<XmlElement>();

            XmlDocument xml = new XmlDocument();
            xml.Load(filepath);

            XmlElement? root = xml.DocumentElement;

            if (root != null)
            {
                foreach (XmlElement node in root)
                {
                    if (node.Name.ToLower() == "item")
                    {
                        items.Add(node);
                    }
                }
            }
            else
            {
                return null;
            }
            return items;
        }
    }
}
