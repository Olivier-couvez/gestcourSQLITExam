using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.Models
{
    [Serializable]
    public class Inscription : BindableObject
    {
        private int _num = 0;
        private int _idxCoureur;
        private int _idxCourse;
        private static int _nbInsciption;

        public Inscription()
        {
            Num = NbCourses++;
        }

        public static int NbCourses { get => _nbInsciption; set { _nbInsciption = value; } }
        public int Num { get => _num; set { _num = value; } }
        public int IdxCoureur { get => _idxCoureur; set { _idxCoureur = value; OnPropertyChanged(); } }
        public int IdxCourse { get => _idxCourse; set { _idxCourse = value; OnPropertyChanged(); } }
    }
}
