using BankAppV2.HelperClass;
using BankAppV2.View;
using MyExtention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankAppV2.Model
{
    class ModelAddCompany
    {
        bool flag = false;
        EFData my = new EFData();

        public ModelAddCompany()
        {
            my = new EFData();
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
        internal void Check(IViewAddCompany view, string oldnum)
        {
            string freeNumDoc = view.NumbInn;

            string status = view.Status;

            if (my.CheckNumDoc(freeNumDoc, status) == true)
            {
                if (oldnum != view.NumbInn)
                {
                    {
                        view.NumbInn = "";

                        MessageBox.Show("Такой клиетн уже существует!");
                    }
                }
            }
        }


        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void AdressLostFocus(IViewAddCompany view)
        {
            if (view.Adress == "Введите Адрес")
            {
                view.Adress = "";
            }
            else if (view.Adress == "")
            {
                view.Adress = "Введите Адрес";
            }


        }



        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void NumDocLostFocus(IViewAddCompany view)
        {
            if (view.NumbInn == "Введите Серию и номер ИНН без пробела" || view.NumbInn == "Введите Серию и номер ПАСПОРТА без пробела")
            {
                view.NumbInn = "";
            }
            else if (view.NumbInn == "")
            {
                view.NumbInn = "Введите Серию и номер  без пробела";
            }


        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        public void AddClient(IViewAddCompany view)
        {
            Company cl = CreateClient(view);
            if (flag == true)
            {
                try
                {
                    my.AddCompany(cl);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }

                foreach (Window window in App.Current.Windows)
                {
                    if (window is Windows.AddClient)
                        window.Close();
                    else if (window is Windows.AddClompanyWin) window.Close();
                }

                flag = false;
            }


        }




        /// <summary>
        /// Сохранить изменения
        /// </summary>
        public void Change(IViewAddCompany view, string oldnum)
        {
            Company cl;
            cl = CreateClient(view);
            if (flag == true)
            {
                try
                {
                    my.ChangeCompany(cl, oldnum);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }
        }

        /// <summary>
        /// Заполняет значения при загрузке
        /// </summary>
        public void Loader(IViewAddCompany view)
        {
            view.CompName = view.co.CompName;
            view.NumbInn = view.co.INN;
            view.Rating = view.co.BankRating.ToString();
            view.Status = SetIndexClient();
            view.CreateDay = view.co.CreateDay;
            view.Adress = view.co.Adress;
            view.Finance = view.co.Finance.ToString();

        }

        /// <summary>
        /// Метод сохраняет или обновляет клиента
        /// </summary>
        /// <param name="metod">Используемый метод </param>
        private Company CreateClient(IViewAddCompany view)
        {
            Company client = new Company();
            try
            {
                if (my.CheckNumDoc(view.NumbInn, view.Status) == true && view.co.INN != view.NumbInn) { throw new Exception("Такой клиет уже существует!"); }

                ///COmpany
                if (view.Status == "COMPANY")


                {
                    if (view.NumbInn != "" && view.Status != "" && view.CompName != "" && view.Adress != "" && view.Rating != ""
                        && view.CreateDay != null && view.Finance != "")
                    {
                        if (view.NumbInn.Length < 12 || view.NumbInn == "Введите Серию и номер  без пробела"
                           || view.NumbInn == "Введите Серию и номер ПАСПОРТА без пробела" || view.NumbInn == "Введите Серию и номер  без пробела")
                        {
                            throw new Exception("Номер ИНН введен некоректно");
                        }

                        if (view.Adress == "Введите Адрес" || view.Adress == "")
                        {
                            throw new Exception("Вы не ввели адрес");
                        }

                        client = new Company()
                        {
                            INN = view.NumbInn,
                            ClStatus = view.Status,
                            CompName = view.CompName,
                            Finance = view.Finance.ToInt32(),
                            Adress = view.Adress,
                            BankRating = view.Rating.ToInt32(),
                            CreateDay = view.CreateDay
                        };
                        flag = true;
                    }
                    else { throw new Exception("Не все поля заполнены!"); }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return client;

        }

        /// <summary>
        /// Получаем индекс значения статуса
        /// </summary>
        /// <returns></returns>
        string SetIndexClient()
        {
            //if (view.cl.Status == "VIP") { return "1"; }
            //else if(view.cl.Status == "STANDART") { return "0"; }
            //else  { return "0"; }
            return "0";
        }
    }
}
