using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace zoom_attendance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Attendance> attendees = new List<Attendance>();
        public StorageFolder folder = null;
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
            }
            else
            {
                Folder_Text.Text = "Invalid Folder";
            }
        }

        private void Analyse_Logs_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
