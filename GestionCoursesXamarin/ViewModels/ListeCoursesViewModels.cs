using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GestionCoursesXamarin.ViewModels
{
    public class ListeCoursesViewModels : BindableObject
    {
        private List<Course> _courses;
        public List<Course> ListCourses { get => _courses; set { _courses = value; OnPropertyChanged(); } }

        private List<Coureur> _coureur;
        public List<Coureur> ListCoureurs { get => _coureur; set { _coureur = value; OnPropertyChanged(); } }

        public Command AddCoureur {get; set;}
        public Command AddCourse { get; set; }

        public INavigation Navigation { get; set; }
        public ListView MaListeView { get; set; }

        public ListeCoursesViewModels(INavigation navigation, ListView maListView)
        {
            if (ListCourses == null)
            {
                ListCourses = new List<Course>();
            }
            ListCourses = App.Database.GetCourse();

            AddCoureur = new Command(AddCoureurAction);
            AddCourse = new Command(AddCourseAction);
            Navigation = navigation;
            MaListeView = maListView;
            MaListeView.ItemsSource = null;
            MaListeView.ItemsSource = App.Database.GetCourse();
        }

        

        private void AddCoureurAction()
        {
            Navigation.PushModalAsync(new GestionCoureur());
        }

        private void AddCourseAction()
        {
            Navigation.PushModalAsync(new GestionCourses(MaListeView));
            MaListeView.ItemsSource = null;
            MaListeView.ItemsSource = App.Database.GetCourse();
        }

        public void OuvrirFenInscription(ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new GestionInscription(e));
        }
    }
}
