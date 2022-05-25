using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OrdenesTrabajo.Vistas;
using Xamarin.Essentials;

namespace OrdenesTrabajo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Preferences.Get("isLogged",false))
            {
                MainPage = new MenuPage();
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
     
                
            

            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
