using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    public class Album
    {
        //Below is the property(In album there are list of photos)
        public  AlbumName AlbumType  {get; set;}   
        public string AlbumName { get; set; }
        public string IconFile { get; set; }
        public List<Photo> AlbumListPhotos { get; set; }
        
        //Below is the constructor
        public Album()
        {
            AlbumListPhotos = new List<Photo>();
        }
        public Album(String iconFile, string AlbumName):this()
        {
            IconFile = iconFile;
            this.AlbumName = AlbumName;
        }

        public Album(String iconFile, AlbumName albumName):this()
        {
            IconFile = iconFile;
            this.AlbumName = albumName.ToString();
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


    }
}
