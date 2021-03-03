using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
     
    }
}
