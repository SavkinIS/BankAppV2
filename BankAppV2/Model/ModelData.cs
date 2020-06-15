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
    class ModelData
    {
        EFData my ;

        public ModelData()
        {
            my = new EFData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns></returns>
        public List<Company> LoaderData()
        {
            SkillDBEntities skill = new SkillDBEntities();
            return skill.Company.ToList();
        }

        /// <summary>
        /// открывает счета выбранного клиента
        /// </summary>
        public void OpenClientCash(IViewDataComp view)
        {
            CashWin cw = new CashWin(view.Status, view.NumPassOrInn);
            cw.ShowDialog();
        }

        /// <summary>
        /// удаляет выбранного клиента
        /// </summary>
        public void DeleteClient(IViewDataComp view)
        {
            my.DelClient(view.Status, view.NumPassOrInn);
            view.dataTable = my.PrintData();
        }

        /// <summary>
        /// Открывает окно для изменения
        /// </summary>
        public void ChangeClientInfo(IViewDataComp view)
        {
            ChangeComp cc = new ChangeComp(my.GetCompanyFromDB(view.NumPassOrInn));
            cc.ShowDialog();
            view.dataTable = LoaderData();
        }

    }
}
