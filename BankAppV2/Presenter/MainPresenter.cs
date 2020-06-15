using BankAppV2.HelperClass;
using BankAppV2.Model;
using BankAppV2.View;
using BankAppV2.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.Presenter
{
    class MainPresenter
    {
        IMainView view;
        EFData my = new EFData();
        ModelMain mm;
        /// <summary>
        /// Список для комбо бокса с типами запросов
        /// </summary>
        public ComboTypes types = new ComboTypes();

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view">ViewModel для главного  окна</param>
        public MainPresenter(IMainView view)
        {
            this.view = view;
            mm = new ModelMain();
        }

        /// <summary>
        /// метод открывает Окно добавления нового клиента
        /// </summary>
        public void OpenNewClient()
        {
            mm.OpenNewClient();
        }

        /// <summary>
        /// Открывает всех клиентов людей
        /// </summary>
        public void PeopleClient()
        {
            mm.PeopleClient();
        }

        internal void OpenNewClientComp()
        {
            mm.OpenNewClientComp();
        }

        /// <summary>
        /// Открывает новое окно всех компаний 
        /// </summary>
        public void CompanyClient()
        {
            mm.CompanyClient();
        }

        /// <summary>
        /// Открывает окно с выборкой
        /// </summary>
        public void Sample()
        {
            mm.Sample(view.Request, view.About);
        }

        
       
    }
}
