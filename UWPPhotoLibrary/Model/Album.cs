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
        
        //Below is the constructor
        public Album()
        {

        }
        public Album(String iconFile, string AlbumName)
        {
            IconFile = iconFile;
            this.AlbumName = AlbumName;
        }

        public Album(String iconFile, AlbumName albumName)
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
