using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    class PhotoSelection
    {
        public int SelectedPhotoPosition { get; set; }
        public  ObservableCollection<Photo> Photos { get; set; }
    }
}
