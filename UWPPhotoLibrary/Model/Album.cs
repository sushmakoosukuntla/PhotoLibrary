using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    class Album
    {
        //Below is the property(In album there are list of photos)
        public List<Photo> photos = new List<Photo>();
        
        //Below is the constructor
        public Album(List<Photo> photos)
        {
            
        }
        

       
    }
}
