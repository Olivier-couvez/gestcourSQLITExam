using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.ViewModels
{
    class GestionInscriptionViewModel : BindableObject
    {
        private Inscription _inscript;
        private string _estIsncrit;

        public Inscription Inscrit { get => _inscript; set { _inscript = value; OnPropertyChanged(); } }

        public string EstIsncrit { get { return _estIsncrit; } set { _estIsncrit = value; OnPropertyChanged(); } }

        public Command btnRetour { get; set; }
        public INavigation Navigation { get; set; }

        public GestionInscriptionViewModel(INavigation navigation)
        {
            if (Inscrit == null)
            {
                Inscrit = new Inscription();
                btnRetour = new Command(RetourCommand);
                Navigation = navigation;
            }
        }

        private void RetourCommand()
        {
            Navigation.PopModalAsync();
        }

        public void MajDonnees(ItemTappedEventArgs e, int NumCourse)
        {
            bool ecritOk = true;
            Inscrit = new Inscription();
            var selecteditem = (Coureur)e.Item;
            Inscrit.IdxCoureur = selecteditem.Num;
            Inscrit.IdxCourse = NumCourse;
            foreach(Inscription inscript in App.ListeInscription)
            {
                if (inscript.IdxCoureur == Inscrit.IdxCoureur && Inscrit.IdxCourse == NumCourse)
                {
                    ecritOk = false;
                }       
            }
            if (ecritOk == true)
            {
                App.ListeInscription.Add(Inscrit);
                App.ListeCoureurs[selecteditem.Num-1].Einscrit = true;
                EstIsncrit = "oui";
            }



        }

        public void IntialisationCoureur(int NumCourse)
        {
            foreach (Coureur coureur in App.ListeCoureurs)
            {
                EstIsncrit = "non";
                App.ListeCoureurs[coureur.Num-1].Einscrit = false;
            }



                foreach (Coureur coureur in App.ListeCoureurs)
            {
                foreach (Inscription inscript in App.ListeInscription)
                {
                    if ((inscript.IdxCoureur == coureur.Num-1) && (inscript.IdxCourse == NumCourse ))
                    {
                        EstIsncrit = "oui";
                        App.ListeCoureurs[coureur.Num-1].Einscrit = true;
                    }
                }
               
            }
        }
    }
}
