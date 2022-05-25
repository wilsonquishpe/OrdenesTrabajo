using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using OrdenesTrabajo.Vistas;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace OrdenesTrabajo.ViewModels
{
    public class ListClientesViewModel:BaseViewModel
    {

        public INavigation Navigation;

        private ObservableCollection<Cliente> clientes;

        public ObservableCollection<Cliente> Clientes
        {
            get { return clientes; }
            set { SetValue(ref this.clientes, value); }
        }
        
        public Command AddCommand { get; set; }

        public ListClientesViewModel()
        {
            AddCommand = new Command(AddMethod);
        }

        public async void LoadData()
        {
            _ = new Resultado();
            Resultado resul = await ServiceRest.GetListClientes();
            List<Cliente> lista = JsonConvert.DeserializeObject<List<Cliente>>(resul.body.ToString());
            Clientes = new ObservableCollection<Cliente>(lista);
        }

        private void AddMethod()
        {
            if (Navigation != null)
                Navigation.PushAsync(new Clientes());
        }
    }
}
