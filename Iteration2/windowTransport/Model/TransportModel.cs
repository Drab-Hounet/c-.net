using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Library;
using Microsoft.Maps.MapControl.WPF;

namespace windowTransport.Model
{
    public class Transport_model : INotifyPropertyChanged
    {
        private String name;
        private List<Line> listLines;
        private Location locationStation;
        private Double trLatitude;
        private Double trLongitude;

        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public Double TrLatitude
        {
            get
            {
                return trLatitude;
            }

            set
            {
                if (trLatitude != value)
                {
                    trLatitude = value;
                    RaisePropertyChanged("TrLatitude");
                }
            }
        }

        public Location LocationStation
        {
            get
            {
                return new Location(TrLatitude, TrLongitude);
            }            
        }

        public Double TrLongitude
        {
            get
            {
                return trLongitude;
            }

            set
            {
                if (trLongitude != value)
                {
                    trLongitude = value;
                    RaisePropertyChanged("TrLongitude");
                }
            }
        }

        public List<Line> ListLines
        {
            get
            {
                return listLines;
            }

            set
            {
                if (listLines != value)
                {
                    listLines = value;
                    RaisePropertyChanged("ListLines");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
