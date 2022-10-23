using System;
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

        FolderBrowserDialog dialog = new FolderBrowserDialog();
        string[] courseFiles;
        string[] TaskFiles;
        string[] TaskHomeWorks;
        string[] HWSrecevie;
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
            //foreach(var HW in TaskHomeWorks)
            //{
            //    HWSrecevie.Append(HW.Split('\\').Last().Split('_')[0]);
            //}
            foreach(var studentHomework in TaskHomeWorks)
            {
                Student s = new Student();
                string StudentHWName = studentHomework.Split('\\').Last();
                s.Id = StudentHWName.Split('_')[0];
                s.Name = StudentHWName.Split('_')[1];
                s.Course = courseInfo.Course_name;
                s.Year = courseInfo.Course_year;
                s.Grade = 100;
                s.Average = 0;
                string[] StudentFiles = Directory.GetFiles(studentHomework);

                foreach (var rule in rules)
                {
                    if (rule.Rule_Number == 2)
                    {
                        bool exist = false;
                        foreach (var file in StudentFiles)
                        {
                            if(file.Split('\\').Last() == rule.File_Name)
                                exist = true;
                        }
                        if (exist == false)
                            s.Grade -= rule.Points;
                    }

                    if(rule.Rule_Number == 3)
                    {
                        bool exp = false;
                        foreach (var file in StudentFiles)
                        {
                            if (file.Split('\\').Last() == rule.File_Name)
                            {
                                foreach (var line in File.ReadAllLines(file))
                                {
                                    if (line.Contains(rule.Regular_Exp) == true)
                                        exp = true;
                                    break;
                                }
                            }
                            break;
                        }
                        if (exp == false && s.Grade >= rule.Points)
                            s.Grade -= rule.Points;
                        else if(exp == false)
                            s.Grade = 0;
                    }
                }
            }
        }

        private void GetFilesAndDirectoriesPath()
        {
            // get rule and grades files for the home work
            TaskFiles = Directory.GetFiles(dialog.SelectedPath);
            // get the students homework folders
            TaskHomeWorks = Directory.GetDirectories(dialog.SelectedPath);
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
            foreach (var file in TaskFiles)
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
       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
