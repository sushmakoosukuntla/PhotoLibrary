using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    public static class PhotoManager
    {
        public static ObservableCollection<Photo> GetAllPhotos()
        {
            //Empty list of type photo will get created in the line below and the list name is photos.
            var photos = new ObservableCollection<Photo>();
            var allPhotos = GetPhotos();            
            foreach (var photo in allPhotos)
            {
                photos.Add(photo);
            }
            return photos;
            //The above foreach can write like below(shortcut)
            //allPhotos.ForEach(photo => photos.Add(photo));
        }

        public static ObservableCollection<Album> GetAllAlbums()
        {
            //Empty list of type photo will get created in the line below and the list name is photos.
            var albums = new ObservableCollection<Album>();
            var allAlbums = GetAlbums();
            foreach (var album in allAlbums)
            {
                albums.Add(album);
            }
            return albums;
            //The above foreach can write like below(shortcut)
            //allPhotos.ForEach(photo => photos.Add(photo));
        }


        public static void GetPhotosByCategory(ObservableCollection<Photo> photos, AlbumName category)
        {
            var allPhotos = GetPhotos();
            var filteredPhotos = allPhotos.Where(photo => photo.AlbumName == category).ToList();
            photos.Clear();
            filteredPhotos.ForEach(photo => photos.Add(photo));
        }


        /*We will be using below GetPhotos method for many other methods in this class, 
        that is the reason we are making it private and not using the type ObservableCollection*/
        /* and also, in order to keep our code organized we have created the below private method.
        * If in future, if we want to make any changes in photos list, if we make the changes here, 
        * everywhere will get updated. If we use observable collection in the below method, 
        * in future, if we want to make any changes in photos list the code becomes messy. */
        private static List<Photo> GetPhotos() 
        {
            var photos = new List<Photo>();
            photos.Add(new Photo("Animals1", AlbumName.Animals));
            photos.Add(new Photo("Animals2", AlbumName.Animals));

            photos.Add(new Photo("Baby1", AlbumName.Babies));
            photos.Add(new Photo("Baby2", AlbumName.Babies));

            photos.Add(new Photo("Flowers1", AlbumName.Flowers));
            photos.Add(new Photo("Flowers1", AlbumName.Flowers));

            photos.Add(new Photo("Fruits1", AlbumName.Fruits));
            photos.Add(new Photo("Fruits2", AlbumName.Fruits));

            photos.Add(new Photo("Nature", AlbumName.Nature));            

            return photos;
        }


        private static List<Album> GetAlbums()
        {
            var albums = new List<Album>();
            albums.Add(new Album { IconFile = $"Assets/Album Icons/Animals-Icon.png", AlbumType= AlbumName.Animals });
            albums.Add(new Album { IconFile = $"Assets/Album Icons/Babies-Icon.png", AlbumType = AlbumName.Babies });
            albums.Add(new Album { IconFile = $"Assets/Album Icons/Flowers-Icon.png", AlbumType = AlbumName.Flowers});
            albums.Add(new Album { IconFile = $"Assets/Album Icons/Fruits-Icon.png", AlbumType = AlbumName.Fruits });
            albums.Add(new Album { IconFile = $"Assets/Album Icons/Nature-Icon.png", AlbumType = AlbumName.Nature });

            return albums;
        }
    }
}
