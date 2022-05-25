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
    public class ListCatalogoViewModel:BaseViewModel
    {

        public INavigation Navigation;

        private ObservableCollection<Catalogo> catalogos;

        public ObservableCollection<Catalogo> Catalogos
        {
            get { return catalogos; }
            set { SetValue(ref this.catalogos, value); }
        }

        public ListCatalogoViewModel()
        {
           
        }

        public async void LoadData()
        {
            _ = new Resultado();
            Resultado resul = await ServiceRest.GetListCatalogos();
            List<Catalogo> lista = JsonConvert.DeserializeObject<List<Catalogo>>(resul.body.ToString());
            Catalogos = new ObservableCollection<Catalogo>(lista);
        }


    }
}
