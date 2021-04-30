using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCoursesXamarin.Models
{
    public class enrCourse
    {
        [PrimaryKey, AutoIncrement]
        public int _num  { get; set; }
        public string _nom { get; set; }
        public string _lieu { get; set; }
        public double _distance { get; set; }
        public static int _nbCourses { get; set; }
    }
}
