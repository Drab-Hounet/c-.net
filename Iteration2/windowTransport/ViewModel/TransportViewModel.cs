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
        private List<TransportComplete> listTransports;
        private API api;
        private ObservableCollection<Transport_model> transports;

        public TransportViewModel()
        {
            api = new API();
            transports = new ObservableCollection<Transport_model>();
            DoubleClickPos = new RelayCommand(MapExecute);
            ValidationForm = new RelayCommand(FormExecute);

            SelectedLocation = new Location(45.185697, 5.728726);
            Dist = 500;
            CallApi();
        }

        public void FormExecute(object obj)
        {
            TransportsObservable = null;
            SelectedLocation = new Location(Latitude, Longitude);
            CallApi();
        }

        public void MapExecute(object obj)
        {
            SelectedLocation = obj as Location;
            CallApi();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Public Properties

        private Boolean offLine;
        public Boolean OffLine
        {
            get
            {
                return offLine;
            }

            set
            {
                if (offLine != value)
                {
                    offLine = value;
                    RaisePropertyChanged("OffLine");
                }
            }
        }

        private Double latitude;
        public Double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    SelectedLocation.Latitude = Latitude;
                    RaisePropertyChanged("Latitude");
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
                    SelectedLocation.Longitude = Longitude;
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

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get
            {
                return selectedLocation;
            }
            set
            {
                if (selectedLocation != value)
                {
                    selectedLocation = value;
                    Latitude = selectedLocation.Latitude;
                    Longitude = selectedLocation.Longitude;
                    RaisePropertyChanged("SelectedLocation");
                }
            }
        }

        public ObservableCollection<Transport_model> TransportsObservable
        {
            get;
            set;
        }

        #endregion

        #region Commands

        public ICommand ValidationForm { get; private set; }

        public ICommand DoubleClickPos { get; private set; }

        #endregion

        #region private methods

        private void CallApi()
        {
            TransportsObservable = null;
            api.OffLine = OffLine;

            listTransports = api.GetAllTransportFromJson(SelectedLocation.Latitude, SelectedLocation.Longitude, Dist);

            transports.Clear();
            foreach (TransportComplete tsprt in listTransports)
            {
                transports.Add(new Transport_model { Name = tsprt.Name, TrLatitude = tsprt.Lat, TrLongitude = tsprt.Lon, ListLines = tsprt.LinesDetails });

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

        #endregion
    }
}
