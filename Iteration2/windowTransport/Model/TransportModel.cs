using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Library;

namespace windowTransport.Model
{
    public class Transport_model : INotifyPropertyChanged
    {
        private String name;
        private List<Line> listLines;

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }

}
