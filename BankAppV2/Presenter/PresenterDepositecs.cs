using BankAppV2.HelperClass;
using BankAppV2.Model;
using BankAppV2.View;
using BankAppV2.Windows;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.Presenter
{
    class PresenterDepositecs
    {
        IViewDeposite view;
        ModelDepos md;

       internal List<string> li = new List<string> { "Ежегодная капитализация", "Ежемесячная капитализация" };

        public PresenterDepositecs(IViewDeposite view)
        {
            this.view = view;
            md = new ModelDepos();
        }


        /// <summary>
        ///  открыть вклад
        /// </summary>
        /// <param name="numCl">номер документа клиента</param>
        /// <param name="status">Статус клиента </param>
        internal void Open(string numCl, string status)
        {
            md.Open(numCl, status, view);
        }

        /// <summary>
        /// расчитать Вклад
        /// </summary>
        internal void Conculate()
        {
            md.Conculate(view);
        }

        /// <summary>
        /// Загрузка даных 
        /// </summary>
        /// <param name="numCl"></param>
        /// <param name="status"></param>
        internal void Loader(string numCl, string status)
        {
            md.Loader(numCl, status, view);
        }



    }
}
