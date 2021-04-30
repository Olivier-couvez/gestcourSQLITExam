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


    public partial class GestionCourses : ContentPage
    {
        public ListView Malisteview { get; set; }
        public GestionCourses(ListView maListeView)
        {
            InitializeComponent();
            Malisteview = maListeView;
            BindingContext = new GestionCoursesViewModel(Navigation, Malisteview);
        }
    }
}