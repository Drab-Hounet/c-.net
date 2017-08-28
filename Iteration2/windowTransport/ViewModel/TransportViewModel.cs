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
        private Double longitude;

        public Double Longitude
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


        private ICommand GetcoordinatesGPS { get; set; }

        public TransportViewModel()
        {
            GetcoordinatesGPS = new RelayCommand(ChangeCanExecute);
        }

        public bool CanExecute
        {
            get
            {
                return true;
            }

            set { }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            {
                return GetcoordinatesGPS;
            }
            set
            {
            }
        }

        public void ChangeCanExecute(object obj)
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

        public ObservableCollection<Transport_model> TransportsObservable
        {
            get;
            set;
        }

        public void LoadTransport()
        {
            List<TransportComplete> listTransports;
            Transport transport = new Transport();
            listTransports = api.GetAllTransportFromJson(5.63118, 45.287448, 700);

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
