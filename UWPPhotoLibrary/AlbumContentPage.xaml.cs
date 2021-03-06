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
    public sealed partial class AlbumContentPage : Page
    {
        private ObservableCollection<Photo> AlbumPhotos;
        private Album currentAlbum;

        
        
        public AlbumContentPage()
        {
            this.InitializeComponent();
            AlbumPhotos = new ObservableCollection<Photo>();
            
        }
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                var album = (Album)e.Parameter;
                AlbumNameTextComponent.Text = album.AlbumName;
                foreach (var a in album.AlbumListPhotos)
                {
                    AlbumPhotos.Add(a);
                }
                currentAlbum = album;

            }
        }

        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            int startingPositionPhoto = 0;
            //var doubleTapped = new Photo();
            var selectedPhoto = (Photo)AlbumPhotosGrid.SelectedItem;
            //(Photo)AlbumContentPage.SelectedItems[0];
            if (AlbumPhotos.Contains(selectedPhoto))
            {
                startingPositionPhoto = AlbumPhotos.IndexOf(selectedPhoto);
            }
            var Ps = new PhotoSelection();
            Ps.SelectedPhotoPosition = startingPositionPhoto;
            Ps.Photos = AlbumPhotos;
            Frame.Navigate(typeof(SingleImage), Ps);
        }

        private void AlbumPhotosGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickItem = (Photo)e.ClickedItem;
            /*All photos grid is different and selectedItems list is different(I have kept selection mode as multiple)
            that is the reason selectedItems will be list*/
            //When we select the items, selectedItems will come to the different list
            /*When the selectedItems count is equal to 1 && the click items is equal to selectedItems[0], 
            it means the selected items list size is equal to 1, then the favorite button will get disabled.*/
            if (AlbumPhotosGrid.SelectedItems.Count == 1 && AlbumPhotosGrid.SelectedItems[0].Equals(clickItem))
            {
                SetCoverPhoto.IsEnabled = false;
               
            }
            else if (SetCoverPhoto.IsEnabled != true)
            {
                SetCoverPhoto.IsEnabled = true;
                
            }
        }

        private void SetCoverPhoto_Click(object sender, RoutedEventArgs e)
        { 
            
            var selectedCoverPhoto = (Photo)AlbumPhotosGrid.SelectedItem;
            currentAlbum.SetCoverPhotoForAlbum(selectedCoverPhoto);
            Frame.Navigate(typeof(AlbumsPage));
        }
    }
}