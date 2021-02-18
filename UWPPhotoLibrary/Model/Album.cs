using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPPhotoLibrary.Model
{
    public class Album
    {
        private List<Photo> getImages()
        {
            var images = new List<Photo>();
            images.Add(new Photo(AlbumName.Animals));
            images.Add(new Photo(AlbumName.Babies));
            images.Add(new Photo(AlbumName.Flowers));
            images.Add(new Photo(AlbumName.Fruits));
            images.Add(new Photo(AlbumName.Nature));

            return images;

        }
    }
}
