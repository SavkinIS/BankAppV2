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

    /// <summary>
    /// для работы с клиентами
    /// </summary>
    class PresenterDataClien
    {
        IViewData view;

        ModelDataClient md; 


        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public PresenterDataClien(IViewData view)
        {
            this.view = view;
            md = new ModelDataClient();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns></returns>
        public List<Client> LoaderData()
        {

            return md.LoaderData();
        }

        /// <summary>
        /// открывает счета выбранного клиента
        /// </summary>
        public void OpenClientCash()
        {
            md.OpenClientCash(view);
        }

        /// <summary>
        /// удаляет выбранного клиента
        /// </summary>
        public void DeleteClient()
        {
            md.DeleteClient(view);
        }


        public void ChangeClientInfo()
        {
            md.ChangeClientInfo(view);
            view.dataTable = LoaderData();
        }
    }
}
