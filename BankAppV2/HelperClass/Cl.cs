using BankAppV2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.HelperClass
{
    public class Cl
    {
        public static void Close(object win)
        {
           
            foreach (Window window in App.Current.Windows)
            {
                if (window == win)
                    window.Close();
            }
        }
    }
}
