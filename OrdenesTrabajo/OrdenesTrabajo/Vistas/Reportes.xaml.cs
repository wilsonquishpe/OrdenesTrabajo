using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using OrdenesTrabajo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reportes : ContentPage
    {
        private ListOrdenesViewModel _viewModel;
        public Reportes()
        {
            InitializeComponent();
            _viewModel = new ListOrdenesViewModel();
            BindingContext = _viewModel;
          
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _viewModel.LoadData();

        }
    }
}