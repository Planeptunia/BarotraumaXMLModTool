using System.Diagnostics;
using System.Reflection;
using System.Xml;

namespace BXMT.Utilities
{
    public class CustomTypes
    {
        /// <summary>
        /// Enum consisting of all Barotrauma included FileTypes
        /// </summary>
        public enum FileType
        {
            Other,
            Item
        }

        /// <summary>
        /// Helper class for containing classes containing optional attributes for ContentTypes
        /// </summary>
        public class OptionalTypeAttributes
        {
            public class ItemAttributes
            {
                public string? NameIdentifier { get; set; } = null;
                public string? FallbackNameIdentifier { get; set; } = null;
                public string? DescriptionIdentifier { get; set; } = null;
                public string? Name { get; set; } = null;
                public List<string>? Aliases { get; set; } = null;
                public List<string>? Tags { get; set; } = null;
                public ItemAttributes.Categories? Category { get; set; } = null;
                public bool? AllowAsExtraCargo { get; set; } = null;
                public float? InteractDistance { get; set; } = null;
                public float? InteractPriority { get; set; } = null;
                public bool? InteractThroughWalls { get; set; } = null;
                public bool? HideConditionBar { get; set; } = null;
                public bool? HideConditionInTooltip { get; set; } = null;
                public bool? RequireBodyInsideTrigger { get; set; } = null;
                public bool? RequireCursorInsideTrigger { get; set; } = null;
                public bool? RequireCampaignInteract { get; set; } = null;
                public bool? FocusOnSelected { get; set; } = null;
                public float? OffsetOnSelected { get; set; } = null;
                public float? Health { get; set; } = null;
                public bool? AllowSellWhenBroken { get; set; } = null;
                public bool? Indestructible { get; set; } = null;
                public bool? DamagedByExplosions { get; set; } = null;
                public float? ExplosionDamageMultiplier { get; set; } = null;
                public bool? DamagedByProjectiles { get; set; } = null;
                public bool? DamagedByMeleeWeapons { get; set; } = null;
                public bool? DamagedByRepairTools { get; set; } = null;
                public bool? DamagedByMonsters { get; set; } = null;
                public bool? FireProof { get; set; } = null;
                public bool? WaterProof { get; set; } = null;
                public float? ImpactTolerance { get; set; } = null;
                public float? OnDamagedThreshold { get; set; } = null;
                public float? SonarSize { get; set; } = null;
                public bool? UseInHealthInterface { get; set; } = null;
                public bool? DisableItemUsageWhenSelected { get; set; } = null;
                public string? CargoContainerIdentifier { get; set; } = null;
                public bool? UseContainedSpriteColor { get; set; } = null;
                public bool? UseContainedInventoryIconColor { get; set; } = null;
                public float? AddedRepairSpeedMultiplier { get; set; } = null;
                public float? AddedPickingSpeedMultiplier { get; set; } = null;
                public bool? CannotRepairFail { get; set; } = null;
                public string? EquipConfirmationText { get; set; } = null;
                public bool? AllowRotatingInEditor { get; set; } = null;
                public bool? ShowContentsInTooltip { get; set; } = null;
                public bool? CanFlipX { get; set; } = null;
                public bool? CanFlipY { get; set; } = null;
                public bool? IsDangerous { get; set; } = null;
                public int? MaxStackSize { get; set; } = null;
                public bool? AllowDroppingOnSwap { get; set; } = null;
                public bool? ResizeHorizontal { get; set; } = null;
                public bool? ResizeVertical { get; set; } = null;
                public string? Description { get; set; } = null;
                public string? AllowedUpgrades { get; set; } = null;
                public bool? HideInMenus { get; set; } = null;
                public string? Subcategory { get; set; } = null;
                public bool? Linkable { get; set; } = null;
                public string? SpriteColor { get; set; } = null;
                public float? Scale { get; set; } = null;

                public enum Categories
                {
                    Decorative,
                    Machine,
                    Medical,
                    Weapon,
                    Diving,
                    Equipment,
                    Fuel,
                    Electrical,
                    Material,
                    Alien,
                    Wrecked,
                    Misc
                }
            }
        }

