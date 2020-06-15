using BankAppV2.HelperClass;
using BankAppV2.Model;
using BankAppV2.View;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankAppV2.Presenter
{
    class PresenterAddClient
    {
       internal ClientStatuses clStat = new ClientStatuses();
        
        IViewAddClient view;
        ModelAddClient ma ;
        string oldnum = "";

        public PresenterAddClient(IViewAddClient view)
        {
            this.view = view;
            oldnum = this.view.cl.Passport;
            ma = new ModelAddClient();
        }

        /// <summary>
        /// Ввалидация ввода на цифры
        /// </summary>
        internal void Validinput(KeyEventArgs e, object s) 
        {

            ma.Validinput(e, s);
        }


        /// <summary>
        ///Проверка номера документа на совпадение
        /// </summary>
        internal void Check()
        {
            ma.Check(view, oldnum);
        }


        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void AdressLostFocus()
        {
            ma.AdressLostFocus(view);
        }

        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void WorkPlaceLostFocus()
        {
            ma.WorkPlaceLostFocus(view);
        }

        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void NumDocLostFocus()
        {
            ma.NumDocLostFocus(view);
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        public void AddClient()
        {
            ma.AddClient(view);
        }

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public void Change()
        {
            ma.Change(view, oldnum);
        }

        /// <summary>
        /// Заполняет значения при загрузке
        /// </summary>
        public void Loader()
        {
            ma.Loader(view);
        }

    }
}
