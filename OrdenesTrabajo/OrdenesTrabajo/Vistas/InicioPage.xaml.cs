using OrdenesTrabajo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {

        private InicioViewModel _viewModel;

        public InicioPage()
        {
            InitializeComponent();
            _viewModel = new InicioViewModel();
            BindingContext = _viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadDataAsync();
            _viewModel.LoadCantIngAsync();
            _viewModel.LoadCantPenAsync();
            _viewModel.LoadCantSolAsync();
            _viewModel.LoadCantEnvAsync(); 
        }
    }
}