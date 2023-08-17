using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace b1_task2.WPF.Models
{
    public class BankAccountNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int accountNumber)
            {
                if (accountNumber >= 1 && accountNumber <= 9)
                {
                    return $"ПО КЛАССУ";
                }
                if(accountNumber == 0) return $"БАЛАНС";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
