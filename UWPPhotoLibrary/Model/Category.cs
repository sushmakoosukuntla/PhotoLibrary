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
    class CategoryList
    {
        public PhotoCategory Category { get;}        
        public string IconFile { get; set; }
     
    }
}
