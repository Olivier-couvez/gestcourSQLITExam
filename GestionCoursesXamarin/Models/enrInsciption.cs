using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCoursesXamarin.Models
{
    public class enrInsciption
    {
        [PrimaryKey, AutoIncrement]
        public int _num { get ; set ; }
        public int _idxCoureur { get ; set ; }
        public int _idxCourse { get ; set ; }
        public static int _nbInsciption { get ; set ; }
    }
}