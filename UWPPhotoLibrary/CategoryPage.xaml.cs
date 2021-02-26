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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryPage : Page
    {        
        private List<Category> CategoryList;
        public CategoryPage()
        {
            this.InitializeComponent();
            
            //After initializing the app, we can see category grid.
            
            CategoryList = new List<Category>();
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Albums-Icon.png", PhotoCategory = PhotoCategory.Albums });
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/AllPhotos-Icon.png", PhotoCategory = PhotoCategory.AllPhotos });
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Favorites-Icon.png", PhotoCategory = PhotoCategory.Favotites });

        }      
        private void CategoryGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var categoryItem = (Category)e.ClickedItem;
            if(categoryItem.PhotoCategory == PhotoCategory.Albums)
            {
                Frame.Navigate(typeof(AlbumsPage));                
            } 
            else if(categoryItem.PhotoCategory == PhotoCategory.AllPhotos)
            {
                Frame.Navigate(typeof(AllPhotosPage));
            }
            else if(categoryItem.PhotoCategory == PhotoCategory.Favotites)
            {
                
                Frame.Navigate(typeof(FavoritesPage));
            }
            
                       
            //LibraryName.Text = categoryItem.PhotoCategory.ToString();
            
        }
    }
}
        
