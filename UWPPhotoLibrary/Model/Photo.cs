using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI.Popups;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Controls;


namespace UWPPhotoLibrary.Model
{
    public enum AlbumName
    {
        Animals,
        Babies,
        Flowers,
        Fruits,
        Nature,              
    }
    public class Photo
    {
        public AlbumName AlbumName { get; set; }
        public string ImageFile { get; set; }
        public DateTime DateCreated { get; }
        public string Name { get; set; }

        public BitmapImage bmImage { get; set; }

        public int ID { get; set; }
        private static int lastImageID = 0;

        //Below is the constructor
        public Photo()
        {

        }
        public Photo(String name, AlbumName albumName)
        {

            Name = name;
            AlbumName = albumName;
            ImageFile = $"ms-appx:///Assets/Images/{AlbumName}/{Name}.jpg"; // file path 
            bmImage = new BitmapImage();
            //bmImage.UriSource = new Uri((Window.Current.Content as Frame)?.BaseUri, ImageFile);
            bmImage.UriSource = new Uri(ImageFile);
            bmImage.AutoPlay = true;

            //   MyMediaElement.Source = new Uri(BaseUri, sound.AudioFile);
            DateCreated = DateTime.Now;
        }
        public Photo(String name, Uri uri)
        {
            Name = name;
            ImageFile = uri.AbsoluteUri;
            bmImage = new BitmapImage();
            bmImage.UriSource = uri;
            bmImage.AutoPlay = true;
        }

        public Photo(String name, StorageFile file) {
            bmImage = new BitmapImage();
            setImage(file);

          
        }

        private async void setImage(StorageFile file) {
            using (var stream = await file.OpenReadAsync())
            {
                await bmImage.SetSourceAsync(stream);
            }
        }

       /* public override bool Equals(object obj)
        {
            var value = (Photo)obj;
            if (value.Name.Equals(Name))
            {
                return true;
            }
            return false;
        }

       /* public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /*public static async void AddImageAsync(Photo image)
        {
            var imageFile = image.SourceImageFile;
            var localFolder = ApplicationData.Current.LocalFolder;
            ImageProperties imageProperties = await imageFile.Properties.GetImagePropertiesAsync();
            try
            {
                try
                {
                    Windows.Storage.StorageFile existingFile = await localFolder.GetFileAsync(imageFile.Name);
                }
                catch (FileNotFoundException)
                {
                    await imageFile.CopyAsync(localFolder);
                }

                image.Name = imageFile.Name;
                image.ID = ++lastImageID;
                

            }
            catch (ArgumentException ex)
            {
                var messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
                return;
            }
        }*/


    }
}