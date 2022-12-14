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
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
