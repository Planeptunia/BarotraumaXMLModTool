using CommunityToolkit.Maui.Storage;
using System.Diagnostics;

namespace BXMT.Utilities
{
    public class FileWorker
    {
        /// <summary>
        /// Opens a file explorer for user to pick a specific file
        /// </summary>
        /// <param name="options">PickOptions to specify options for FilePicker</param>
        /// <returns>FileResult if file was selected successfully or null if file wasn't selected successfully</returns>
        public static async Task<FileResult?> OpenUserFile(PickOptions options)
        {
            try
            {
                var file = await FilePicker.Default.PickAsync(options);
                if (file != null)
                {
                    return file;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Opens a file explorer for user to pick a specific folder
        /// </summary>
        /// <returns>FolderPickerResult if folder was selected successfully or null if folder wasn't selected successfully</returns>
        public async static Task<FolderPickerResult?> OpenUserFolder()
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;

            FolderPickerResult result = await FolderPicker.PickAsync(token);

            if (result.IsSuccessful)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
