using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class SingleImage : Page
    {
        ObservableCollection<Photo> Singleimage = new ObservableCollection<Photo>();

        public SingleImage()
        {
            this.InitializeComponent();

        }
       
        //select multiple photos in UI to navigate between images on the screen
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e != null && e.Parameter != null)
            {
                if (e.Parameter.GetType() == typeof(List<Photo>))
                {
                    var pickedPhotos = (List<Photo>)e.Parameter;
                    foreach (var photo in pickedPhotos)
                    {
                        Singleimage.Add(photo);
                    }
                }
            }
        }
    }
}