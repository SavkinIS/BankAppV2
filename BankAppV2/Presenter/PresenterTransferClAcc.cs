using BankAppV2.HelperClass;
using BankAppV2.Model;
using BankAppV2.View;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankAppV2.Presenter
{
    class PresenterTransferClAcc
    {
        IViewTransferClientsAcc view;
        ModelTransAllCl mt;
       

        public PresenterTransferClAcc(IViewTransferClientsAcc view)
        {
            this.view = view;
            mt = new ModelTransAllCl();
        }



        /// <summary>
        /// Ввалидация ввода на цифры
        /// </summary>
        internal void Validation(KeyEventArgs e, object s)
        {

            mt.Validation(e, s);
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void Loader()
        {
            mt.Loader(view);
        }

        /// <summary>
        /// отображает счета клинта
        /// </summary>
        /// <param name="numCl">Клиент</param>
        /// <param name="status">Счет</param>
        /// <returns></returns>
        public List<string> CashList(string numCl, string status)
        {
            return mt.CashList(numCl, status, view);
        }


        /// <summary>
        /// Отображает сумму на счете
        /// </summary>
        public void TakeFinance()
        {
            mt.TakeFinance(view);
        }


        /// <summary>
        /// Перевод между счетами
        /// </summary>
        public void Trans()
        {
            mt.Trans(view);            
        }


        /// <summary>
        /// Проверяет на наличее счета
        /// </summary>
        public void Verify ()
        {
            mt.Verify(view);
        }


    }
}
