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
    public sealed partial class CustomAlbum : Page
    {
        private ObservableCollection<Photo> photos;
        private IReadOnlyList<StorageFile> SelectedPhotosList;

        private static HashSet<Photo> PhotoSet = new HashSet<Photo>();
        private static string AlbumContent;
        private object CatrgorySet;

        public CustomAlbum()
        {
            this.InitializeComponent();
            if (PhotoSet.Count < 1)
            {
                photos = PhotoManager.GetAllPhotos();
            }
            else
            {
                photos = PhotoManager.GetAllPhotos();
                photos.Clear();
                foreach (var value in PhotoSet)
                {
                    CustomAlbumButton.Content = AlbumContent;
                    photos.Add(value);
                }
            }

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
                    photos.Clear();
                    PhotoSet.Clear();
                    foreach (var photo in pickedPhotos)
                    {
                        photos.Add(photo);
                        PhotoSet.Add(photo);
                    }

                }
                else if (e.Parameter.GetType() == typeof(string))
                {
                    var albumname = (string)e.Parameter;
                    CustomAlbumButton.Content = "Add Photos to " + albumname;
                    AlbumContent = (string)CustomAlbumButton.Content;
                }
            }
        }

        private void CustomAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            var custom = new List<Photo>();
            var CustomImage = AllPhotosGrid.SelectedItems;
            for (var i = 0; i < CustomImage.Count; i++)
            {
                custom.Add((Photo)CustomImage[i]);

            }
            Frame.Navigate(typeof(CustomAlbum), custom);




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
                CustomAlbumButton.IsEnabled = false;
                FullScreenButton.IsEnabled = false;
                CoverImageButton.IsEnabled = false;
            }
            else if (CustomAlbumButton.IsEnabled != true)
            {
                CustomAlbumButton.IsEnabled = true;
                CoverImageButton.IsEnabled = true;
                FullScreenButton.IsEnabled = true;

            }
           


        }


        private void FullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            var custom = new List<Photo>();
            var CustomImage = AllPhotosGrid.SelectedItems;
            for (var i = 0; i < CustomImage.Count; i++)
            {
                custom.Add((Photo)CustomImage[i]);

            }
            Frame.Navigate(typeof(SingleImage), custom);

        }

        private void CoverImageButton_Click(object sender, RoutedEventArgs e)
        {
            var custom = new List<Photo>();



            var CustomImage = AllPhotosGrid.SelectedItems;

            for (var i = 0; i < CustomImage.Count; i++)
            {
                custom.Add((Photo)CustomImage[i]);
                Frame.Navigate(typeof(CategoryPage), (Photo)CustomImage[i]);
            }

        }
    }
}


        

    

