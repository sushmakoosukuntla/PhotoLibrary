using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPPhotoLibrary.Model
{
    public enum PhotoCategory
    {
        AllPhotos,
        Albums,
        Favotites
    }
    public class Category
    {
        //  internal AlbumName AlbumType;

        public string PhotoCategory { get; set; }
        public string IconFile { get; set; }
        public string CoverImage { get; set; }
        public BitmapImage bmImage { get; set; }





        /*public Category()
        {
            bmImage = new BitmapImage();
            //bmImage.UriSource = new Uri((Window.Current.Content as Frame)?.BaseUri, ImageFile);
            bmImage.UriSource = new Uri(CoverImage);
            bmImage.AutoPlay = true;


        }
        private async void setImage(StorageFile file)
        {
            using (var stream = await file.OpenReadAsync())
            {
                await bmImage.SetSourceAsync(stream);
            }

        }*/
    }
}


 

    

