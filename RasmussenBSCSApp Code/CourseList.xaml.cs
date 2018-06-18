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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RasmussenBSCSApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CourseList : Page
    {
        public CourseList()
        {
            this.InitializeComponent();
        }

        private void ListCourseInfo()
        {
            courseNumber.Text = BL_ContentPage.CourseNumberOutput;
            courseName.Text = BL_ContentPage.CourseNameOutput;
            courseDescription.Text = BL_ContentPage.CourseDescriptionOutput;
            courseCredit.Text = BL_ContentPage.CourseCredits;
            coursePrereq.Text = BL_ContentPage.CoursePrereq;
        }

        private void IComboBox1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CDA3315C();
            ListCourseInfo();
        }

        private void IComboBox2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.MAN3504();
            ListCourseInfo();
        }

        private void IComboBox3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CDA3428C();
            ListCourseInfo();
        }

        private void IComboBox4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CIS3801C();
            ListCourseInfo();
        }

        private void IComboBox5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CIS4655C();
            ListCourseInfo();
        }

        private void IComboBox6_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.GEB3422();
            ListCourseInfo();
        }

        private void IComboBox7_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CTS4557();
            ListCourseInfo();
        }
        
        private void IComboBox8_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CIS3917C();
            ListCourseInfo();
        }

        private void IComboBox9_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CTS3265C();
            ListCourseInfo();
        }

        private void IComboBox10_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CIS4793C();
            ListCourseInfo();
        }

        private void IComboBox11_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CIS4836C();
            ListCourseInfo();
        }

        private void IComboBox12_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CTS3302C();
            ListCourseInfo();
        }

        private void IComboBox13_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CTS4623C();
            ListCourseInfo();
        }

        private void IComboBox14_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.CIS4910C();
            ListCourseInfo();
        }

        private void IComboBox15_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.COP3488C();
            ListCourseInfo();
        }

        private void IComboBox16_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.COP4474C();
            ListCourseInfo();
        }

        private void IComboBox17_Tapped(object sender, TappedRoutedEventArgs e)
        {
            BL_ContentPage.COP4777C();
            ListCourseInfo();
        }
                        
        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RasmussenBSCSApp.MainPage), null);
        }
    }
}
