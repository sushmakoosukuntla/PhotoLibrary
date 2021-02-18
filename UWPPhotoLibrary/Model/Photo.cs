using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    public enum AlbumName
    {
        Animals,
        Babies,
        Flowers,
        Fruits,
        Nature
    }
    public class Photo
    {
        public AlbumName Album { get; set; }
        public string ImageFile { get; set; }
        public DateTime DateCreated { get; }
        public string Name { get; set; }

        //Below is the constructor
        public Photo(AlbumName album)
        {
            ImageFile = $"/Assets/Audio/{Album}/{Name}.jpg";
            Album = album;

            /*I'm not defining the DateCreated, because we have to use 
            .Now property when ever we add the photo in to the album*/
        }
    }
}