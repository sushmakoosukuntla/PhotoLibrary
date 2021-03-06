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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPhotoLibrary
{
    public sealed partial class UploadPhoto : ContentDialog
    {
        private IReadOnlyList<StorageFile> SelectedPhotosList;
        private static List<string> AllowedExtensions= new List<string> { ".jpg", ".png", ".gif"
        , ".jpeg"};
        private Frame Frame;

        public UploadPhoto(Frame frame)
        {
            Frame = frame;
            this.InitializeComponent();        
        }

        

        private async void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            //the new PicturesLibrary from local computer will get popped up to select pictures
            FileOpenPicker Fop = new FileOpenPicker();

            /*for FileOpenPicker there are many properties, ViewMode and SuggestedStartLocation
             are couple of them*/
            Fop.ViewMode = PickerViewMode.List;
            Fop.SuggestedStartLocation= PickerLocationId.PicturesLibrary;

            /*We should specify the type of files we wanted to open. For this i have created the 
             *static property(private static List<string> AllowedExtensions= 
             *new List<string> { ".jpg", ".png", ".gif", ".jpeg"};) below the class and I 
             have added them to FileTypeFilter by using foreach loop*/

            foreach (var Extension in AllowedExtensions)
                Fop.FileTypeFilter.Add(Extension);     
            
            SelectedPhotosList =  await Fop.PickMultipleFilesAsync();
            if (SelectedPhotosList != null && SelectedPhotosList.Count > 0)
            {
                foreach (StorageFile file in SelectedPhotosList)
                    Image.Text += file.Name;
                Image.TextWrapping = TextWrapping.Wrap;

                IsPrimaryButtonEnabled = true;
            }
        }

        private void OpenButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var ToBeUploadedPhotosList = new List<Photo>();
            foreach (StorageFile imageFile in SelectedPhotosList)
            {
               // var uri = new System.Uri(imageFile.Path);
                var image = new Photo(imageFile.Name, imageFile);
                ToBeUploadedPhotosList.Add(image);
            }
           Frame.Navigate(typeof(AllPhotosPage), ToBeUploadedPhotosList);

          
        } 

       
    }
}
