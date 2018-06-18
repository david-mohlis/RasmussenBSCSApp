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

using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;
using System.Net.Http;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RasmussenBSCSApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CourseComplete : Page
    {
        public CourseComplete()
        {
            this.InitializeComponent();
        }

        IMobileServiceTable<CoursesComplete> completedCourses = App.MobileService1.GetTable<CoursesComplete>();
        MobileServiceCollection<CoursesComplete, CoursesComplete> classList;

        public class Contact
        {
            public int ID { get; set; }
            public string NAME { get; set; }
            public string EMAILADDRESS { get; set; }
        }

        public class CoursesComplete
        {
            public string Id { get; set; }
            public string courseName { get; set; }
            public string courseNumber { get; set; }
            public string courseCredits { get; set; }
            public string gradeReceived { get; set; }
            public string quarterComplete { get; set; }
            public string instructorName { get; set; }
            public Boolean courseRemoved { get; set; }
        }

        async private void SubmitAddCourse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /* add course information to db with successful message popup*/
            try
            {
                /*search database for all courses that haven't been deleted and also that there are no duplicate course names*/
                classList = await completedCourses
                    .Where(CoursesComplete => CoursesComplete.courseName == addCourseName.Text && CoursesComplete.courseRemoved == false)                    
                    .ToCollectionAsync();

                //Check to make sure course name selection is entered.
                if (selectCourseName.SelectedValue != null)
                {
                    if (classList.Count == 0)
                    {
                        CoursesComplete addClass = new CoursesComplete
                        {
                            courseName = addCourseName.Text,
                            courseNumber = addCourseNumber.Text,
                            courseCredits = addCreditsReceived.Text,
                            gradeReceived = addGrade.Text,
                            quarterComplete = addQuarter.Text,
                            instructorName = addInstructor.Text,
                            courseRemoved = false
                        };
                        await App.MobileService1.GetTable<CoursesComplete>().InsertAsync(addClass);
                        var dialog = new MessageDialog("Class added successfully!");
                        await dialog.ShowAsync();

                        ClearAdd();
                    }
                    else
                    {
                        var dialog = new MessageDialog("Class has already been entered.");
                        await dialog.ShowAsync();
                    }
                }
                else
                {
                    var dialog = new MessageDialog("Course Name not selected.");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }           
        }

        async private void SubmitUpdateCourse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*update course information in db with successful message popup*/
            try
            {
                //make sure a class is selected before submitting updates
                if (updateSelectName.SelectedValue != null)
                {
                    CoursesComplete updateClass = new CoursesComplete
                    {
                        Id = updateId.Text,
                        courseName = updateCourseName.Text,
                        courseNumber = updateCourseNumber.Text,
                        courseCredits = updateCreditsReceived.Text,
                        gradeReceived = updateGrade.Text,
                        quarterComplete = updateQuarter.Text,
                        instructorName = updateInstructor.Text,
                        courseRemoved = false
                    };
                    await completedCourses.UpdateAsync(updateClass);
                    var dialog = new MessageDialog("Class updated successfully!");
                    await dialog.ShowAsync();

                    ClearUpdate();                    
                }
                else
                {
                    var dialog = new MessageDialog("Course not selected for update.");
                    await dialog.ShowAsync();
                } 
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }
        }

        async private void SubmitDeleteCourse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*delete course information in db with successful message popup*/
            try
            {
                //make sure a class is selected before submitting delete request
                if (deleteSelectedName.SelectedValue != null)
                {
                    CoursesComplete deleteClass = new CoursesComplete
                    {
                        Id = deleteId.Text,
                        courseName = deleteCourseName.Text,
                        courseNumber = deleteCourseNumber.Text,
                        courseCredits = deleteCreditsReceived.Text,
                        gradeReceived = deleteGrade.Text,
                        quarterComplete = deleteQuarter.Text,
                        instructorName = deleteInstructor.Text,
                        courseRemoved = true
                    };
                    await completedCourses.UpdateAsync(deleteClass);
                    var dialog = new MessageDialog("Class deleted successfully!");
                    await dialog.ShowAsync();
                    ClearDelete();
                }
                else
                {
                    var dialog = new MessageDialog("Class not selected for deletion.");
                    await dialog.ShowAsync();
                }
            }
            catch (Exception em)
            {
                var dialog = new MessageDialog("An Error Occured: " + em.Message);
                await dialog.ShowAsync();
            }
        }

        async private void UpdateCourses_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Course Complete feature "refresh" button. Clears all previous grid contents and calls RefreshList to display clean list
            foreach (UIElement element in courseCompleteListTable.Children)
            {
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }
            }
            await RefreshList();                        
        }

        private async Task RefreshList()
        {
            /*function that populates information for courses complete feature*/
            MobileServiceInvalidOperationException exception = null;
            try
            {
                classList = await completedCourses
                    .Where(CoursesComplete => CoursesComplete.courseRemoved == false)
                    .OrderBy(courseComplete => courseComplete.courseName)
                    .ToCollectionAsync();

                //function that generates the column headers
                CreateGridHeader();

                //build a new row and column for all classes added
                for (int i = 0; i < classList.Count; i++)
                {
                    courseCompleteListTable.RowDefinitions.Add(new RowDefinition());
                    courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
                    courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
                    courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
                    courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
                    courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
                    courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());

                    TextBox results1 = new TextBox();
                    Grid.SetColumn(results1, 0);
                    Grid.SetRow(results1, (i + 1));
                    courseCompleteListTable.Children.Add(results1);
                    results1.TextWrapping = TextWrapping.Wrap;
                    results1.BorderThickness = new Thickness(3);
                    results1.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                    results1.Name = "resulttextbox1" + i;
                    results1.IsReadOnly = true;
                    results1.Text = classList[i].courseName;

                    TextBox results2 = new TextBox();
                    Grid.SetColumn(results2, 1);
                    Grid.SetRow(results2, (i + 1));
                    courseCompleteListTable.Children.Add(results2);
                    results2.TextWrapping = TextWrapping.Wrap;
                    results2.BorderThickness = new Thickness(3);
                    results2.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                    results2.Name = "resulttextbox1" + i;
                    results2.IsReadOnly = true;
                    results2.Text = classList[i].courseNumber;

                    TextBox results3 = new TextBox();
                    Grid.SetColumn(results3, 2);
                    Grid.SetRow(results3, (i + 1));
                    courseCompleteListTable.Children.Add(results3);
                    results3.TextWrapping = TextWrapping.Wrap;
                    results3.BorderThickness = new Thickness(3);
                    results3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                    results3.Name = "resulttextbox1" + i;
                    results3.IsReadOnly = true;
                    results3.Text = classList[i].courseCredits;

                    TextBox results4 = new TextBox();
                    Grid.SetColumn(results4, 3);
                    Grid.SetRow(results4, (i + 1));
                    courseCompleteListTable.Children.Add(results4);
                    results4.TextWrapping = TextWrapping.Wrap;
                    results4.BorderThickness = new Thickness(3);
                    results4.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                    results4.Name = "resulttextbox1" + i;
                    results4.IsReadOnly = true;
                    results4.Text = classList[i].gradeReceived;

                    TextBox results5 = new TextBox();
                    Grid.SetColumn(results5, 4);
                    Grid.SetRow(results5, (i + 1));
                    courseCompleteListTable.Children.Add(results5);
                    results5.TextWrapping = TextWrapping.Wrap;
                    results5.BorderThickness = new Thickness(3);
                    results5.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                    results5.Name = "resulttextbox1" + i;
                    results5.IsReadOnly = true;
                    results5.Text = classList[i].quarterComplete;

                    TextBox results6 = new TextBox();
                    Grid.SetColumn(results6, 5);
                    Grid.SetRow(results6, (i + 1));
                    courseCompleteListTable.Children.Add(results6);
                    results6.TextWrapping = TextWrapping.Wrap;
                    results6.BorderThickness = new Thickness(3);
                    results6.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                    results6.Name = "resulttextbox1" + i;
                    results6.IsReadOnly = true;
                    results6.Text = classList[i].instructorName;
                }
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }
        }

        private void CreateGridHeader()
        {
            //this function builds the top header information for RefreshList function
            courseCompleteListTable.RowDefinitions.Add(new RowDefinition());
            courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
            courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
            courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
            courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
            courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());
            courseCompleteListTable.ColumnDefinitions.Add(new ColumnDefinition());

            TextBox header1 = new TextBox();
            Grid.SetColumn(header1, 0);            
            Grid.SetRow(header1, 0);            
            courseCompleteListTable.Children.Add(header1);                         
            header1.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            header1.BorderThickness = new Thickness(3);
            header1.IsReadOnly = true;
            header1.Text = "Course Name";

            TextBox header2 = new TextBox();
            Grid.SetColumn(header2, 1);
            Grid.SetRow(header2, 0);
            courseCompleteListTable.Children.Add(header2);            
            header2.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            header2.BorderThickness = new Thickness(3);
            header2.IsReadOnly = true;
            header2.Text = "Course Number";

            TextBox header3 = new TextBox();
            Grid.SetColumn(header3, 2);
            Grid.SetRow(header3, 0);
            courseCompleteListTable.Children.Add(header3);            
            header3.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            header3.BorderThickness = new Thickness(3);
            header3.IsReadOnly = true;
            header3.Text = "Credits";

            TextBox header4 = new TextBox();
            Grid.SetColumn(header4, 3);
            Grid.SetRow(header4, 0);
            courseCompleteListTable.Children.Add(header4);            
            header4.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            header4.BorderThickness = new Thickness(3);
            header4.IsReadOnly = true;
            header4.Text = "Grade";

            TextBox header5 = new TextBox();
            Grid.SetColumn(header5, 4);
            Grid.SetRow(header5, 0);
            courseCompleteListTable.Children.Add(header5);                   
            header5.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            header5.BorderThickness = new Thickness(3);
            header5.IsReadOnly = true;
            header5.Text = "Quarter";

            TextBox header6 = new TextBox();
            Grid.SetColumn(header6, 5);
            Grid.SetRow(header6, 0);
            courseCompleteListTable.Children.Add(header6);                        
            header6.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            header6.BorderThickness = new Thickness(3);
            header6.IsReadOnly = true;
            header6.Text = "Instructor";
        }

        private void ClearAdd()
        {
            //clear add course form information
            selectCourseName.SelectedValue = "";
            addCourseName.Text = "";
            addCourseNumber.Text = "";
            addCreditsReceived.Text = "";
            addGrade.Text = "";
            addQuarter.Text = "";
            addInstructor.Text = "";
        }

        private void ClearUpdate()
        {
            //clear update course form information
            updateSelectName.SelectedValue = "";
            updateCourseName.Text = "";
            updateCourseNumber.Text = "";
            updateCreditsReceived.Text = "";
            updateGrade.Text = "";
            updateQuarter.Text = "";
            updateInstructor.Text = "";
        }

        private void ClearDelete()
        {
            //clear delete course form information
            deleteSelectedName.SelectedValue = "";
            deleteCourseName.Text = "";
            deleteCourseNumber.Text = "";
            deleteCreditsReceived.Text = "";
            deleteGrade.Text = "";
            deleteQuarter.Text = "";
            deleteInstructor.Text = "";
        }

        private void BackButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //event handler for back button in bottom left corner. navigates to mainpage
            this.Frame.Navigate(typeof(RasmussenBSCSApp.MainPage), null);
        }

        private void CourseCompleteList_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*set course complete grid as visible and the rest to collapsed*/
            courseCompleteListTable.Visibility = Visibility.Visible;
            viewCourseButton.Visibility = Visibility.Visible;
            viewCoursesHeader.Visibility = Visibility.Visible;
            addCourseForm.Visibility = Visibility.Collapsed;
            updateCourseForm.Visibility = Visibility.Collapsed;
            deleteCourseForm.Visibility = Visibility.Collapsed;
        }

        private void AddCourse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*set grid for add form as visible and the rest to collapsed*/
            addCourseForm.Visibility = Visibility.Visible;
            courseCompleteListTable.Visibility = Visibility.Collapsed;
            viewCourseButton.Visibility = Visibility.Collapsed;
            viewCoursesHeader.Visibility = Visibility.Collapsed;
            updateCourseForm.Visibility = Visibility.Collapsed;
            deleteCourseForm.Visibility = Visibility.Collapsed;

            ClearAdd();
        }

        async private void UpdateCourse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*set update form grid as visible and the rest to collapsed*/
            updateCourseForm.Visibility = Visibility.Visible;            
            courseCompleteListTable.Visibility = Visibility.Collapsed;
            viewCourseButton.Visibility = Visibility.Collapsed;
            viewCoursesHeader.Visibility = Visibility.Collapsed;
            addCourseForm.Visibility = Visibility.Collapsed;
            deleteCourseForm.Visibility = Visibility.Collapsed;

            ClearUpdate();

            //Create list of added courses to update from database and sorts them by course name.
            MobileServiceInvalidOperationException exception = null;
            try
            {
                classList = await completedCourses
                    .Where(CoursesComplete => CoursesComplete.courseRemoved == false)
                    .OrderBy(CoursesComplete => CoursesComplete.courseName)
                    .ToCollectionAsync();

                if (classList.Count == 0)
                {
                    await new MessageDialog("No Classes Available to Update").ShowAsync();
                }
                else
                {
                    updateSelectName.Items.Clear();
                    for (int i = 0; i < classList.Count; i++)
                    {
                        updateSelectName.Items.Add(classList[i].courseName);
                    }
                }
            }
            catch (MobileServiceInvalidOperationException e2)
            {
                exception = e2;
            }
        }

        async private void UpdateCourseForm_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //populates update course form information for easy updating.
            MobileServiceInvalidOperationException exception1 = null;            
            try
            {
                if (updateSelectName.SelectedValue != null)
                {
                    classList = await completedCourses
                        .Where(CoursesComplete => CoursesComplete.courseName == updateSelectName.SelectedItem.ToString() && CoursesComplete.courseRemoved == false)
                        .ToCollectionAsync();

                    updateId.Text = classList[0].Id;
                    updateCourseName.Text = classList[0].courseName;
                    updateCourseNumber.Text = classList[0].courseNumber;
                    updateCreditsReceived.Text = classList[0].courseCredits;
                    updateGrade.Text = classList[0].gradeReceived;
                    updateQuarter.Text = classList[0].quarterComplete;
                    updateInstructor.Text = classList[0].instructorName;
                }
                else
                {
                    await new MessageDialog("Course Name not selected.").ShowAsync();
                }
            }
            catch (MobileServiceInvalidOperationException e1)
            {
                exception1 = e1;
            }
        }

        async private void DeleteCourse_Tapped(object sender, TappedRoutedEventArgs e)
        {
            /*set delete form as visible and the rest to collapsed*/
            deleteCourseForm.Visibility = Visibility.Visible;            
            courseCompleteListTable.Visibility = Visibility.Collapsed;
            viewCourseButton.Visibility = Visibility.Collapsed;
            viewCoursesHeader.Visibility = Visibility.Collapsed;
            addCourseForm.Visibility = Visibility.Collapsed;
            updateCourseForm.Visibility = Visibility.Collapsed;

            ClearDelete();

            //Create list of added courses to delete from database and sorts them by course name.
            MobileServiceInvalidOperationException exception = null;
            try
            {
                classList = await completedCourses
                    .Where(CoursesComplete => CoursesComplete.courseRemoved == false)
                    .OrderBy(CoursesComplete => CoursesComplete.courseName)
                    .ToCollectionAsync();

                if (classList.Count == 0)
                {
                    await new MessageDialog("No Classes Available to Delete").ShowAsync();
                }
                else
                {
                    deleteSelectedName.Items.Clear();
                    for (int i = 0; i < classList.Count; i++)
                    {
                        deleteSelectedName.Items.Add(classList[i].courseName);
                    }
                }
            }
            catch (MobileServiceInvalidOperationException e1)
            {
                exception = e1;
            }
        }

        async private void DeleteCourseForm_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //populated delete course form information for easy deletion.
            MobileServiceInvalidOperationException exception1 = null;
            try
            {
                if (deleteSelectedName.SelectedValue != null)
                {
                    classList = await completedCourses
                        .Where(CoursesComplete => CoursesComplete.courseName == deleteSelectedName.SelectedItem.ToString() && CoursesComplete.courseRemoved == false)
                        .ToCollectionAsync();

                    deleteId.Text = classList[0].Id;
                    deleteCourseName.Text = classList[0].courseName;
                    deleteCourseNumber.Text = classList[0].courseNumber;
                    deleteCreditsReceived.Text = classList[0].courseCredits;
                    deleteGrade.Text = classList[0].gradeReceived;
                    deleteQuarter.Text = classList[0].quarterComplete;
                    deleteInstructor.Text = classList[0].instructorName;
                }
                else
                {
                    await new MessageDialog("Course Name not selected").ShowAsync();
                }
            }
            catch (MobileServiceInvalidOperationException e2)
            {
                exception1 = e2;
            }
        }

        //All Combobox event handlers are to populate course name, number, and credits fields for add coures feature.
        private void ComboBox1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox1.Content.ToString();
            addCourseNumber.Text = "CTS4623C";
            addCreditsReceived.Text = "4";
        }

        private void ComboBox2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox2.Content.ToString();
            addCourseNumber.Text = "CIS4655C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox3.Content.ToString();
            addCourseNumber.Text = "GEB3422";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox4_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox4.Content.ToString();
            addCourseNumber.Text = "CIS4910C";
            addCreditsReceived.Text = "3";
        }

        private void ComboBox5_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox5.Content.ToString();
            addCourseNumber.Text = "CIS4793C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox6_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox6.Content.ToString();
            addCourseNumber.Text = "CTS4557";
            addCreditsReceived.Text = "3";
        }

        private void ComboBox7_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox7.Content.ToString();
            addCourseNumber.Text = "CTS3302C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox8_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox8.Content.ToString();
            addCourseNumber.Text = "CDA3428C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox9_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox9.Content.ToString();
            addCourseNumber.Text = "CIS3917C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox10_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox10.Content.ToString();
            addCourseNumber.Text = "CDA3315C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox11_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox11.Content.ToString();
            addCourseNumber.Text = "CIS3801C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox12_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox12.Content.ToString();
            addCourseNumber.Text = "CTS3265C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox13_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox13.Content.ToString();
            addCourseNumber.Text = "MAN3504";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox14_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox14.Content.ToString();
            addCourseNumber.Text = "COP3488C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox15_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox15.Content.ToString();
            addCourseNumber.Text = "COP4474C";
            addCreditsReceived.Text = "4";

        }

        private void ComboBox16_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox16.Content.ToString();
            addCourseNumber.Text = "COP4777C";            
            addCreditsReceived.Text = "4";

        }

        private void ComboBox17_Tapped(object sender, TappedRoutedEventArgs e)
        {
            addCourseName.Text = ComboBox17.Content.ToString();
            addCourseNumber.Text = "CIS4836C";
            addCreditsReceived.Text = "4";

        }
    }
}
