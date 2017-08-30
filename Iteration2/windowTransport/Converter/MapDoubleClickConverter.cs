using GalaSoft.MvvmLight.Command;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace windowTransport.Converter
{
    public class MapDoubleClickConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            MouseButtonEventArgs eventArgs = value as MouseButtonEventArgs;
            Map map = parameter as Map;
            if (eventArgs != null && map != null)
            {
                //Convert the mouse coordinates to a locatoin on the map
                return map.ViewportPointToLocation(eventArgs.GetPosition(map));
            }

            return new Location();
        }
    }
}
