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
        //private static ObservableCollection<Album> staticAlbums = PhotoManager.GetAllAlbums();
        private static HashSet<Album> hashAlbums = new HashSet<Album>();

        public static HashSet<Album> GetActiveAlbums()
        {
            return hashAlbums;
        }
        
        public AlbumsPage()
        {
            this.InitializeComponent();            
            //Albums = PhotoManager.GetAllAlbums();
            Albums = new ObservableCollection<Album>();
            foreach (var a in hashAlbums)
            {
                Albums.Add(a);                
            }
        }
        static AlbumsPage()
        {
            foreach (var a in PhotoManager.GetAllAlbums())
            {                
                hashAlbums.Add(a);
            }
        }

        public static HashSet<Album> getAllAbums() {
            return hashAlbums;
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
            Frame.Navigate(typeof(AlbumContentPage), album);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Frame.Navigate(typeof(AlbumsPage),AssetFolderName.Text);
            if (e != null && e.Parameter != null )
            {
                var AlbumName = (string)e.Parameter;
                if (!String.IsNullOrEmpty(AlbumName))
                {
                    var a = new Album($"Assets/Album Icons/Folders-Windows-Folder-icon.png", AlbumName);
                    //$"Assets/Album Icons/Animals-Icon.png"
                    hashAlbums.Add(a);
                    //staticAlbums.Add(a);
                }
                Albums.Clear();
                foreach(var a in hashAlbums)
                {
                    Albums.Add(a);
                }
            }
        }

        
    }

}
 