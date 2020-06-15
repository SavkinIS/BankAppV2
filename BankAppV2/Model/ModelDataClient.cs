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
    class ModelDataClient
    {
        EFData my ;

        public ModelDataClient()
        {
            my = new EFData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns></returns>
        public List<Client> LoaderData()
        {
            my = new EFData();
            return my.PrintDataClient();
        }

        /// <summary>
        /// открывает счета выбранного клиента
        /// </summary>
        public void OpenClientCash(IViewData view)
        {
            CashWin cw = new CashWin(view.Status, view.NumPassOrInn);
            cw.ShowDialog();
        }

        /// <summary>
        /// удаляет выбранного клиента
        /// </summary>
        public void DeleteClient(IViewData view)
        {
            my.DelClient(view.Status, view.NumPassOrInn);
            view.dataTable = my.PrintDataClient();
        }


        public void ChangeClientInfo(IViewData view)
        {
            ChangeClient cc = new ChangeClient(my.GetClientFromDB(view.NumPassOrInn));
            cc.ShowDialog();
            view.dataTable = LoaderData();
        }
    }
}
