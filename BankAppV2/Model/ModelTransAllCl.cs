using BankAppV2.HelperClass;
using BankAppV2.View;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankAppV2.Model
{
    class ModelTransAllCl
    {
        EFData my;
        public ModelTransAllCl()
        {
            my = new EFData();
        }

        /// <summary>
        /// Ввалидация ввода на цифры
        /// </summary>
        internal void Validation(KeyEventArgs e, object s)
        {

            Validators.Validinput(e, s);
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        public void Loader(IViewTransferClientsAcc view)
        {
            view.CurentFinance = my.FinanceOnAcc(view.CurentAcc);
        }

        /// <summary>
        /// отображает счета клинта
        /// </summary>
        /// <param name="numCl">Клиент</param>
        /// <param name="status">Счет</param>
        /// <returns></returns>
        public List<string> CashList(string numCl, string status, IViewTransferClientsAcc view)
        {
            List<string> li = new List<string>();
            li = my.ClientCashAcc(numCl, status);
            li.Remove(view.CurentAcc);
            return li;

        }


        /// <summary>
        /// Отображает сумму на счете
        /// </summary>
        public void TakeFinance(IViewTransferClientsAcc view)
        {
            view.SelectedFinance = my.FinanceOnAcc(view.SelectedAcc);
        }


        /// <summary>
        /// Перевод между счетами
        /// </summary>
        public void Trans(IViewTransferClientsAcc view)
        {
            string a = view.CurentFinance;
            string b = view.SelectedFinance;
            string sum = view.SumTransfer;


            if (sum.ToDouble() < a.ToDouble())
            {
                view.CurentFinance = a.SubDouble(sum);
                view.SelectedFinance = b.SumDouble(sum);

                my.TransferClientsAcc(view.CurentAcc, view.CurentFinance, view.SelectedAcc, view.SelectedFinance);


            }
            else { MessageBox.Show("Вы ввели некоректные данные"); }
            view.SumTransfer = "";
        }


        /// <summary>
        /// Проверяет на наличее счета
        /// </summary>
        public void Verify(IViewTransferClientsAcc view)
        {
            if (!my.NeedCashAcc(view.SelectedAcc))
            {
                view.SelectedAcc = "";
                MessageBox.Show("Такого счета не сущуствует!");
            }
            else { view.SelectedFinance = my.FinanceOnAcc(view.SelectedAcc); }
        }


    }
}
