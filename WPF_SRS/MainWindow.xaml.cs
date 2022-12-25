using System;
using System.Collections.Generic;
using System.Windows;

namespace WPF_SRS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();
        List<Student> students = new List<Student>();
        List<Record> records = new List<Record>();

        Student selectedStudent = null;
        Teacher selectedTeacher = null;
        Course selectedCourse = null;
        Record selectedRecord = null;
        public MainWindow()
        {
            InitializeComponent();

            InitialCourse();

            InitializeStudent();
        }

        private void InitializeStudent()
        {
            Student student1 = new Student() { StudentID = "5A9G0001", StudentName = "陳小明" };
            students.Add(student1);
            Student student2 = new Student() { StudentID = "5A9G0002", StudentName = "王小美" };
            students.Add(student2);
            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }

        private void InitialCourse()
        {
            //建立測試資料
            Teacher teacher1 = new Teacher("陳定宏");
            //Course coursela = new Course(teacher1) {CourseNmae="視窗程式設計",OpeningClass="五專三甲",Point=3,Type="必修" };
            //teacher1.TeachingCourses.Add(coursela);
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "五專三甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技三乙", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技三丙", Point = 3, Type = "必修" });

            teachers.Add(teacher1);

            Teacher teacher2 = new Teacher("杜俊育");
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "行動無線通訊", OpeningClass = "碩研資工一甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "行動電信網路應用", OpeningClass = "四技資工三甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "雲端人工智慧運算實務", OpeningClass = "四技資工四甲等合開", Point = 3, Type = "選修" });

            teachers.Add(teacher2);

            trvTeacher.ItemsSource = teachers;

            foreach (Teacher teacher in teachers)
            {
                foreach (Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }

            lbCourse.ItemsSource = courses;
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            statusLabel.Content = "選課學生：" + selectedStudent.ToString();
        }

        private void trvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(trvTeacher.SelectedItem is Teacher)
            {
                selectedTeacher = trvTeacher.SelectedItem as Teacher;
                statusLabel.Content = "選取老師：" + selectedTeacher.ToString();
            }
            if(trvTeacher.SelectedItem is Course)
            {
                selectedCourse = trvTeacher.SelectedItem as Course;
                statusLabel.Content = selectedCourse.ToString();
            }
        }

        private void lbCourse_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCourse = lbCourse.SelectedItem as Course;
            statusLabel.Content = selectedCourse.ToString();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請選擇學生或課程", "資料不足");
            }else
            {
                Record currentRecord = new Record()
                {
                    SelectedStudent = selectedStudent,
                    SelectedCourse = selectedCourse
                };
                foreach(Record r in records)
                {
                    if(r.Equals(currentRecord))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName} 已經選過 {selectedCourse.CourseName} 了，請重新選擇未選過的課程");
                        return; 
                    }
                }
                records.Add(currentRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }           
        }

        private void lvRecord_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lvRecord.SelectedItem != null)
            {
                selectedRecord = lvRecord.SelectedItem as Record;
                statusLabel.Content = selectedRecord;
            }
        }

        private void withdrawButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedRecord != null)
            {
                records.Remove(selectedRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }else
            {
                MessageBox.Show("請選擇要退選的紀錄");
            }
        }
    }
}
