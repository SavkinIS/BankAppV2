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

    /// <summary>
    /// для работы с компаниями
    /// </summary>
    class PresenterData
    {
        IViewDataComp view;
        ModelData md;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="view"></param>
        public PresenterData(IViewDataComp view)
        {
            this.view = view;
            md = new ModelData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns></returns>
        public List<Company> LoaderData()
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

        /// <summary>
        /// Открывает окно для изменения
        /// </summary>
        public void ChangeClientInfo()
        {
            md.ChangeClientInfo(view);
            view.dataTable = LoaderData();
        }
       
    }
}
