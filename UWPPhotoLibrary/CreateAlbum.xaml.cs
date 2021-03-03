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
using Windows.Storage.Pickers;
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
    public sealed partial class CreateAlbum : ContentDialog
    {
 
        private Frame Frame;
        public CreateAlbum(Frame frame)
        {
            Frame = frame;
            this.InitializeComponent();
        }
        
        private void ContentDialog_AddClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            String Content = this.AlbumName.Text;
            Frame.Navigate(typeof(CategoryPage), Content);

        }



        private void ContentDialog_CancelClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
       
    }
}
