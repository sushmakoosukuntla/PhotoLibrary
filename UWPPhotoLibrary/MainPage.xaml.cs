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
        private List<Category> CategoryList;
        
        public MainPage()
        {
            this.InitializeComponent();
            
            //After initializing the app, we can see category grid.
            CategoryList = new List<Category>();
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Albums-Icon.png", PhotoCategory = PhotoCategory.Albums});
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/AllPhotos-Icon.png", PhotoCategory = PhotoCategory.AllPhotos });
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Favorites-Icon.png", PhotoCategory = PhotoCategory.Favotites });

        }

       

        private void BackButton_Click(object sender, RoutedEventArgs e) //line 21 in xaml
        {
            
        }

        private void CategoryGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var categoryItem = (Category)e.ClickedItem;
            CategoryGrid.Visibility = Visibility.Collapsed;
            NewPage.Visibility = Visibility.Visible;
            NewPage.Navigate(typeof(AlbumsPage));            
            //this.Frame.Navigate(typeof(PhotoCategory), itemId);
            //Navigate(Type sourcePageType, object parameter);
            LibraryName.Text = categoryItem.PhotoCategory.ToString();
            /*Here category item is an enum(albums, allphotos, favorites) which has photocategory and iconfile 
            as properties*/
            //example Albums.photocategory(albums, allphotos, favorites) === PhotoCategory.Albums



            //var menuItem = (MenuItem)e.ClickedItem;
            //CategoryText is the name given for TextBlock in the remaining grid(like All Sounds) in Xaml in line 49
        }
    }
}
