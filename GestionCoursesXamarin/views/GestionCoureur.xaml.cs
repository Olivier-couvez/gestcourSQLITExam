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
    public partial class GestionCoureur : ContentPage
    {
        public GestionCoureur()
        {
            InitializeComponent();
            BindingContext = new GestionCoureursViewModel(Navigation);
        }
    }
}