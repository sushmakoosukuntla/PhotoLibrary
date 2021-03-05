using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPPhotoLibrary.Model;
using Windows.ApplicationModel.Activation;
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
        public MainPage()
        {
            this.InitializeComponent();

            MyFrame.Navigate(typeof(CategoryPage));
        }

           /* public void OnLaunched(LaunchActivatedEventArgs e)
            {
                Frame rootFrame = Window.Current.Content as Frame;

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active.
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page.
                    rootFrame = new Frame();

                    rootFrame.NavigationFailed += OnNavigationFailed;

                    if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    {
                        //TODO: Load state from previously suspended application.
                    }

                    // Place the frame in the current Window.
                    Window.Current.Content = rootFrame;
                }

                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter.
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }

                // Ensure the current window is active.
                Window.Current.Activate();
            }

            void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
            {
                throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
            }
        }*/
    




    

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(CategoryPage));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoForward)
            {
                MyFrame.GoForward();
            }
        }

        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new UploadPhoto(MyFrame);
            await dialog.ShowAsync();
          //  MyFrame.Navigate(typeof(AllPhotosPage));
                   
        }

        private async void CreateAlbum_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CreateAlbum(MyFrame);
            await dialog.ShowAsync();


        }
    }
}
