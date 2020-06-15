using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankAppV2.HelperClass
{
   public class Validators
    {

        public static void Validinput(KeyEventArgs e, object s)
        {
            char input = 'a';

            try
            {
                input = e.Key.ToString().Last();
                var x = e.Key;
                if (!Char.IsDigit(input) || e.Key.ToString() == "Back" || e.Key.ToString() == "Left" || e.Key.ToString() == "Right" || e.Key.ToString() == "Tab"
                    || e.Key.ToString() == "Delete")
                {
                    if (e.Key.ToString() != "Back" && e.Key.ToString() != "Left" && e.Key.ToString() != "Right" && e.Key.ToString() != "Tab"&& e.Key.ToString() != "Delete")
                    {
                        e.Handled = true;
                    }


                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



            // MessageBox.Show(e.Key.ToString());

        }
    }
}
