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
            var selecteditem = (Coureur)e.Item;
            Inscrit.IdxCoureur = selecteditem.Num;
            Inscrit.IdxCourse = NumCourse;
            App.ListeInscription.Add(Inscrit);
            App.ListeCoureurs[selecteditem.Num].Einscrit = true;
            EstIsncrit = "oui";
        }

        public void IntialisationCoureur(int NumCourse)
        {
            foreach(Coureur coureur in App.ListeCoureurs)
            {
                foreach (Inscription inscript in App.ListeInscription)
                {
                    if ((inscript.IdxCoureur == coureur.Num) && (inscript.IdxCourse == NumCourse ))
                    {
                        EstIsncrit = "oui";
                    }
                    else
                    {
                        EstIsncrit = "non";
                    }
                }
               
            }
        }
    }
}
