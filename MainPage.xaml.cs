using System.Diagnostics;

namespace BXMT
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public async void OnGetFilepathClicked(object sender, EventArgs e)
        {
            PickOptions pickOptions = new();

            // Set a specific file type to be able to open with these settings
            FilePickerFileType customType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<String>>
                {
                    { DevicePlatform.WinUI, new[] { ".xml" } }
                });
            pickOptions.FileTypes = customType;

            var file = await OpenFile(pickOptions);

            if (file != null)
            {
                FilepathLabel.Text = file.FullPath;
                List<System.Xml.XmlElement>? items = BXMT.Parser.GetItemsFromXML(file.FullPath);
                ItemStack.Children.Clear();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        string id = item.GetAttribute("identifier");
                        ItemStack.Add(new Label() { Text = id });
                        Debug.Print($"Got item with id = {id}");
                    }
                }
            }
        }

        // Gets a PickOptions and returns FileResult from FilePicker
        private async Task<FileResult?> OpenFile(PickOptions options)
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
    }
}
