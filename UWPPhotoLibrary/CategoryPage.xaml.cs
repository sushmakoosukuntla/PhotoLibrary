using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
        private IReadOnlyList<StorageFile> SelectedPhotosList;

        private static HashSet<Category> CatrgorySet = new HashSet<Category>();
        public CategoryPage()
        {
            this.InitializeComponent();

            //After initializing the app, we can see category grid.

            CategoryList = new List<Category>();
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Albums-Icon.png", PhotoCategory = "Albums" });
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/AllPhotos-Icon.png", PhotoCategory = "AllPhotos" });
            CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Favorites-Icon.png", PhotoCategory = "Favotites" });

            foreach (var value in CatrgorySet)
            {

                CategoryList.Add(value);
                
            }
        }
        private void CategoryGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var categoryItem = (Category)e.ClickedItem;
            if (categoryItem.PhotoCategory == "Albums")
            {
                Frame.Navigate(typeof(AlbumsPage));
            }
            else if (categoryItem.PhotoCategory == "AllPhotos")
            {
                Frame.Navigate(typeof(AllPhotosPage));
            }
            else if (categoryItem.PhotoCategory == "Favotites")
            {

                Frame.Navigate(typeof(FavoritesPage));
            }
            else
            {

               Frame.Navigate(typeof(CustomAlbum), categoryItem.PhotoCategory);
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                if (e.Parameter.GetType() == typeof(String))
                {
                    var AlbumName = (String)e.Parameter;

                    CategoryList.Clear();
                    CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Albums-Icon.png", PhotoCategory = "Albums" });
                    CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/AllPhotos-Icon.png", PhotoCategory = "AllPhotos" });
                    CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Favorites-Icon.png", PhotoCategory = "Favotites" });

                    CatrgorySet.Add(new Category { IconFile = $"Assets/Category Icons/Albums-Icon.png", PhotoCategory = AlbumName });

                    foreach (var value in CatrgorySet)
                    {

                        CategoryList.Add(value);
                    }
                }
                if (e.Parameter.GetType() == typeof(Photo))
                {
                   var Coverimage = (Photo)e.Parameter;
                    CategoryList.Clear();
                    CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Albums-Icon.png", PhotoCategory = "Albums" });
                    CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/AllPhotos-Icon.png", PhotoCategory = "AllPhotos" });
                    CategoryList.Add(new Category { IconFile = $"Assets/Category Icons/Favorites-Icon.png", PhotoCategory = "Favotites" });


                    foreach (var value in CatrgorySet)
                    {
                        value.IconFile = Coverimage.ImageFile;
                        CategoryList.Add(value);
                    }
                   
                }
            }
        }
    }
}

