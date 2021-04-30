using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestionCoursesXamarin.ViewModels
{
    public class GestionCoureursViewModel : BindableObject
    {
        private Coureur _coureur;

        public Coureur Coureur { get => _coureur; set { _coureur = value; OnPropertyChanged(); } }

        public Command ValiderCoureur { get; set; }
        public Command AnnulerCoureur { get; set; }

        public INavigation Navigation { get; set; }



        public GestionCoureursViewModel(INavigation navigation)
        {
 

            if (Coureur ==  null)
            {
                Coureur = new Coureur();
                ValiderCoureur = new Command(ValiderCoureurCommand);
                AnnulerCoureur = new Command(AnnulerCoureurCommand);
                Navigation = navigation;
            }
        }

        private void ValiderCoureurCommand()
        {
            // test

            if(!string.IsNullOrEmpty(Coureur.Prenom) || !string.IsNullOrEmpty(Coureur.Nom) || !string.IsNullOrEmpty(Coureur.Sexe) || !string.IsNullOrEmpty(Coureur.Age.ToString()))
            {
                App.ListeCoureurs.Add(Coureur);

                Navigation.PopModalAsync();
            }
        }
        private void AnnulerCoureurCommand()
        {
                Navigation.PopModalAsync();
        }
    }
}
