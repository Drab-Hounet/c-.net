using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace windowTransport.Converter
{
    class Substring : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String text = (String) value;
            String[] temp = text.Split(',');
            if(temp.Length == 1)
            {
                text = temp[0];
            }
            else
            {
                text = temp[1];
            }
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
