using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Photo> photos;
        private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();

            photos = PhotoManager.GetAllPhotos();
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem(PhotoCategory.AllPhotos, "All Photos"));
            MenuItems.Add(new MenuItem(PhotoCategory.Albums, "Albums"));
            MenuItems.Add(new MenuItem(PhotoCategory.Favotites, "Favorites"));

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            //MySplitView is the name given for Grid.Row="1" in Xaml in line 23  
            // If the pane is open it is true, we used ! so it becomes false and the pane gets closed
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
