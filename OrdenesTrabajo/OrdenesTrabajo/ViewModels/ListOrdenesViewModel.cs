using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace OrdenesTrabajo.ViewModels
{
    public class ListOrdenesViewModel:BaseViewModel
    {
        private ObservableCollection<OrdenTrabajo> ordenes;

        public INavigation Navigation;
        public ObservableCollection<OrdenTrabajo> Ordenes
        {
            get { return ordenes; }
            set { SetValue(ref this.ordenes, value); }
        }

        public async void LoadData()
        {
            _ = new Resultado();
            Resultado resul = await ServiceRest.GetListOrdenes();
            List<OrdenTrabajo> lista = JsonConvert.DeserializeObject<List<OrdenTrabajo>>(resul.body.ToString());
            Ordenes = new ObservableCollection<OrdenTrabajo>(lista);
        }
    }
}
