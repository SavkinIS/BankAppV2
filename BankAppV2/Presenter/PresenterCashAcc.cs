using BankAppV2.HelperClass;
using BankAppV2.Model;
using BankAppV2.View;
using BankAppV2.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.Presenter
{
    class PresenterCashAcc
    {

        IViewCashApp view;

        ModelCashAcc mc;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public PresenterCashAcc(IViewCashApp view)
        {
            this.view = view;
            mc = new ModelCashAcc();
        }
        /// <summary>
        /// Загружает таблицу при загрузке окна
        /// </summary>
        /// <returns></returns>
        public List<CashAccounts> Loader()
        {

            return mc.Loader(view);
        }

        /// <summary>
        /// Создать новый счет
        /// </summary>
        public void NewCashAcc()
        {

            mc.NewCashAcc(view);

        }

        

        /// <summary>
        /// Расчитать кредит
        /// </summary>
        public void CreateCredit()
        {
            mc.CreateCredit(view);
        }

        /// <summary>
        /// открыть вклад
        /// </summary>
        public void OpenDeposit()
        {
            mc.OpenDeposit(view);
        }

        /// <summary>
        /// ПереводМежду своими счетами
        /// </summary>
        public void TransClientsCashAcc()
        {
            mc.TransClientsCashAcc(view);
        }

        /// <summary>
        /// Перевод другим клиентам
        /// </summary>
        public void TarnsOtherClients()
        {
            mc.TarnsOtherClients(view);
        }

        /// <summary>
        /// Удалить счет
        /// </summary>
        public void DeleteCashAcc()
        {
            mc.DeleteCashAcc(view);
        }


      
    }
}
