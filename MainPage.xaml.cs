using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;

using CsvHelper;

namespace zoom_attendance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public StorageFolder folder = null;
        public List<Attendance> attendees = new List<Attendance>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            string possibleFolder = Folder_Text.Text;
            if (!string.IsNullOrEmpty(possibleFolder))
            {
                folder = await StorageFolder.GetFolderFromPathAsync(possibleFolder);
            }
            else
            {
                var folderPicker = new FolderPicker
                {
                    SuggestedStartLocation = PickerLocationId.Desktop
                };

                folder = await folderPicker.PickSingleFolderAsync();
            }

            if (folder != null)
            {
                Windows.Storage.AccessCache.StorageApplicationPermissions.
                    FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                Folder_Text.Text = folder.Name;
                Analyse_Button.IsEnabled = true;
            }
            else
            {
                Analyse_Button.IsEnabled = false;
                Folder_Text.Text = "Invalid Folder";
            }
        }

        private async void Analyse_Logs_Click(object sender, RoutedEventArgs e)
        {
            if (folder == null) return;

            List<StorageFile> fileStream = (List<StorageFile>)await folder.GetItemsAsync();

            foreach (var file in fileStream)
            {
                if (file.FileType.Equals("csv"))
                {
                    using (var reader = await file.OpenReadAsync())
                    {
                        using (var csv = new CsvReader((TextReader)reader, CultureInfo.InvariantCulture))
                        {
                            var records = csv.GetRecords<Attendance>();
                            // Once records are aquired
                        }
                    }
                }
            }
        }
    }
}
