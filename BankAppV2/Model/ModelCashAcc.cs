using BankAppV2.HelperClass;
using BankAppV2.View;
using BankAppV2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.Model
{
   
    class ModelCashAcc
    {
        EFData my;

        public ModelCashAcc()
        {
            my = new EFData();
        }

        /// <summary>
        /// Загружает таблицу при загрузке окна
        /// </summary>
        /// <returns></returns>
        public List<CashAccounts> Loader(IViewCashApp view)
        {

            return my.PrintClientCash(view.Status, view.NumPassOrInn);
        }

        /// <summary>
        /// Создать новый счет
        /// </summary>
        public void NewCashAcc(IViewCashApp view)
        {

            my.NewCashAcc(view.Status, view.NumPassOrInn);
            UpViewDt(view);

        }



        /// <summary>
        /// Расчитать кредит
        /// </summary>
        public void CreateCredit(IViewCashApp view)
        {
            CreditWin credit = new CreditWin(view.NumPassOrInn, view.Status);
            credit.ShowDialog();
            UpViewDt(view);
        }

        /// <summary>
        /// открыть вклад
        /// </summary>
        public void OpenDeposit(IViewCashApp view)
        {
            DepositeWin dep = new DepositeWin(view.NumPassOrInn, view.Status);
            dep.ShowDialog();
            my = new EFData();
            UpViewDt(view);
        }

        /// <summary>
        /// ПереводМежду своими счетами
        /// </summary>
        public void TransClientsCashAcc(IViewCashApp view)
        {
            TransferClientsAccounts_Win tr = new TransferClientsAccounts_Win(view.CashNum, view.NumPassOrInn, view.Status);
            tr.ShowDialog();
            my = new EFData();
            UpViewDt(view);
        }

        /// <summary>
        /// Перевод другим клиентам
        /// </summary>
        public void TarnsOtherClients(IViewCashApp view)
        {
            TransferAllClients trAll = new TransferAllClients(view.CashNum, view.NumPassOrInn, view.Status);
            trAll.ShowDialog();
            my = new EFData();
            UpViewDt(view);
        }

        /// <summary>
        /// Удалить счет
        /// </summary>
        public void DeleteCashAcc(IViewCashApp view)
        {
            my.DeleteCashAcc(view.CashNum);
            my = new EFData();
            UpViewDt(view);
        }


        #region Helpers
        /// <summary>
        /// Обновляет  view.dataTable
        /// </summary>
        private void UpViewDt(IViewCashApp view)
        {
            my = new EFData();
            view.dataTable = my.PrintClientCash(view.Status, view.NumPassOrInn);
        }
        #endregion
    }
}
