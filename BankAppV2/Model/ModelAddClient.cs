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
    class ModelAddClient
    {
        
        bool flag = false;
        EFData my = new EFData();

        public ModelAddClient()
        {
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
        internal void Check(IViewAddClient view, string oldnum)
        {
            string freeNumDoc = view.NumDoc;

            string status = view.Status;

            if (!my.CheckNumDoc(freeNumDoc, status) == true)
            {
                if (oldnum != view.NumDoc)
                {
                    {
                        view.NumDoc = "";

                        MessageBox.Show("Такой клиетн уже существует!");
                    }
                }
            }
        }


        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void AdressLostFocus(IViewAddClient view)
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
        internal void WorkPlaceLostFocus(IViewAddClient view)
        {
            if (view.WorkPlace == "Введите место работы")
            {
                view.WorkPlace = "";
            }
            else if (view.WorkPlace == "")
            {
                view.WorkPlace = "Введите место работы";
            }

        }

        /// <summary>
        /// очищает поле при первом клике
        /// </summary>
        internal void NumDocLostFocus(IViewAddClient view)
        {
            if (view.NumDoc == "Введите Серию и номер ИНН без пробела" || view.NumDoc == "Введите Серию и номер ПАСПОРТА без пробела")
            {
                view.NumDoc = "";
            }
            else if (view.NumDoc == "")
            {
                view.NumDoc = "Введите Серию и номер  без пробела";
            }


        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        public void AddClient(IViewAddClient view)
        {
            Client cl = CreateClient(view);
            if (flag == true)
            {
                try
                {
                    my.AddClient(cl);
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
        public void Change(IViewAddClient view, string oldnum)
        {
            Client cl;
            cl = CreateClient(view);
            if (flag == true)
            {
                try
                {
                    my.ChangeClient(cl, oldnum);
                }
                catch (Exception e) { MessageBox.Show(e.Message); }
            }
        }

        /// <summary>
        /// Заполняет значения при загрузке
        /// </summary>
        public void Loader(IViewAddClient view)
        {

            view.FName = view.cl.FName;
            view.LName = view.cl.LName;
            view.NumDoc = view.cl.Passport;
            view.Rating = view.cl.BankRating.ToString();
            view.Status = SetIndexClient();
            view.brthDay = view.cl.BrthDay;
            view.Adress = view.cl.Adress;
            view.Finance = view.cl.Finance.ToString();
            view.WorkPlace = view.cl.WorkPlace;


        }

        /// <summary>
        /// Метод сохраняет или обновляет клиента
        /// </summary>
        /// <param name="metod">Используемый метод </param>
        private Client CreateClient(IViewAddClient view)
        {
            Client client = new Client();
            try
            {
                if (!my.CheckNumDoc(view.NumDoc, view.Status) == true && view.cl.Passport != view.NumDoc) { throw new Exception("Такой клиет уже существует!"); }

                ///Client
                if (view.Status != "COMPANY")
                {
                    if (view.NumDoc != "" && view.Status != "" && view.FName != "" && view.LName != ""
                        && view.Adress != "" && view.Rating != "" && view.brthDay != null && view.WorkPlace != "" && view.Finance != "")
                    {

                        if (view.NumDoc.Length < 12 || view.NumDoc == "Введите Серию и номер  без пробела"
                            || view.NumDoc == "Введите Серию и номер ПАСПОРТА без пробела" || view.NumDoc == "Введите Серию и номер  без пробела")
                        {
                            throw new Exception("Номер  ПАСПОРТА введен некоректно");
                        }
                        if (view.WorkPlace == "Введите место работы")
                        {
                            view.WorkPlace = "";
                        }

                        if (view.Adress == "Введите Адрес" || view.Adress == "")
                        {
                            throw new Exception("Вы не ввели адрес");
                        }

                        client = new Client()
                        {
                            Passport = view.NumDoc,
                            ClStatus = view.Status,
                            FName = view.FName,
                            LName = view.LName,
                            Finance = view.Finance.ToInt32(),
                            Adress = view.Adress,
                            BankRating = view.Rating.ToInt32(),
                            WorkPlace = view.WorkPlace,
                            BrthDay = view.brthDay
                        };
                        flag = true;

                    }
                    else { throw new Exception("Не все поля заполнены!"); }
                }
                //Company

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
