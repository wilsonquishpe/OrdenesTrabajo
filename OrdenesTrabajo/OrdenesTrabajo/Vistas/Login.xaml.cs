using Acr.UserDialogs;
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
    public partial class Login : ContentPage
    {

        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {

            

            try
            {
                UserDialogs.Instance.ShowLoading("Ingresando...", MaskType.Black);
                UserLogin user = new UserLogin { username = txtUser.Text, password = txtPassword.Text };
                ServiceRest serviceRest = new ServiceRest();
                int resultado = await serviceRest.IniciarSesion(user);
                Debug.WriteLine("RESULTADO LOGIN: " + resultado);
                if (resultado > 0)
                {
                    UserDialogs.Instance.HideLoading();
                    Application.Current.MainPage = new MenuPage();
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    await App.Current.MainPage.DisplayAlert("Error", "Usuario o Contraseña incorrectos", "Aceptar");
                    txtPassword.Text = string.Empty;
                }
            } catch(Exception ex) {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
 
        }
    }
}