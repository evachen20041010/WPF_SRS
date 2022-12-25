namespace WPF_SRS
{
    internal class Record
    {
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }
        public bool Equals(Record record)
        {
            if (SelectedStudent.StudentID == record.SelectedStudent.StudentID && SelectedCourse.CourseName == record.SelectedCourse.CourseName)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return $"選課紀錄：{SelectedStudent.StudentName}\\{SelectedCourse.CourseName}";
        }
    }
}
