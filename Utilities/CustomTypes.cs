using System.Diagnostics;
using System.Xml;

namespace BXMT.Utilities
{
    public class CustomTypes
    {
        /// <summary>
        /// Enum consisting of all Barotrauma ContentTypes
        /// </summary>
        public enum ContentType
        {
            Item = 1 << 0,
            Other = 1 << 1
        }

        /// <summary>
        /// Class representing included in filelist.xml file
        /// </summary>
        public class ContentFile
        {
            public ContentType contentType;
            public string pathToFile;
            public XmlElement xmlContent;

            public ContentFile(XmlElement includedFile)
            {
                this.xmlContent = includedFile;

                this.pathToFile = includedFile.GetAttribute("file");

                if (Enum.TryParse(includedFile.Name, out this.contentType))
                {
                    switch (this.contentType)
                    {
                        case ContentType.Item:
                            this.contentType = ContentType.Item;
                            break;
                        case ContentType.Other:
                            this.contentType = ContentType.Other;
                            break;
                        default:
                            Debug.WriteLine("Failed to assign content type");
                            break;
                    }
                }

                else
                {
                    Debug.WriteLine("ContentType is not in enum");
                }
            }
        }

        /// <summary>
        /// Class representing filelist.xml
        /// </summary>
        public class ContentPackage
        {
            public string name;
            public bool isCorePackage;
            public string gameVersion;
            public string packageVersion;
            public XmlElement xmlContent;

            // List containing all of the included files nodes
            public List<ContentFile> includedFiles;

            /// <summary>
            /// Constructor for opening existing filelist.xml
            /// </summary>
            /// <param name="contentPackage">XmlElement of contentpackage node</param>
            public ContentPackage(XmlElement contentPackage)
            {
                this.name = contentPackage.GetAttribute("name");
                this.isCorePackage = Convert.ToBoolean(contentPackage.GetAttribute("corepackage"));
                this.gameVersion = contentPackage.GetAttribute("gameversion");
                this.packageVersion = contentPackage.GetAttribute("modversion");

                this.xmlContent = contentPackage;

                foreach (XmlElement child in contentPackage.ChildNodes)
                {
                    includedFiles.Add(new ContentFile(child));
                }
            }

            /// <summary>
            /// Constructor for creating new filelist.xml
            /// </summary>
            /// <param name="name">Name for contentpackage</param>
            /// <param name="gameVersion">Version of Barotrauma this contentpackage is made for</param>
            /// <param name="packageVersion">Version of contentpackage, defaults to 1.0.0.0</param>
            /// <param name="isCorePackage">Can this package be used as corepackage, defaults to false</param>
            public ContentPackage(string name, string gameVersion, string packageVersion = "1.0.0.0", bool isCorePackage = false)
            {
                this.name = name;
                this.isCorePackage = isCorePackage;
                this.gameVersion = gameVersion;
                this.packageVersion = packageVersion;

                XmlDocument tempDoc = new();
                this.xmlContent = tempDoc.CreateElement("contentpackage");

                this.xmlContent.SetAttribute("name", name);
                this.xmlContent.SetAttribute("gameversion", gameVersion);
                this.xmlContent.SetAttribute("modversion", packageVersion);
                this.xmlContent.SetAttribute("corepackage", isCorePackage.ToString());
            }
        }
    }
}
