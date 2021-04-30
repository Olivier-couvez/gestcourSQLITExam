using GestionCoursesXamarin.ViewModels;
using GestionCoursesXamarin.views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionCoursesXamarin.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeCourses : ContentPage
    {
        public ListeCourses()
        {
            InitializeComponent();
            BindingContext = new ListeCoursesViewModels(Navigation, ListeDesCourses);
    }

        private void ListeDesCourses_ItemTapped(object sender, ItemTappedEventArgs e) 
        {
            ((ListeCoursesViewModels) BindingContext).OuvrirFenInscription(e);
        }

    }
}
