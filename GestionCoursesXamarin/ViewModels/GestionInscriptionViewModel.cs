using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GestionCoursesXamarin.Extension;
using System.Linq;

namespace GestionCoursesXamarin.ViewModels
{
    class GestionInscriptionViewModel : BindableObject
    {
        private Inscription _inscript;
        private string _estIsncrit;
        private List<Coureur> _listCoureur;

        public Inscription Inscrit { get => _inscript; set { _inscript = value; OnPropertyChanged(); } }

        public string EstIsncrit { get { return _estIsncrit; } set { _estIsncrit = value; OnPropertyChanged(); } }
        public List<Coureur> ListCoureur { get => _listCoureur; set { _listCoureur = value; OnPropertyChanged(); } }

        public ListView MaListeView { get; set; }


        public Command btnRetour { get; set; }
        public INavigation Navigation { get; set; }

        public GestionInscriptionViewModel(INavigation navigation,ListView maListeView)
        {
            if (Inscrit == null)
            {
                Inscrit = new Inscription();
                btnRetour = new Command(RetourCommand);
                Navigation = navigation;
                if (ListCoureur == null)
                    ListCoureur = new List<Coureur>();
                //MaListeView = maListeView;
                //MaListeView.ItemsSource = null;
                //MaListeView.ItemsSource = App.Database.GetCoureur();
                ListCoureur = App.Database.GetCoureur();
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
            foreach(Inscription inscript in App.Database.GetInscription())
            {
                if (inscript.IdxCoureur == Inscrit.IdxCoureur && inscript.IdxCourse == NumCourse)
                {
                    ecritOk = false;
                }        
            }
            if (ecritOk == true)
            {    
                App.ListeInscription.Add(Inscrit);
                App.Database.SaveInscription(Inscrit.ToInscriptionBasique());
                App.ListeCoureurs[selecteditem.Num].Einscrit = true;
                //MaListeView.ItemsSource = null;
                //MaListeView.ItemsSource = App.Database.GetCoureur();
                ListCoureur.Where(x => x.Num == selecteditem.Num).FirstOrDefault().Einscrit = true;
                EstIsncrit = "oui";
            }
        }

        public void IntialisationCoureur(int NumCourse)
        {
            foreach (Coureur coureur in App.Database.GetCoureur())
            {
                EstIsncrit = "non";
                App.ListeCoureurs[coureur.Num-1].Einscrit = false;
            }

            foreach (Coureur coureur in App.Database.GetCoureur())
            {
                foreach (Inscription inscript in App.Database.GetInscription())
                {
                    if ((inscript.IdxCoureur == coureur.Num) && (inscript.IdxCourse == NumCourse))
                    {
                        EstIsncrit = "oui";
                        ListCoureur.Where(x => x.Num == coureur.Num).FirstOrDefault().Einscrit = true;
                    }
                }

            }
        }
    }
}
