using System.Diagnostics;
using System.Xml;

namespace BXMT.Utilities
{
    public class ProjectFuncs
    {
        /// <summary>
        /// Gets a folder from user, checks if folder is empty and then creates a new filelist.xml in specified folder
        /// </summary>
        /// <param name="name">Name for this contentpackage</param>
        /// <param name="isCorePackage">Can this contentpackage be a corepackage</param>
        /// <returns>ContentPackage representing newly created filelist.xml</returns>
        public async static Task<CustomTypes.ContentPackage?> CreateNewProject(string name, bool isCorePackage)
        {
            string gameVersion = InfoGrabber.GetGameVersion();

            var result = await FileWorker.OpenUserFolder();

            if (result != null)
            {
                string[] filesInTarget = Directory.GetFiles($"{result.Folder.Path}");
                if (filesInTarget.Length > 0 || filesInTarget != null)
                {
                    Debug.WriteLine("Target Folder is not empty, abort");
                    return null;
                }
                FileStream filelistStream = File.Open($"{result.Folder.Path}\\filelist.xml", FileMode.Create);

                XmlDocument filelistXml = new();

                CustomTypes.ContentPackage newPackage  = new(name, gameVersion, isCorePackage:isCorePackage);

                filelistXml.AppendChild(newPackage.xmlContent);

                filelistXml.Save(filelistStream);

                filelistStream.Close();

                return newPackage;
            }
            return null;
        }

        /// <summary>
        /// Gets a folder from user, checks if folder is not empty and has filelist.xml then opens filelist.xml to read
        /// </summary>
        /// <returns>ContentPackage representing opened filelist.xml</returns>
        public async static Task<CustomTypes.ContentPackage?> OpenProject()
        {
            var result = await FileWorker.OpenUserFolder();
            string pathToFilelist = "";

            if (result != null)
            {
                string[] filesInTarget = Directory.GetFiles($"{result.Folder.Path}");
                if (filesInTarget.Length > 0 || filesInTarget != null)
                {
                    foreach (string file in filesInTarget)
                    {
                        if (file.EndsWith("filelist.xml"))
                        {
                            pathToFilelist = file;
                            break;
                        }
                    }
                }
                else 
                {
                    return null;
                }

                XmlDocument filelistXml = new();

                FileStream filelistStream = File.OpenRead(pathToFilelist);

                filelistXml.Load(filelistStream);

                CustomTypes.ContentPackage loadedPackage = new(filelistXml.DocumentElement);

                return loadedPackage;
            }
            else
            {
                return null;
            }
        }
    }
}
