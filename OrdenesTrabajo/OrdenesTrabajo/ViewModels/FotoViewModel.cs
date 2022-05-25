using OrdenesTrabajo.Models;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OrdenesTrabajo.ViewModels
{
    public class FotoViewModel : FotoModel
    {

        public Command CapturarComando { get; set; }

        public FotoViewModel()
        {
            CapturarComando = new Command(OnTakePhoto);

        }

        async void OnTakePhoto()
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            await LoadPhotoAsync(photo);
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
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




    }
}
