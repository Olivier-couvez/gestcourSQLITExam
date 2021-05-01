using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCoursesXamarin.Models
{
    public class enrCoureur
    {
        [PrimaryKey, AutoIncrement]
        public int _num { get; set; }
        public string _nom { get ; set ;  }
        public string _prenom { get ; set ; }
        public int _age { get; set; }
        public string _sexe { get ; set ;}
        public bool _einscrit { get; set; }
        public static int _nbCoureur { get; set; }
    }
}
