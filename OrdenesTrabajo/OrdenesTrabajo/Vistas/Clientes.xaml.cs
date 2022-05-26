using Acr.UserDialogs;
using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clientes : ContentPage
    {
        public Clientes()
        {
            InitializeComponent();
            _ = CargarCatalogosAsync();
        }

        public async Task CargarCatalogosAsync()
        {
            List<Catalogo> lstCatalogoEquipos = new List<Catalogo>();
            lstCatalogoEquipos.Clear();
            ServiceRest service = new ServiceRest();
            Resultado resul = new Resultado();
            resul = await service.GetCatalogoByTipo("documento");
            lstCatalogoEquipos = JsonConvert.DeserializeObject<List<Catalogo>>(resul.body.ToString());
            pickerIdentificacion.ItemsSource = lstCatalogoEquipos;

        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            try {
                UserDialogs.Instance.ShowLoading("Guardando...", MaskType.Black);
                Catalogo ca = new Catalogo();
                ca = (Catalogo)pickerIdentificacion.SelectedItem;
                Cliente cliente = new Cliente
                {
                    online = true,
                    email = txtEmail.Text,
                    address = txtDireccion.Text,
                    document = txtDocumento.Text,
                    typeDocument = ca.value.ToString(),
                    firstName = txtNombres.Text,
                    lastName = txtApellidos.Text,
                    phoneNumber = txtTelefono.Text
                };

                ServiceRest service = new ServiceRest();
                Resultado resul = new Resultado();
                resul = await service.SaveCliente(cliente);
                Debug.WriteLine("resul: " + resul);
                if(resul.ok)
                {
                    UserDialogs.Instance.HideLoading();
                    await Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "El cliente ya se encuentra registrado", "Aceptar");
                    UserDialogs.Instance.HideLoading();
                }

            } catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                UserDialogs.Instance.HideLoading();
            }


        }
    }
}