using BankAppV2.HelperClass;
using BankAppV2.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankAppV2.Model
{
    class ModelMain
    {
        EFData my = new EFData();

        public ModelMain()
        {
           
        }

        /// <summary>
        /// Открывает окно с выборкой
        /// </summary>
        public void Sample(string Request, string About)
        {
            List<Client> c;
            List<Company> co;
            List<CashAccounts> ca;
            if (Request == "Фамилия")
            {
                c = new List<Client>();
                ///string Name, string NumDoc, string type || view.Request == "Номер паспорта"
                c = my.ReqestClientsFromNUM(About, "LName");
                OpenSelect(c);
            }
            else if (Request == "Номер паспорта")
            {
                c = my.ReqestClientsFromNUM(About, "Passport");
                OpenSelect(c);
            }
            else if (Request == "Название Компании")
            {
                co = my.ReqestCompanyFromNUM(About, "CompName");
                OpenSelect(co);
            }
            else if (Request == "Номер ИНН")
            {
                co = my.ReqestCompanyFromNUM(About, "CompName");
                OpenSelect(co);
            }
            else if (Request == "Номер Счета")
            {
              ca = my.ReqCashAsync(About).Result;
           
              
                if (ca.Count != 0)
                {
                    ReqCashWin win = new ReqCashWin(ca);
                    win.ShowDialog();
                }
                else { MessageBox.Show("Нет совпадений"); }
            }
            else
            {
                MessageBox.Show("Тип выборки не выбран");
            }

        }


        /// <summary>
        /// метод открывает Окно добавления нового клиента
        /// </summary>
        public void OpenNewClient()
        {

            AddClient acl = new AddClient();
            acl.ShowDialog();

        }

        /// <summary>
        /// Открывает всех клиентов людей
        /// </summary>
        public void PeopleClient()
        {
            DataWinClient dw = new DataWinClient();
            dw.ShowDialog();
        }

        internal void OpenNewClientComp()
        {
            AddClompanyWin acl = new AddClompanyWin();
            acl.ShowDialog();
        }

        /// <summary>
        /// Открывает новое окно всех компаний 
        /// </summary>
        public void CompanyClient()
        {
            DataWinComp dw = new DataWinComp();
            dw.ShowDialog();
        }

        /// <summary>
        /// Если в таблице есть результат то открывает окно с выборкой
        /// </summary>
        /// <param name="c"></param>
        private static void OpenSelect(List<Company> c)
        {
            if (c.Count != 0)
            {
                ReqestWin win = new ReqestWin(c);
                win.ShowDialog();
            }
            else { MessageBox.Show("Нет совпадений"); }
        }
        /// <summary>
        /// Если в таблице есть результат то открывает окно с выборкой
        /// </summary>
        /// <param name="c"></param>
        private static void OpenSelect(List<Client> c)
        {
            if (c.Count != 0)
            {
                ReqestWin win = new ReqestWin(c);
                win.ShowDialog();
            }
            else { MessageBox.Show("Нет совпадений"); }
        }
    }
}
