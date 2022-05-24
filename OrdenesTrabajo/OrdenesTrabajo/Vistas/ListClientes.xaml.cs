using OrdenesTrabajo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListClientes : ContentPage
    {
        private ListClientesViewModel _viewModel;

        public ListClientes()
        {
            InitializeComponent();

            _viewModel = new ListClientesViewModel()
            {
                Navigation = Navigation
            };
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadData();

        }



    }
}