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
        private static ObservableCollection<Photo> staticPhotos = PhotoManager.GetAllPhotos();
        public ObservableCollection<Photo> photos;
        private HashSet<Album> hashAlbums = new HashSet<Album>();


        public AllPhotosPage()
        {
            this.InitializeComponent();
            photos = new ObservableCollection<Photo>();
            foreach (var p in staticPhotos)
            {
                photos.Add(p);
            }
            hashAlbums = AlbumsPage.getAllAbums();
        }
        
        public ObservableCollection<Photo> GetPhotos()
        {
            return photos;
        }

        /*Below If we dont overide OnNavigatedTo method in this page(AllPhotosPage), There wont be any function 
            to perform and the page will display allPhotos without any filter. 
            So, actully we need filter in that page, so we are calling GetPhotosByCategory from photomanager*/
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                /*if (e.Parameter.GetType() == typeof(AssetFolderName))
                {
                    var albumType = (AssetFolderName)e.Parameter;
                    PhotoManager.GetPhotosByCategory(GetPhotos(), albumType);
                }*/

                if (e.Parameter.GetType() == typeof(List<Photo>))
                {
                    var pickedPhotos = (List<Photo>)e.Parameter;
                    foreach (var photo in pickedPhotos)
                    {
                        staticPhotos.Add(photo);
                        photos.Add(photo);
                    }
                }
            }
            // else it displays all the photos without any filter
            
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
                ComboAlbums.IsEnabled = false;


            }
            else if (FavoriteButton.IsEnabled != true)
            {
                FavoriteButton.IsEnabled = true;
                ComboAlbums.IsEnabled = true;
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

        
        /*private void FullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedPhotosList = new List<Photo>();
            var SelectedPhotos = AllPhotosGrid.SelectedItems;
            for (var i = 0; i < SelectedPhotos.Count; i++)
            {
                SelectedPhotosList.Add((Photo)SelectedPhotos[i]);
            }
            Frame.Navigate(typeof(SingleImage), SelectedPhotosList);
        }*/

        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            int startingPositionPhoto = 0;
            //var doubleTapped = new Photo();
            var selectedPhoto = (Photo)AllPhotosGrid.SelectedItems[0];
            if (photos.Contains(selectedPhoto))
            {
                 startingPositionPhoto = photos.IndexOf(selectedPhoto);
            }
            var Ps = new PhotoSelection();
            Ps.SelectedPhotoPosition = startingPositionPhoto;
            Ps.Photos = photos;
            Frame.Navigate(typeof(SingleImage), Ps);
        }

     

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e != null && e.AddedItems != null)
            {
                var album = (Album)ComboAlbums.SelectedItem;               
                var albumPhotos = new List<Photo>();
                var selectedPhotos = AllPhotosGrid.SelectedItems;
                for (var i = 0; i < selectedPhotos.Count; i++)
                {
                    albumPhotos.Add((Photo)selectedPhotos[i]);
                }
                album.AlbumListPhotos.AddRange(albumPhotos);
                //album.AlbumListPhotos = albumPhotos;
                Frame.Navigate(typeof(AlbumContentPage), album);


            }

        }
    }
    
}
