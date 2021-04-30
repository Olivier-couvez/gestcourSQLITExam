using GestionCoursesXamarin.Models;
using GestionCoursesXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionCoursesXamarin.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class GestionInscription : ContentPage
    {
        int numCourses;
        public GestionInscription(ItemTappedEventArgs e)
        {
            InitializeComponent();
            BindingContext = new GestionInscriptionViewModel(Navigation);
            ListeInscriptions.ItemsSource = App.ListeCoureurs;
            var selecteditem = (Course)e.Item;
            numCourses = selecteditem.Num;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((GestionInscriptionViewModel)BindingContext).IntialisationCoureur(numCourses);

        }

        private void ListeInscriptions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((GestionInscriptionViewModel) BindingContext).MajDonnees(e, numCourses);
            
        }
    }
}