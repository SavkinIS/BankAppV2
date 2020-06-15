using BankAppV2.View;
using BankAppV2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.Model
{
    class ModelRequest
    {
        public ModelRequest()
        {
        }
        public void Open(IViewRequest view)
        {
            if (view.NumInn == "")
            {
                CashWin cash = new CashWin(view.Status, view.NumPass);
                cash.ShowDialog();
            }
            else if (view.NumPass == "")
            {
                CashWin cash = new CashWin(view.Status, view.NumInn);
                cash.ShowDialog();
            }


        }
    }
}
