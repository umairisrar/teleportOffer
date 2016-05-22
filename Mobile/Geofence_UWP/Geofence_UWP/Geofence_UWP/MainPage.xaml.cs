using Geofence_UWP.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Geofence_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        DataTransferManager dataTransferManager;
        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            this.ShellSplitView.Content = frame;

            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += dataTransferManager_DataRequested;
        }


        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // ShellSplitView.CompactPaneLength = 48;
            this.ShellSplitView.IsPaneOpen = !this.ShellSplitView.IsPaneOpen;

        }
        private void HamburgerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // don't let the radiobutton check
            (sender as RadioButton).IsChecked = false;

            // toggle the splitview pane
            this.ShellSplitView.IsPaneOpen = !this.ShellSplitView.IsPaneOpen;
        }


        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)ShellSplitView.Content).Navigate(typeof(HomePage));
            //Frame.Navigate(typeof(HomePage));
        }




        private void Deals_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NearBy_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)ShellSplitView.Content).Navigate(typeof(DealsPage));
        }


        void dataTransferManager_DataRequested(DataTransferManager sender,
              DataRequestedEventArgs args)
        {
            Uri sharedWebLink = new Uri("https://www.microsoft.com/en-gb/store/apps/ocumatic/9nblggh4rh0x");

            if (sharedWebLink != null)
            {
                DataPackage dataPackage = args.Request.Data;
                dataPackage.Properties.Title = "Sharing Ocumatic";

                dataPackage.Properties.Description =
                    "With Ocumatic you can Track Your Eye Health and Connect with Your Eye MD";


                dataPackage.SetWebLink(sharedWebLink);
            }
        }
        private void Share_Click(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rate_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
