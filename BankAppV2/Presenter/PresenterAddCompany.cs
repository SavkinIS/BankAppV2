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
    class PresenterAddCompany
    {
       internal ClientStatuses clStat = new ClientStatuses();
       
        IViewAddCompany view;
        string oldnum = "";
        ModelAddCompany mc;


        public PresenterAddCompany(IViewAddCompany view)
        {
            this.view = view;
           oldnum = this.view.co.INN;
            mc = new ModelAddCompany();
        }

        /// <summary>
        /// Ввалидация ввода на цифры
        /// </summary>
        internal void Validinput(KeyEventArgs e, object s) 
        {
           
            Validators.Validinput(e, s);
        }


        /// <summary>
        ///Проверка номера документа на совпадение
        /// </summary>
        internal void Check()
        {
            mc.Check(view, oldnum);
        }


        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void AdressLostFocus()
        {
            mc.AdressLostFocus(view);            
        }

        

        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void NumDocLostFocus()
        {
            mc.NumDocLostFocus(view);
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        public void AddClient()
        {
            mc.AddClient(view);
        }


       

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public void Change()
        {
            mc.Change(view, oldnum);
        }

        /// <summary>
        /// Заполняет значения при загрузке
        /// </summary>
        public void Loader()
        {
            mc.Loader(view);          
        }

        
    }
}
