using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SRS
{
    internal class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return $"{StudentID} {StudentName}";
        }
    }
}
