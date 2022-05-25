using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace OrdenesTrabajo.Models
{
    public class ExternoModel : INotifyPropertyChanged
    {
        private string organization_name;
        private string area_code;
        private string city;
        private string country;
        private string country_code3;
        private string continent_code;
        private int asn;
        private string region;
        private string latitude;
        private string longitude;
        private int accuracy;
        private string ip;
        private string timezone;
        private string organization;
        private string country_code;

        public string Organization_name { get { return organization_name; }
            set { organization_name = value;
                OnPropertyChanged();
            } 
        }
        public string Area_code
        {
            get { return area_code; }
            set
            {
                area_code = value;
                OnPropertyChanged();
            }
        }
        public string City {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }
        public string Country_code3 {
            get { return country_code3; }
            set
            {
                country_code3 = value;
                OnPropertyChanged();
            }
        }
        public string Continent_code {
            get { return continent_code; }
            set
            {
                continent_code = value;
                OnPropertyChanged();
            }
        }
        public int Asn {
            get { return asn; }
            set
            {
                asn = value;
                OnPropertyChanged();
            }
        }
        public string Region {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged();
            }
        }
        public string Latitude {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged();
            }
        }
        public string Longitude {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged();
            }
        }
        public int Accuracy {
            get { return accuracy; }
            set
            {
                accuracy = value;
                OnPropertyChanged();
            }
        }
        public string Ip {
            get { return ip; }
            set
            {
                ip = value;
                OnPropertyChanged();
            }
        }
        public string Timezone {
            get { return timezone; }
            set
            {
                timezone = value;
                OnPropertyChanged();
            }
        }
        public string Organization {
            get { return organization; }
            set
            {
                organization = value;
                OnPropertyChanged();
            }
        }
        public string Country_code {
            get { return country_code; }
            set
            {
                country_code = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
