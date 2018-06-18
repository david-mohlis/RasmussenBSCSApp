using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//using Amazon.IdentityManagement;
//using Amazon.IdentityManagement.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RasmussenBSCSApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ProgramInfo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProgramInfo), null);
        }

        private void FacultyList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FacultyList), null);
        }

        private void CourseList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseList), null);
        }

        private void ToDoList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ToDoList), null);
        }

        private void AuthLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AuthLogin), null);
        }

        private void CourseComplete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CourseComplete), null);
        }

        private void PrettyButton_Click(object sender, RoutedEventArgs e)
        {
            MainPageGrid.Background.SetValue(SolidColorBrush.ColorProperty, Windows.UI.Colors.HotPink);
            prettyButton.Content = "Pretty Background Selected";
            boringButton.Content = "Click for boring background";
            improveButton.Content = "Click for improved background";
        }

        private void BoringButton_Click(object sender, RoutedEventArgs e)
        {
            MainPageGrid.Background.SetValue(SolidColorBrush.ColorProperty, Windows.UI.Colors.White);
            prettyButton.Content = "Click for pretty background";
            boringButton.Content = "Boring Background Selected";
            improveButton.Content = "Click for improved background";
        }

        private void ImproveButton_Click(object sender, RoutedEventArgs e)
        {
            MainPageGrid.Background.SetValue(SolidColorBrush.ColorProperty, Windows.UI.Colors.LightSlateGray);
            prettyButton.Content = "Click for pretty background";
            boringButton.Content = "Click for boring background";
            improveButton.Content = "Improved Background Selected";
        }

        public static string AWS_Name { get; set; }

        public static void GetAWS()
        {
            var Var2 = new Amazon.Auth.AccessControlPolicy.Policy();
            AWS_Name = Convert.ToString(Var2.Version);
        }

        private void btnGetAPI_Click(object sender, RoutedEventArgs e)
        {
            GetAWS();
            resultsGetAPI.Text = "Version: " + AWS_Name;
        }

        private void GoogleAuth_Tapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GoogleAuth), null);
        }
    }
}
