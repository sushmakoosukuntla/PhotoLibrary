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
    public sealed partial class AlbumsPage : Page
    {
        private ObservableCollection<Album> Albums;
        public AlbumsPage()
        {
            this.InitializeComponent();            
            Albums = PhotoManager.GetAllAlbums();
        }
        
        /*When the consumer clicks on the Album(Animals,babies,fruits,flowers,nature), the object will store in e,
         object in the sence the album properties(IconFile and Albumtype) so we are type casting the object by giving the type
        Album.*/

        private void AlbumsPage1_ItemClick(object sender, ItemClickEventArgs e)
            
        {
            var album = (Album)e.ClickedItem;
            /*here the Frame.Navigate will navigate to Allphotos page but it will not filter them according to the Albumname.
             So that is the reason we are giving the parameter album.AlbumType also*/
            /*In order to filter the photos, we are overiding the method OnNavigatedTo in AllPhotos.Xaml.cs page */
            Frame.Navigate(typeof(AllPhotosPage), album.AlbumType);

        }

    }

}
