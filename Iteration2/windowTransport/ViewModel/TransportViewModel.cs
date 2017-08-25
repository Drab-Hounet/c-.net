using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowTransport.Model;
using Library;

namespace windowTransport.ViewModel
{
    class TransportViewModel
    {
        public ObservableCollection<Transport_model> TransportsObservable
        {
            get;
            set;
        }

        public void LoadTransport()
        {
            ObservableCollection<Transport_model> transports = new ObservableCollection<Transport_model>();
            Transport transport = new Transport();
            API api = new API();
            List<TransportComplete> listTransports = api.GetAllTransportFromJson(5.63118, 45.287448, 700);

            foreach (TransportComplete tsprt in listTransports)
            {
                transports.Add(new Transport_model { Name = tsprt.Name, ListLines = tsprt.LinesDetails});
                
            }

            TransportsObservable = transports;
        }
    }
}
