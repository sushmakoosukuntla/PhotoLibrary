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
        //public AllPhotosPage(AlbumName albumType)
        //{
         //   PhotoManager.GetPhotosByCategory(GetPhotos(), albumType);
        //}

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

    }
}
