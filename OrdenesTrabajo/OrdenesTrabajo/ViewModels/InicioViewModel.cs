using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace OrdenesTrabajo.ViewModels
{
    public class InicioViewModel:BaseViewModel
    {

        private ExternoModel externo;
        public ExternoModel Externo { 
            get { return externo;  }
            set { SetValue(ref this.externo, value); }
        }
        private string ingresados;
        public string Ingresados
        {
            get { return ingresados; }
            set { SetValue(ref this.ingresados, value); }
        }

        private string pendientes;
        public string Pendientes
        {
            get { return pendientes; }
            set { SetValue(ref this.pendientes, value); }
        }

        private string solucionados;
        public string Solucionados
        {
            get { return solucionados; }
            set { SetValue(ref this.solucionados, value); }
        }

        private string enviados;
        public string Enviados
        {
            get { return enviados; }
            set { SetValue(ref this.enviados, value); }
        }

        public async void LoadCantIngAsync()
        {
            try
            {
                ServiceOrden sv = new ServiceOrden();
                Response response = await sv.Get("ordenTrabajo/listC/INGRESADO");
            if (!response.IsSuccess)
            {
                // UserDialogs.Instance.HideLoading();
                Console.WriteLine("LoadDataAsync:Message:!response.IsSuccess " + response.Message);
                    Ingresados = "0";
                }
            Console.WriteLine("LoadDataAsync:Message " + response.Message);
            var resultado = JsonConvert.DeserializeObject<Resultado>(response.Message);
                Console.WriteLine("RES: " + resultado.body);
                Ingresados = resultado.body.ToString();
            //UserDialogs.Instance.HideLoading();

            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.HideLoading();
                Console.WriteLine("Error in MyFile LoadData: " + ex.Message);
                Ingresados = "0";

            }
        }

        public async void LoadCantPenAsync()
        {
            try
            {
                ServiceOrden sv = new ServiceOrden();
                Response response = await sv.Get("ordenTrabajo/listC/PENDIENTE");
                if (!response.IsSuccess)
                {
                    // UserDialogs.Instance.HideLoading();
                    Console.WriteLine("LoadDataAsync:Message:!response.IsSuccess " + response.Message);
                    Pendientes = "0";
                }
                Console.WriteLine("LoadDataAsync:Message " + response.Message);
                var resultado = JsonConvert.DeserializeObject<Resultado>(response.Message);
                Console.WriteLine("RES: " + resultado.body);
                Pendientes = resultado.body.ToString();
                //UserDialogs.Instance.HideLoading();

            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.HideLoading();
                Console.WriteLine("Error in MyFile LoadData: " + ex.Message);
                Pendientes = "0";

            }
        }

        public async void LoadCantSolAsync()
        {
            try
            {
                ServiceOrden sv = new ServiceOrden();
                Response response = await sv.Get("ordenTrabajo/listC/SOLUCIONADO");
                if (!response.IsSuccess)
                {
                    // UserDialogs.Instance.HideLoading();
                    Console.WriteLine("LoadDataAsync:Message:!response.IsSuccess " + response.Message);
                    Solucionados = "0";
                }
                Console.WriteLine("LoadDataAsync:Message " + response.Message);
                var resultado = JsonConvert.DeserializeObject<Resultado>(response.Message);
                Console.WriteLine("RES: " + resultado.body);
                Solucionados = resultado.body.ToString();
                //UserDialogs.Instance.HideLoading();

            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.HideLoading();
                Console.WriteLine("Error in MyFile LoadData: " + ex.Message);
                Solucionados = "0";

            }
        }

        public async void LoadCantEnvAsync()
        {
            try
            {
                ServiceOrden sv = new ServiceOrden();
                Response response = await sv.Get("ordenTrabajo/listC/ENVIADO");
                if (!response.IsSuccess)
                {
                    // UserDialogs.Instance.HideLoading();
                    Console.WriteLine("LoadDataAsync:Message:!response.IsSuccess " + response.Message);
                    Enviados = "0";
                }
                Console.WriteLine("LoadDataAsync:Message " + response.Message);
                var resultado = JsonConvert.DeserializeObject<Resultado>(response.Message);
                Console.WriteLine("RES: " + resultado.body);
                Enviados = resultado.body.ToString();
                //UserDialogs.Instance.HideLoading();

            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.HideLoading();
                Console.WriteLine("Error in MyFile LoadData: " + ex.Message);
                Enviados = "0";

            }
        }

        public async void LoadDataAsync()
        {
            try
            {
                //UserDialogs.Instance.ShowLoading("Cargando...", MaskType.Black);
                ServiceExt service = new ServiceExt();
                Response response = await service.Get("");
                if (!response.IsSuccess)
                {
                   // UserDialogs.Instance.HideLoading();
                    Console.WriteLine("LoadDataAsync:Message:!response.IsSuccess " + response.Message);
                    Externo = new ExternoModel();
                    
                }

               Console.WriteLine("LoadDataAsync:Message " + response.Message);
                var externoModel = JsonConvert.DeserializeObject<ExternoModel>(response.Message);
                //UserDialogs.Instance.HideLoading();
                Externo = externoModel;
                Console.WriteLine("1 " + Externo.Country);


            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.HideLoading();
                Console.WriteLine("Error in MyFile LoadData: " + ex.Message);
                Externo = new ExternoModel();
              
            }
        }

    }
}
