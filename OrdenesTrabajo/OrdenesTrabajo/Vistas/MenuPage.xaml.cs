using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrdenesTrabajo.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : FlyoutPage
    {
        public List<MenuItemsModel> menuItems;
        public MenuPage(Page page = null)
        {
            InitializeComponent();
            myPageMain();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void myPageMain()
        {

            Detail = new NavigationPage(new InicioPage());

            menuItems = new List<MenuItemsModel> { };

            menuItems.Add(new MenuItemsModel { page = typeof(InicioPage), Titulo = "Inicio", Icono="entrega.png" });
            menuItems.Add(new MenuItemsModel { page = typeof(Ordenes), Titulo = "Ingresar Orden", Icono = "documento.png" });
            menuItems.Add(new MenuItemsModel { page = typeof(ListClientes), Titulo = "Clientes", Icono = "seguro.png" });
            menuItems.Add(new MenuItemsModel { page = typeof(Reportes), Titulo = "Ordenes", Icono = "certificado.png" });
            menuItems.Add(new MenuItemsModel { page = null, Titulo = "Cerrar Sesión", Icono = "avion.png" });

            listPageMain.ItemsSource = menuItems;

        }

        private async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var option = e.SelectedItem as MenuItemsModel;

            try
            {

                if (option.page != null)
                {
                    IsPresented = false;
                    Detail = new NavigationPage((Page)Activator.CreateInstance(option.page));
                }
                else if (option.Titulo == "Cerrar Sesión")
                {

                    var result = await DisplayAlert("Confirmar", "¿Estás seguro de cerrar sesión?", "Sí", "No");
                    if (result)
                    {
                        Preferences.Set("isLogged", false);
                        Application.Current.MainPage = new Login();

                    }
                }

                await Task.Delay(200);

                listPageMain.SelectedItem = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}