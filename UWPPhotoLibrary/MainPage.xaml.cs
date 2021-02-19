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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPPhotoLibrary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Photo> photos;
        private List<CategoryList> Category;
        public MainPage()
        {
            this.InitializeComponent();
            
            //After initializing the app, we can see category grid.
            Category = new List<CategoryList>();
            Category.Add(new CategoryList { IconFile = "Assets/CategoryIcons/Albums-Icon.png", });
            Category.Add(new CategoryList(PhotoCategory.Albums, "Albums"));
            Category.Add(new CategoryList(PhotoCategory.Favotites, "Favorites"));

        }

        private void BackButton_Click(object sender, RoutedEventArgs e) //line 21 in xaml
        {
            
        }
    }
}
