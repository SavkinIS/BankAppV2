using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.HelperClass
{
   public class ClientOLD 
    {
        #region Поля и свойства
        /// <summary>
        /// Номер пасспорта или ИНН
        /// </summary>
        string numDoc;

        /// <summary>
        /// Статус нового клиента
        /// </summary>
        string status ;

        string fName ;

        string lName ;

        string finance ;

        string adress ;

        string rating ;

        string workPlace;

        DateTime brDay;

        
        public string NumDoc { get => numDoc; set => numDoc = value; }
        public string Status { get => status; set => status = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string Finance { get => finance; set => finance = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Rating { get => rating; set => rating = value; }
        public string WorkPlace { get => workPlace; set => workPlace = value; }
        public DateTime BrDay { get => brDay; set => brDay = value; }
        #endregion


        /// <summary>
        /// Клиент Человек
        /// </summary>
        /// <param name="numDoc">Номер пасспорта</param>
        /// <param name="status">Статус</param>
        /// <param name="fName">Имя</param>
        /// <param name="lName">Фамилия</param>
        /// <param name="finance">Финансы</param>
        /// <param name="adress">Адрес жительства</param>
        /// <param name="rating">Банковский рейтинг</param>
        /// <param name="workPlace">Место работы</param>
        /// <param name="brDay">День Рождения</param>
        public ClientOLD(string numDoc, string status, string fName, string lName, string finance, string adress, string rating, string workPlace, DateTime brDay)
        {
            NumDoc = numDoc;
            Status = status;
            FName = fName;
            LName = lName;
            Finance = finance;
            Adress = adress;
            Rating = rating;
            WorkPlace = workPlace;
            BrDay = brDay;
        }


        /// <summary>
        /// Клиент компания
        /// </summary>
        /// <param name="numDoc">Номер пасспорта</param>
        /// <param name="status">Статус</param>
        /// <param name="CompName">Имя Компании</param>
        /// <param name="finance">Финансы</param>
        /// <param name="adress">Адрес компании</param>
        /// <param name="rating">Банковский рейинг</param>
        /// <param name="CreateDay">Дата создания компании</param>
        public ClientOLD(string numDoc, string status, string CompName, string finance, string adress, string rating, DateTime CreateDay)
        {
            NumDoc = numDoc;
            Status = status;
            FName = CompName;
            Finance = finance;
            Adress = adress;
            Rating = rating;
            BrDay = CreateDay;
        }

        public ClientOLD()
        {
        }
    }
}
