using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    public static class PhotoManager
    {
        private static List<Photo> getPhotos()
        {
            var photos = new List<Photo>();

            photos.Add(new Photo("Animals1", AlbumName.Animals));
            photos.Add(new Photo("Animals2", AlbumName.Animals));

            photos.Add(new Photo("Baby1", AlbumName.Babies));
            photos.Add(new Photo("Baby2", AlbumName.Babies));

            photos.Add(new Photo("Flowers1", AlbumName.Flowers));
            photos.Add(new Photo("Flowers2", AlbumName.Flowers));

            photos.Add(new Photo("Fruits1", AlbumName.Fruits));
            photos.Add(new Photo("Fruits2", AlbumName.Fruits));

            photos.Add(new Photo("Nature", AlbumName.Nature));

            return photos;


        }

    }
}
