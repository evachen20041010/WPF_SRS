﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SRS
{
    internal class Course
    {
        public string CourseName { get; set; }
        public string Type { get; set; }
        public int Point { get; set; }
        public string OpeningClass { get; set; }
        public Teacher Tutor { get; set; }
        public Course(Teacher tutor)
        {
            Tutor = tutor;
        }
        public override string ToString()
        {
            return $"授課教師 {Tutor.TeacherName}: [{OpeningClass}]{CourseName}({Type}{Point}學分)";
        }
    }
}
