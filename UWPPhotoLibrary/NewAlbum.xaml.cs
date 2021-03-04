using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    public sealed partial class NewAlbum : ContentDialog
    {
        private Frame Frame;
        public NewAlbum(Frame frame)
        {
            Frame = frame;
            this.InitializeComponent();
        }

        private void AddButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {   //public bool Navigate(Type sourcePageType, object parameter);                   
            Frame.Navigate(typeof(AlbumsPage),AlbumName.Text);
            AlbumName.Text = "";
            
        }

        private void CancelButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //
        }
    }
}
