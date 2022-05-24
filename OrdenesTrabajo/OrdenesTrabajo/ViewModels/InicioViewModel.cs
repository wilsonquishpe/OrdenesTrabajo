using Acr.UserDialogs;
using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesTrabajo.ViewModels
{
    public class InicioViewModel:BaseViewModel
    {

        private ExternoModel externo;

        public ExternoModel Externo
        {
            get { return externo; }
        }

        public ExternoModel GetExterno()
        {
            return Externo;
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
                    //Console.WriteLine("LoadDataAsync:Message:!response.IsSuccess " + response.Message);
                    externo = new ExternoModel();
                    
                }

                //Console.WriteLine("LoadDataAsync:Message " + response.Message);
                var externoModel = JsonConvert.DeserializeObject<ExternoModel>(response.Message);
                //UserDialogs.Instance.HideLoading();
                externo = externoModel;
                
            }
            catch (Exception ex)
            {
                //UserDialogs.Instance.HideLoading();
                //Console.WriteLine("Error in MyFile LoadData: " + ex.Message);
                externo = new ExternoModel();
              
            }
        }

    }
}
