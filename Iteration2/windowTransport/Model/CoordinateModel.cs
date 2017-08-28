using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.ComponentModel;



namespace windowTransport.Model
{
    class CoordinateModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String lat;
        private String longitude;
        private String dist;

        public String Lat
        {
            get
            {
                return lat;
            }

            set
            {
                if (lat != value)
                {
                    lat = value;
                    RaisePropertyChanged("Lat");
                }
            }
        }

        public String Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    RaisePropertyChanged("Longitude");
                }
            }
        }

        public String Dist
        {
            get
            {
                return dist;
            }

            set
            {
                if (dist != value)
                {
                    dist = value;
                    RaisePropertyChanged("Dist");
                }
            }
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