        /// <summary>
        /// Class representing all Barotrauma ContentTypes
        /// </summary>
        public class ContentTypes
        {
            public class Item
            {

                public required string Identifier { get; set; }

                public OptionalTypeAttributes.ItemAttributes? Attributes { get; }
                public XmlNodeList? Children { get; set; } = null;

                // Construct new Item from identifier and optional ItemAttributes
                public Item(string identifier, OptionalTypeAttributes.ItemAttributes? attributes = null)
                {
                    Identifier = identifier;
                    Attributes = attributes;
                }

                // Construct new Item from XmlElement
                public Item(XmlElement itemElement)
                {
                    Identifier = itemElement.GetAttribute("identifier");
                    Children = itemElement.ChildNodes;
                    Attributes = new();

                    // Iterating through all attributes in xml element
                    foreach (XmlAttribute attr in itemElement.Attributes)
                    {
                        // Iterating through all properties in ItemAttributes helper class
                        foreach (PropertyInfo property in Attributes.GetType().GetProperties())
                        {
                            // Check if name of xml attribute is equals to property in ItemAttributes
                            if (attr.Name.ToLower() == property.Name.ToLower())
                            {
                                // Check if value needs to be made into a list
                                if (attr.Name.ToLower() == "aliases" || attr.Name.ToLower() == "tags")
                                {
                                    List<string> value = new(attr.Value.Split(","));
                                    property.SetValue(Attributes, value);
                                }
                                // Set value with conversion to proper type
                                else
                                {
                                    property.SetValue(Attributes, Convert.ChangeType(attr.Value, conversionType: property.PropertyType));
                                }
                            }
                        }
                    }

                }

                /// <summary>
                /// Gets this Item represent
                /// </summary>
                /// <returns>XmlElement represent of the Item</returns>
                public XmlElement GetAsXml()
                {
                    XmlDocument xmlDoc = new();
                    XmlElement newItem = xmlDoc.CreateElement("Item");

                    // Identifier
                    PropertyInfo identInfo = GetType().GetProperty(nameof(Identifier));
                    newItem.SetAttribute(identInfo.Name.ToLower(), value: identInfo.GetValue(this, null).ToString());


                    if (Attributes != null)
                    {
                        // Optional data attributes
                        foreach (var attr in Attributes.GetType().GetProperties())
                        {
                            if (attr.GetValue(Attributes, null) != null)
                            {
                                newItem.SetAttribute(attr.Name.ToLower(), value: attr.GetValue(Attributes, null).ToString());
                            }
                        }
                    }

                    newItem.InnerText = "";

                    if (this.Children != null)
                    {
                        foreach (XmlNode child in Children)
                        {
                            newItem.AppendChild(child);
                        }
                    }

                    return newItem;
                }
            }
        }

        /// <summary>
        /// Class representing included in filelist.xml file
        /// </summary>
        public class ContentFile
        {
            public FileType fileType;
            public string pathToFile;
            public XmlElement xmlContent;

            public ContentFile(XmlElement includedFile)
            {
                xmlContent = includedFile;

                pathToFile = includedFile.GetAttribute("file");

                if (Enum.TryParse(includedFile.Name, out this.fileType))
                {
                    switch (this.fileType)
                    {
                        case FileType.Item:
                            fileType = FileType.Item;
                            break;
                        case FileType.Other:
                            fileType = FileType.Other;
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
                name = contentPackage.GetAttribute("name");
                isCorePackage = Convert.ToBoolean(contentPackage.GetAttribute("corepackage"));
                gameVersion = contentPackage.GetAttribute("gameversion");
                packageVersion = contentPackage.GetAttribute("modversion");

                xmlContent = contentPackage;

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
                xmlContent = tempDoc.CreateElement("contentpackage");

                xmlContent.SetAttribute("name", name);
                xmlContent.SetAttribute("gameversion", gameVersion);
                xmlContent.SetAttribute("modversion", packageVersion);
                xmlContent.SetAttribute("corepackage", isCorePackage.ToString());

                xmlContent.InnerText = "";
            }
        }
    }
}
