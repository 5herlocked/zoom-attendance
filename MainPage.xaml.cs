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
using CsvHelper;
using System.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace zoom_attendance
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public StorageFolder folder = null;

        public async void parse()
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
                            var records = csv.GetRecords<Foo>();
                        }

                    }
                }
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        public class Foo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Date { get; set; }
        }
    }
}
