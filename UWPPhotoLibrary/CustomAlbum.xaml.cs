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
    public sealed partial class CustomAlbum : Page
    {
        private ObservableCollection<Photo> photos;
        public CustomAlbum()
        {
            this.InitializeComponent();
            photos = PhotoManager.GetAllPhotos();
        }

        public ObservableCollection<Photo> GetPhotos()
        {
            return photos;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                if (e.Parameter.GetType() == typeof(AlbumName))
                {
                    var albumType = (AlbumName)e.Parameter;
                    PhotoManager.GetPhotosByCategory(GetPhotos(), albumType);
                }

                else if (e.Parameter.GetType() == typeof(List<Photo>))
                {
                    var pickedPhotos = (List<Photo>)e.Parameter;
                    foreach (var photo in pickedPhotos)
                    {
                        photos.Add(photo);
                    }
                }
            }
        }

        private void CustomAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            var favs = new List<Photo>();
           // var selectedFavorites = AllPhotosGrid.SelectedItems;
            //for (var i = 0; i < selectedFavorites.Count; i++)
           // {
             //   favs.Add((Photo)selectedFavorites[i]);
           // }
            Frame.Navigate(typeof(CustomAlbum), favs);
        }
    }
}
