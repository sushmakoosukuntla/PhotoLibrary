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
    public sealed partial class AllPhotosPage : Page
    {
        private ObservableCollection<Photo> photos;
      
        public AllPhotosPage()
        {
            this.InitializeComponent();
            photos = PhotoManager.GetAllPhotos();
        }
        
        public ObservableCollection<Photo> GetPhotos()
        {
            return photos;
        }

        /*Below If we dont overide OnNavigatedTo method in this page(AllPhotosPage), There wont be any function to perform and 
         the page will display allPhotos without any filter. 
        So, actully we need filter in that page, so we are calling GetPhotosByCategory from photomanager*/
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                var albumType = (AlbumName)e.Parameter;
                PhotoManager.GetPhotosByCategory(GetPhotos(), albumType);
            }
            // else it ddisplays all the photos without any filter
            
        }

        private void AllPhotosGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickItem = (Photo)e.ClickedItem;
            /*All photos grid is different and selectedItems list is different(I have kept selection mode as multiple)
            that is the reason selectedItems will be list*/
            //When we select the items, selectedItems will come to the different list
            /*When the selectedItems count is equal to 1 && the click items is equal to selectedItems[0], 
            it means the selected items list size is equal to 1, then the favorite button will get disabled.*/
            if (AllPhotosGrid.SelectedItems.Count == 1 && AllPhotosGrid.SelectedItems[0].Equals(clickItem))
            {
                FavoriteButton.IsEnabled = false;
            }
            else if (FavoriteButton.IsEnabled != true)
            {
                FavoriteButton.IsEnabled = true;
            }


        }

        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            var favs = new List<Photo>();
            var selectedFavorites = AllPhotosGrid.SelectedItems;
            for (var i = 0; i < selectedFavorites.Count; i++)
            {
                favs.Add((Photo)selectedFavorites[i]);
            }
            Frame.Navigate(typeof(FavoritesPage), favs );
        }

      
    }
}
