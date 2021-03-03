using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavoritesPage : Page
    {
        private ObservableCollection<Photo> FavPhotos;

        /*Here we have created the static list of FavCollections of type photo because, from the UI when we click on AllPhotos 
         it redirects to All photos page, and we can select some pictures and we can move it to favorites,then favoritesfolder gets
        displayed immediately which is good, But when we go back to the category Grid and select Favorites albums, If we dont
        give FavCollectionsSet as static, new ObservableCollection<Photo> will get initialized, and folder get empty.
        Static means, we give the value to the object only when we initialize, thats it*/

        /*We have also given Hashset because in order to no to repeat the favorite photos.*/
        private static HashSet<Photo> FavCollectionsSet = new HashSet<Photo>();        
        public FavoritesPage()
        {
            this.InitializeComponent();
            FavPhotos = new ObservableCollection<Photo>();            

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)

        {
            /*here in e we dont have a observablecollection list, so we are moving this list 
             to FavPhotos which is observable collection list*/
            

            if (e != null && e.Parameter != null)                
            {
                var favs = (List<Photo>)e.Parameter;
                for (var i = 0; i < favs.Count; i++)
                {
                    FavCollectionsSet.Add((Photo)favs[i]);                                                                               
                }
            }
            FavPhotos.Clear();
            foreach (var value in FavCollectionsSet)                
            {
                
                FavPhotos.Add(value);
            }
        }

        private void Image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            int startingPositionPhoto = 0;
            //var doubleTapped = new Photo();
            var fpics = new ObservableCollection<Photo>();
            var selectedPhoto = (Photo)FavoritesGrid.SelectedItems[0];
            foreach(var pic in FavCollectionsSet)
            {
                fpics.Add(pic);

            }
            if (FavCollectionsSet.Contains(selectedPhoto))
            {
                startingPositionPhoto = fpics.IndexOf(selectedPhoto);
            }
            var Ps = new PhotoSelection();
            Ps.SelectedPhotoPosition = startingPositionPhoto;
            Ps.Photos = fpics;
            Frame.Navigate(typeof(SingleImage), Ps);
        }
    }
}
