using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.Models
{
    [Serializable]
    public class Course : BindableObject
    {
        private int _num = 0;
        private string _nom;
        private string _lieu;
        private double _distance;
        private static int _nbCourses;

        public Course( )
        {
            _num = NbCourses++;
        }

        public static int NbCourses { get => _nbCourses; set { _nbCourses = value; } }
        public int Num { get => _num; set { _num = value; } }
        public string Nom { get => _nom; set { _nom = value; OnPropertyChanged(); } }
        public string Lieu { get => _lieu; set { _lieu = value; OnPropertyChanged(); } }
        public double Distance { get => _distance; set { _distance = value; OnPropertyChanged(); } }
    }
}
