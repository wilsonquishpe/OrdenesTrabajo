using Acr.UserDialogs;
using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using OrdenesTrabajo.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ordenes : ContentPage
    {
        
        public Ordenes()
        {
            InitializeComponent();
            BindingContext = new FotoViewModel();
            _ = CargarClientesAsync();
            _ = CargarCatalogosAsync();
           
            
            
        }

        public async Task CargarClientesAsync()
        {
            List<Cliente> lstClientes = new List<Cliente>();
            lstClientes.Clear();
            Resultado resul = new Resultado();
            resul = await ServiceRest.GetListClientes();
            lstClientes = JsonConvert.DeserializeObject<List<Cliente>>(resul.body.ToString());
            pickerCliente.ItemsSource = lstClientes;
        }

        public async Task CargarCatalogosAsync()
        {
            List<Catalogo> lstCatalogoEquipos = new List<Catalogo>();
            lstCatalogoEquipos.Clear();
            ServiceRest service = new ServiceRest();
            Resultado resul = new Resultado();
            resul = await service.GetCatalogoByTipo("equipo");
            lstCatalogoEquipos = JsonConvert.DeserializeObject<List<Catalogo>>(resul.body.ToString());
            pickerTipo.ItemsSource = lstCatalogoEquipos;
            
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            try {

                Cliente cl = new Cliente();
                Catalogo ca = new Catalogo();
                cl = (Cliente)pickerCliente.SelectedItem;
                ca = (Catalogo)pickerTipo.SelectedItem;
                Debug.WriteLine("save " + cl.id);
                Debug.WriteLine("save " + ca.id);
                OrdenTrabajo ordenTrabajo = new OrdenTrabajo
                {
                    serial = txtSerial.Text,
                    brand = txtMarca.Text,
                    model = txtModelo.Text,
                    description = txtDescripcion.Text,
                    idClient = cl.id,
                    type = ca.value.ToString(),
                    idUser = null,
                    solution = "",
                    status = "INGRESADO",
                    online = true
                };

                ServiceRest service = new ServiceRest();
                Resultado resul = new Resultado();
                resul = await service.SaveOrdenTrabajo(ordenTrabajo);
                Debug.WriteLine("resul: " + resul);
                UserDialogs.Instance.HideLoading();

            }
            catch(Exception ex) { 

               Debug.WriteLine(ex.ToString());

            }

            



        }
    }
}