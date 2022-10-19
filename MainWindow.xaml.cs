﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Check;
using Newtonsoft.Json;

namespace CSharp_FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly string[] options = { "Hi" , "Bye" , "Shahd" , "rabea", "rabaa" };

        FolderBrowserDialog dialog = new FolderBrowserDialog();
        string[] courseFiles;
        string[] homeWorkFiles;
        string[] courseHomeWorks;
        CourseInfo courseInfo = new CourseInfo();
        List<Rules> rules = new List<Rules>();

        public MainWindow()
        {
            InitializeComponent();
            //bindListBox();
        }

        private void btn_SelectFolder(object sender, RoutedEventArgs e)
        {  
            dialog.ShowDialog();
            GetFilesAndDirectoriesPath();
            GetCourseInfoAndGrades();
            GetHomeWorkRulesAndGrades();
        }

        private void GetFilesAndDirectoriesPath()
        {
            // get rule and grades files for the home work
            homeWorkFiles = Directory.GetFiles(dialog.SelectedPath);
            // get the students homework folders
            courseHomeWorks = Directory.GetDirectories(dialog.SelectedPath);
            // get course info file and grades 
            courseFiles = Directory.GetFiles(System.IO.Path.GetDirectoryName(dialog.SelectedPath));
        }

        private void GetCourseInfoAndGrades()
        {
            foreach (var file in courseFiles)
            {
                if (System.IO.Path.GetFileName(file) == "course_info.json")
                {
                    courseInfo = JsonConvert.DeserializeObject<CourseInfo>(File.ReadAllText(file));
                }

                else if (System.IO.Path.GetFileName(file) == "course_grades.csv")
                {
                    // work with csv files
                }
            }
        }

        private void GetHomeWorkRulesAndGrades()
        {
            foreach (var file in homeWorkFiles)
            {
                if (System.IO.Path.GetFileName(file) == "rules.json")
                {
                    rules = JsonConvert.DeserializeObject<List<Rules>>(File.ReadAllText(file));
                }

                else if (System.IO.Path.GetFileName(file) == "grades.csv")
                {
                    // work with csv files
                }
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void bindListBox()
        {
            //MyListBox.ItemsSource = options;
        }
        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //<TextBox HorizontalAlignment="Left" Height="25" Margin="600,100,0,0" TextWrapping="Wrap" Text="  Year " VerticalAlignment="Top" Width="130" FontSize="18" TextChanged="TextBox_TextChanged_2" Foreground="SeaGreen"/>
            //MessageBox.Show(MyListBox.SelectedItem.ToString());


        }
    }
}
