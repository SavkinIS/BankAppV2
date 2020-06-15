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
    class PresenterCredit
    {
        IViewCredit view;
        ModelCredit mc;
        
        /// <summary>
        /// Стандартная ставка для всех
        /// </summary>
        double procents = 16;
        bool flag = false;

        public PresenterCredit(IViewCredit view)
        {
            this.view = view;
            mc = new ModelCredit();
        }

        /// <summary>
        /// Заполненеие при загрузке
        /// </summary>
        /// <param name="num"></param>
        /// <param name="status"></param>
        public void Loader(string num, string status)
        {
            mc.Loader(num, status, view);
        }

        /// <summary>
        /// Ввалидация ввода на цифры
        /// </summary>
        internal void Validation(KeyEventArgs e, object s)
        {
            mc.Validation(e, s);
        }

        /// <summary>
        /// Выдача кредита
        /// </summary>
        /// <param name="num"></param>
        /// <param name="status"></param>
        internal void Give(string num, string status)
        {
            mc.Give(num, status, view);
        }

        /// <summary>
        /// Расчитывает кредит
        /// </summary>
        internal void Calculate()
        {
            mc.Calculate(view);
        }
    }
}
