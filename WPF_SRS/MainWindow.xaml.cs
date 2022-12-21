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

        Student selectedStudent = null;
        Teacher selectedTeacher = null;
        Course selectedCourse = null;
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
        }
    }
}
