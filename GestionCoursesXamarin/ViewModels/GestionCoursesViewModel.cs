using GestionCoursesXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using GestionCoursesXamarin.Extension;

namespace GestionCoursesXamarin.ViewModels
{
    class GestionCoursesViewModel : BindableObject
    {
        private Course _course;

        public Course Course { get => _course; set { _course = value; OnPropertyChanged(); } }

        public Command ValiderCourse { get; set; }
        public Command AnnulerCourse { get; set; }

        public ListView Malisteview { get; set; }
        public INavigation Navigation { get; set; }



        public GestionCoursesViewModel(INavigation navigation, ListView maListeView)
        {


            if (Course == null)
            {
                Course = new Course();
                ValiderCourse = new Command(ValiderCourseCommand);
                AnnulerCourse = new Command(AnnulerCourseCommand);
                Malisteview = maListeView;
                Navigation = navigation;
            }
        }

        private void ValiderCourseCommand()
        {
            // test

            if (!string.IsNullOrEmpty(Course.Nom) || !string.IsNullOrEmpty(Course.Lieu) || !string.IsNullOrEmpty(Course.Distance.ToString()))
            {
                Malisteview.ItemsSource = null;
                App.Database.SaveCourse(Course.ToCourseBasique());
                Malisteview.ItemsSource = App.Database.GetCourse();
                Navigation.PopModalAsync();
                Course = new Course();
            }
        }
        private void AnnulerCourseCommand()
        {
            Navigation.PopModalAsync();
        }
    }
}
