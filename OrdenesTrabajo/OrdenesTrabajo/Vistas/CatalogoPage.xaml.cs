using OrdenesTrabajo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogoPage : ContentPage
    {
        private ListCatalogoViewModel _viewModel;
        public CatalogoPage()
        {
            InitializeComponent();
            _viewModel = new ListCatalogoViewModel();
            BindingContext = _viewModel;   
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadData();

        }
    }
}