using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.Models
{
    [Serializable]
    public class Coureur : BindableObject
    {
        private int _num = 0;
        private string _nom;
        private string _prenom;
        private int _age;
        private string _sexe;
        private static int _nbCoureur;
        private bool _einscrit;
        

        public Coureur()
        {
            Num = NbCoureur++;
        }
        public Coureur(int num, string nom, string prenom,int age, string sexe, bool einscrit = false) : base()
        {
            _num = num;
            _nom = nom;
            _prenom = prenom;
            _age = age;
            _sexe = sexe;
            _einscrit = einscrit;
        }

        public static int NbCoureur { get => _nbCoureur; set { _nbCoureur = value; } }
        public int Num { get => _num; set => _num = value; }
        public string Nom { get => _nom; set { _nom = value; OnPropertyChanged(); } }
        public string Prenom { get => _prenom; set { _prenom = value; OnPropertyChanged(); } }
        public int Age { get => _age; set { _age = value; OnPropertyChanged(); } }
        public string Sexe { get => _sexe; set { _sexe = value; OnPropertyChanged(); } }
        public bool Einscrit { get => _einscrit; set { _einscrit = value; OnPropertyChanged(); } }


    }
}
