using Newtonsoft.Json;
using OrdenesTrabajo.Data;
using OrdenesTrabajo.Models;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OrdenesTrabajo.ViewModels
{
    public class FotoViewModel : FotoModel
    {

        public Command CapturarComando { get; set; }
        public string toBase64;

        public FotoViewModel()
        {
            CapturarComando = new Command(OnTakePhoto);

        }

        async void OnTakePhoto()
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            await LoadPhotoAsync(photo);
        }

        public void AddPhotoAsync()
        {
            Debug.WriteLine("LLegue a AddPhoto " + this.toBase64);
        }

        async Task ConvertPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            {
                using (var newStream = File.OpenWrite(newFile))
                {
                    await stream.CopyToAsync(newStream);

                }
            }
            PhotoPath = newFile;
        }
        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                return;
            }


            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            {
                using (var newStream = File.OpenWrite(newFile))
                {
                    await stream.CopyToAsync(newStream);
                    var bytes = new Byte[(int)stream.Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(bytes, 0, (int)stream.Length);
                    toBase64 = Convert.ToBase64String(bytes);
                    Debug.WriteLine("---- : " + toBase64);

                }
            }

        }


    }
}
