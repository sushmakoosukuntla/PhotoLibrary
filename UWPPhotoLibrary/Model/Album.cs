using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPPhotoLibrary.Model
{
    public class Album
    {
        //Below is the property(In album there are list of photos)
        public  AssetFolderName AlbumType  {get; set;}   
        public string AlbumName { get; set; }
        public string IconFile { get; set; }
        public List<Photo> AlbumListPhotos { get; set; }
        public BitmapImage bmImage { get; set; }

        //Below is the constructor
        public Album()
        {
            AlbumListPhotos = new List<Photo>();
        }
        public Album(String iconFile, string AlbumName):this()
        {
            IconFile =  $"ms-appx:///{iconFile}";
            bmImage = new BitmapImage();
            //bmImage.UriSource = new Uri((Window.Current.Content as Frame)?.BaseUri, ImageFile);
            bmImage.UriSource = new Uri(IconFile);
            bmImage.AutoPlay = true;            
            this.AlbumName = AlbumName;
        }

        public override bool Equals(object obj)
        {
            var value = (Album)obj;
            if (value.AlbumName.Equals(AlbumName))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return AlbumName.GetHashCode();
        }

        //Function to set cover photo
        public  void SetCoverPhotoForAlbum(Photo p)
        {
           bmImage = p.bmImage;
        }


    }
}
