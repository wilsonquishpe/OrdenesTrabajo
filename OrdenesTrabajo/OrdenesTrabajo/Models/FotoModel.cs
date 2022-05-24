using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace OrdenesTrabajo.Models
{
    public class FotoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        string photoPath;
        public string PhotoPath
        {
            get => photoPath;
            set
            {
                if (photoPath == value)
                    return;
                photoPath = value;
                OnPropertyChanged();
            }
        }

    }
}
