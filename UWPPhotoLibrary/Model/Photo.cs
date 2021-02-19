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
        public AlbumName AlbumName { get; set; }
        public string ImageFile { get; set; }
        public DateTime DateCreated { get; }
        public string Name { get; set; }

        //Below is the constructor
        public Photo(String name, AlbumName albumName)
        {
            Name = name;
            AlbumName = albumName;
            ImageFile = $"/Assets/Images/{AlbumName}/{Name}.jpg"; // file path 
            DateCreated = DateTime.Now;
        }

    }
}