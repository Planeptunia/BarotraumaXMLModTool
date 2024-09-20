using System.Diagnostics;
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
        /// Class representing all Barotrauma ContentTypes
        /// </summary>
        public class ContentTypes
        {
            /// <summary>
            /// Class representing Barotrauma Item ContentType
            /// </summary>
            /// <param name="identifier">Used to reference the item, required</param>
            /// <param name="nameIdentifier">Tag used to fetch item name from localization files</param>
            /// <param name="fallbackNameIdentifier">Tag used to fallback is nameIdentifier is not found in localization file</param>
            /// <param name="descriptionIdentifier">Tag used to fetch item description from localization files</param>
            /// <param name="name">Tag used as last fallback to show item name if others are not defined</param>
            /// <param name="aliases">String consisting of additional modifiers separated with commas</param>
            /// <param name="tags">String consisting of tags to group items separated with commas</param>
            /// <param name="category">Category for Item to show in proper category</param>
            /// <param name="allowAsExtraCargo">Can this item be enabled as extra cargo in server settings</param>
            /// <param name="interactDistance"></param>
            /// <param name="interactPriority"></param>
            /// <param name="interactThroughWalls"></param>
            /// <param name="hideConditionBar"></param>
            /// <param name="hideConditionInTooltip"></param>
            /// <param name="requireBodyInsideTrigger"></param>
            /// <param name="requireCursorInsideTrigger"></param>
            /// <param name="requireCampaignInteract"></param>
            /// <param name="focusOnSelected"></param>
            /// <param name="offsetOnSelected"></param>
            /// <param name="health">Item health value</param>
            /// <param name="allowSellWhenBroken"></param>
            /// <param name="indestructible"></param>
            /// <param name="damagedByExplosions"></param>
            /// <param name="explosionDamageMultiplier"></param>
            /// <param name="damagedByProjectiles"></param>
            /// <param name="damagedByMeleeWeapons"></param>
            /// <param name="damagedByRepairTools"></param>
            /// <param name="damagedByMonsters"></param>
            /// <param name="fireProof"></param>
            /// <param name="waterProof"></param>
            /// <param name="impactTolerance"></param>
            /// <param name="onDamagedThreshold"></param>
            /// <param name="sonarSize"></param>
            /// <param name="useInHealthInterface"></param>
            /// <param name="disableItemUsageWhenSelected"></param>
            /// <param name="cargoContainerIdentifier"></param>
            /// <param name="useContainedSpriteColor"></param>
            /// <param name="useContainedInventoryIconColor"></param>
            /// <param name="addedRepairSpeedMultiplier"></param>
            /// <param name="addedPickingSpeedMultiplier"></param>
            /// <param name="cannotRepairFail"></param>
            /// <param name="equipConfirmationText"></param>
            /// <param name="allowRotatingInEditor"></param>
            /// <param name="showContentsInTooltip"></param>
            /// <param name="canFlipX"></param>
            /// <param name="canFlipY"></param>
            /// <param name="isDangerous"></param>
            /// <param name="maxStackSize"></param>
            /// <param name="allowDroppingOnSwap"></param>
            /// <param name="resizeHorizontal"></param>
            /// <param name="resizeVertical"></param>
            /// <param name="description"></param>
            /// <param name="allowedUpgrades"></param>
            /// <param name="hideInMenus"></param>
            /// <param name="subcategory"></param>
            /// <param name="linkable"></param>
            /// <param name="spriteColor">String represent of RGBA color with values separated with commas</param>
            /// <param name="scale">Scale of this Item</param>
            public class Item(
                 string identifier,
                 string? nameIdentifier = null,
                 string? fallbackNameIdentifier = null,
                 string? descriptionIdentifier = null,
                 string? name = null,
                 string? aliases = null,
                 string? tags = null,
                 Item.Categories? category = null,
                 bool? allowAsExtraCargo = null,
                 float? interactDistance = null,
                 float? interactPriority = null,
                 bool? interactThroughWalls = null,
                 bool? hideConditionBar = null,
                 bool? hideConditionInTooltip = null,
                 bool? requireBodyInsideTrigger = null,
                 bool? requireCursorInsideTrigger = null,
                 bool? requireCampaignInteract = null,
                 bool? focusOnSelected = null,
                 float? offsetOnSelected = null,
                 float? health = null,
                 bool? allowSellWhenBroken = null,
                 bool? indestructible = null,
                 bool? damagedByExplosions = null,
                 float? explosionDamageMultiplier = null,
                 bool? damagedByProjectiles = null,
                 bool? damagedByMeleeWeapons = null,
                 bool? damagedByRepairTools = null,
                 bool? damagedByMonsters = null,
                 bool? fireProof = null,
                 bool? waterProof = null,
                 float? impactTolerance = null,
                 float? onDamagedThreshold = null,
                 float? sonarSize = null,
                 bool? useInHealthInterface = null,
                 bool? disableItemUsageWhenSelected = null,
                 string? cargoContainerIdentifier = null,
                 bool? useContainedSpriteColor = null,
                 bool? useContainedInventoryIconColor = null,
                 float? addedRepairSpeedMultiplier = null,
                 float? addedPickingSpeedMultiplier = null,
                 bool? cannotRepairFail = null,
                 string? equipConfirmationText = null,
                 bool? allowRotatingInEditor = null,
                 bool? showContentsInTooltip = null,
                 bool? canFlipX = null,
                 bool? canFlipY = null,
                 bool? isDangerous = null,
                 int? maxStackSize = null,
                 bool? allowDroppingOnSwap = null,
                 bool? resizeHorizontal = null,
                 bool? resizeVertical = null,
                 string? description = null,
                 string? allowedUpgrades = null,
                 bool? hideInMenus = null,
                 string? subcategory = null,
                 bool? linkable = null,
                 string? spriteColor = null,
                 float? scale = null)
            {
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

                // All of Item attributes
                public required string identifier = identifier;
                public string? nameIdentifier = nameIdentifier;
                public string? fallbackNameIdentifier = fallbackNameIdentifier;
                public string? descriptionIdentifier = descriptionIdentifier;

                public string? name = name;
                public string? aliases = aliases;
                public string? tags = tags;
                public Categories? category = category;

                public bool? allowAsExtraCargo = allowAsExtraCargo;
                public float? interactDistance = interactDistance;
                public float? interactPriority = interactPriority;
                public bool? interactThroughWalls = interactThroughWalls;

                public bool? hideConditionBar = hideConditionBar;
                public bool? hideConditionInTooltip = hideConditionInTooltip;
                public bool? requireBodyInsideTrigger = requireBodyInsideTrigger;
                public bool? requireCursorInsideTrigger = requireCursorInsideTrigger;

                public bool? requireCampaignInteract = requireCampaignInteract;
                public bool? focusOnSelected = focusOnSelected;
                public float? offsetOnSelected = offsetOnSelected;
                public float? health = health;

                public bool? allowSellWhenBroken = allowSellWhenBroken;
                public bool? indestructible = indestructible;
                public bool? damagedByExplosions = damagedByExplosions;
                public float? explosionDamageMultiplier = explosionDamageMultiplier;

                public bool? damagedByProjectiles = damagedByProjectiles;
                public bool? damagedByMeleeWeapons = damagedByMeleeWeapons;
                public bool? damagedByRepairTools = damagedByRepairTools;
                public bool? damagedByMonsters = damagedByMonsters;

                public bool? fireProof = fireProof;
                public bool? waterProof = waterProof;
                public float? impactTolerance = impactTolerance;
                public float? onDamagedThreshold = onDamagedThreshold;

                public float? sonarSize = sonarSize;
                public bool? useInHealthInterface = useInHealthInterface;
                public bool? disableItemUsageWhenSelected = disableItemUsageWhenSelected;
                public string? cargoContainerIdentifier = cargoContainerIdentifier;

                public bool? useContainedSpriteColor = useContainedSpriteColor;
                public bool? useContainedInventoryIconColor = useContainedInventoryIconColor;
                public float? addedRepairSpeedMultiplier = addedRepairSpeedMultiplier;
                public float? addedPickingSpeedMultiplier = addedPickingSpeedMultiplier;

                public bool? cannotRepairFail = cannotRepairFail;
                public string? equipConfirmationText = equipConfirmationText;
                public bool? allowRotatingInEditor = allowRotatingInEditor;
                public bool? showContentsInTooltip = showContentsInTooltip;

                public bool? canFlipX = canFlipX;
                public bool? canFlipY = canFlipY;
                public bool? isDangerous = isDangerous;
                public int? maxStackSize = maxStackSize;

                public bool? allowDroppingOnSwap = allowDroppingOnSwap;
                public bool? resizeHorizontal = resizeHorizontal;
                public bool? resizeVertical = resizeVertical;
                public string? description = description;

                public string? allowedUpgrades = allowedUpgrades;
                public bool? hideInMenus = hideInMenus;
                public string? subcategory = subcategory;
                public bool? linkable = linkable;

                public string? spriteColor = spriteColor;
                public float? scale = scale;

                public List<XmlElement>? children = null;

                /// <summary>
                /// Gets this Item represent
                /// </summary>
                /// <returns>XmlElement represent of the Item</returns>
                public XmlElement GetAsXml()
                {
                    XmlDocument xmlDoc = new();
                    XmlElement newItem = xmlDoc.CreateElement("Item");

                    foreach(var attr in this.GetType().GetProperties())
                    {
                        if (attr.GetValue(this, null) != null)
                        {
                            newItem.SetAttribute(attr.Name.ToLower(), value: attr.GetValue(this, null).ToString());
                        }
                    }

                    newItem.InnerText = "";

                    if (this.children != null)
                    {
                        foreach (var child in this.children)
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
                this.xmlContent = includedFile;

                this.pathToFile = includedFile.GetAttribute("file");

                if (Enum.TryParse(includedFile.Name, out this.fileType))
                {
                    switch (this.fileType)
                    {
                        case FileType.Item:
                            this.fileType = FileType.Item;
                            break;
                        case FileType.Other:
                            this.fileType = FileType.Other;
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

                this.xmlContent.InnerText = "";
            }
        }
    }
}
