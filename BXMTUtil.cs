using CommunityToolkit.Maui.Storage;
using System.Xml;

namespace BXMT
{
    namespace BXMTUtil
    {
        public class Utilities
        {
            /// <summary>
            /// When called asks user for a folder to create project in, then creates it and returns
            /// </summary>
            /// <returns>XmlDocument of project's filelist.xml</returns>
            public async static Task<XmlDocument?> CreateNewProject()
            {
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;

                var result = await FolderPicker.PickAsync(token);

                string folderPath;

                if (result.IsSuccessful)
                {
                    folderPath = result.Folder.Path;
                }
                else
                {
                    // TODO:
                    // Show error message if folder wasn't picked successfully
                    return null;
                }

                string projectName = GetProjectName();

                string gameVersion = GetGameVersion();

                FileStream XMLStream = File.Open($"{folderPath}\\filelist.xml", FileMode.Create);

                CreateNewFilelist(projectName, gameVersion, false, XMLStream);

                XmlDocument filelist = new XmlDocument();
                filelist.Load(XMLStream);

                XMLStream.Close();

                return filelist;
            }

            /// <summary>
            /// Gets user inputted name for a project
            /// </summary>
            /// <returns>User inputted name for created project</returns>
            internal static string GetProjectName()
            {
                // Placeholder code for getting name for a project from user's input
                return "BXMTProject";
            }

            /// <summary>
            /// Gets current Barotrauma version from game executable
            /// </summary>
            /// <returns>String representation of game executable version</returns>
            internal static string GetGameVersion()
            {
                // Placeholder code for getting Barotrauma version based on its executable
                return "1.5.9.2";
            }

            /// <summary>
            /// Creates new filelist for contentpackage from given params and writes it to XMLStream
            /// </summary>
            ///
            /// <param name="packageName">
            /// Name for contentpackage shown in Mod Library
            /// </param>
            /// <param name="gameVersion">
            /// Version of the game this contentpackage is created for
            /// </param>
            /// <param name="isCorePackage">
            /// Can this contentpackage be used as core package
            /// </param>
            /// <param name="XMLStream">
            /// FileStream to write XML data to
            /// </param>
            internal static void CreateNewFilelist(string packageName, string gameVersion, bool isCorePackage, FileStream XMLStream)
            {
                if (!string.IsNullOrWhiteSpace(packageName) && XMLStream != null)
                {
                    XmlDocument filelist = new XmlDocument();
                    XmlElement root = filelist.CreateElement("contentpackage");

                    root.SetAttribute("name", packageName);
                    root.SetAttribute("gameversion", gameVersion);
                    root.SetAttribute("corepackage", isCorePackage.ToString());
                    root.SetAttribute("modversion", "1.0.0.0");

                    filelist.AppendChild(root);

                    filelist.Save(XMLStream);

                    XMLStream.Flush();
                }
                else
                {
                    return;
                }
            } 
        }
    }
}
