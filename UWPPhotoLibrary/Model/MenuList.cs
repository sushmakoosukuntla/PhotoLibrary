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
    class MenuItem
    {
        public PhotoCategory Category { get;}
        public string CategoryName { get;}

        //below is the constructor
        public MenuItem(PhotoCategory category, string categoryName)
        {
            Category = category;
            CategoryName = categoryName;
        }
    }
}
