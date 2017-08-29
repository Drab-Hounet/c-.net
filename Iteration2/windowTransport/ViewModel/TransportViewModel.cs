using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowTransport.Model;
using Library;
using System.Diagnostics;
using System.Windows.Input;
using windowTransport.Command;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;



namespace windowTransport.ViewModel
{
    class TransportViewModel : INotifyPropertyChanged
    {
        public List<TransportComplete> listTransports;
        public API api = new API();
        public ObservableCollection<Transport_model> transports = new ObservableCollection<Transport_model>();

        public event PropertyChangedEventHandler PropertyChanged;

        private Double lat;

        public Double Lat
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
        private Double lon;

        public Double Longitude
        {
            get
            {
                return lon;
            }

            set
            {
                if (lon != value)
                {
                    lon = value;
                    RaisePropertyChanged("Longitude");
                }
            }
        }
        private Double dist;

        public Double Dist
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

        private Location locationMap;

        public Location LocationMap
        {
            get
            {
                return locationMap;
            }

            set
            {
                if (locationMap != value)
                {
                    locationMap = value;
                    RaisePropertyChanged("LocationMap");
                }

            }
        }


        private ICommand GetcoordinatesGPS { get; set; }
        private ICommand Test { get; set; }



        public TransportViewModel()
        {
            Test = new RelayCommand(MapExecute);
            GetcoordinatesGPS = new RelayCommand(FormExecute);

        }

        public bool CanExecute
        {
            get
            {
                return true;
            }

            set { }
        }

        public ICommand ValidationForm
        {
            get
            {
                return GetcoordinatesGPS;
            }
            set
            {
            }
        }

        public ICommand DoubleClickPos
        {
            get
            {
                return Test;
            }
            set
            {
            }
        }

        public void FormExecute(object obj)
        {
            TransportsObservable = null;
            Debug.WriteLine(Lat + " " + Longitude + " " + Dist);

            listTransports = api.GetAllTransportFromJson(Lat, Longitude, Dist);

            transports.Clear();
            foreach (TransportComplete tsprt in listTransports)
            {
                transports.Add(new Transport_model { Name = tsprt.Name, ListLines = tsprt.LinesDetails });
            }
            TransportsObservable = transports;
        }

        public void MapExecute(object obj)
        {
            Debug.WriteLine("map");
            Debug.WriteLine(obj);

        }

        public ObservableCollection<Transport_model> TransportsObservable
        {
            get;
            set;
        }

        public void LoadTransport()
        {
            Lat = 45.185697;
            Longitude = 5.728726;
            Dist = 200;
            TransportsObservable = null;
            Debug.WriteLine(Lat + " " + Longitude + " " + Dist);

            listTransports = api.GetAllTransportFromJson(Lat, Longitude, Dist);

            transports.Clear();
            foreach (TransportComplete tsprt in listTransports)
            {
                transports.Add(new Transport_model { Name = tsprt.Name, ListLines = tsprt.LinesDetails });
            }
            TransportsObservable = transports;
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
