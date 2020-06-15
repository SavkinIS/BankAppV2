using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.HelperClass
{
    /// <summary>
    /// Класс описывает значения 
    /// сответствующие Клиенту по номеру строк в таблице
    /// </summary>
   public class ClientDescription
    {
        /// <summary>
        /// Имя клиента
        /// </summary>
        int name = 0;
        /// <summary>
        /// Фамилия клиента
        /// </summary>
        int lname = 1;
        /// <summary>
        /// День Рождения Клиента
        /// </summary>
        int brhDay = 2;
        /// <summary>
        /// Номер паспорта Клиента
        /// </summary>
        int passport = 3;
        /// <summary>
        /// Средства  Клиента
        /// </summary>
        int finance = 4;
        /// <summary>
        /// Рейтинг Клиента
        /// </summary>
        int rating = 5;
        /// <summary>
        /// Статус  Клиента
        /// </summary>
        int status = 6;
        /// <summary>
        /// Адрес Клиента
        /// </summary>
        int adress = 7;
        /// <summary>
        /// Место работы  Клиента
        /// </summary>
        int workPlace = 8;
        /// <summary>
        /// Активность  Клиента
        /// </summary>
        int activ = 9;
        /// <summary>
        /// начало активности Клиента
        /// </summary>
        int firsttranse = 10;

        /// ---------------Компания-----------------------------
        #region Comp
        /// <summary>
        /// Имя Компании
        /// </summary>
        int compName = 0;
        /// <summary>
        /// День Создания Компании
        /// </summary>
        int compCreateDate = 1;
        ///  <summary>
        /// Номер инн Компании
        /// </summary>
        int inn = 2;
        ///<summary>
        /// Средства  Компании
        /// </summary>
        int compfinance = 3;
        /// <summary>
        /// Рейтинг Компании
        /// </summary>
        int compRating = 4;
        /// <summary>
        /// Статус Компании
        /// </summary>
        int compStatus = 5;
        /// <summary>
        /// Адрес Компании
        /// </summary>
        int compAdress = 6;
        /// /// <summary>
        /// Активность Компании
        /// </summary>
        int compActiv = 7;
        /// <summary>
        /// начало активности Компании
        /// </summary>
        int compFstTranse = 8;
        #endregion


        public ClientDescription()
        {
        }
        /// <summary>
        /// Имя клиента
        /// </summary>
        public int Name { get => name; }
        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public int Lname { get => lname; }
        /// <summary>
        /// День Рождения Клиента
        /// </summary>
        public int BrhDay { get => brhDay; }
        /// <summary>
        /// Номер паспорта Клиента
        /// </summary>
        public int Passport { get => passport;  }
        /// <summary>
        /// Средства  Клиента
        /// </summary>
        public int Finance { get => finance;  }
        /// <summary>
        /// Рейтинг Клиента
        /// </summary>
        public int Rating { get => rating;  }
        /// <summary>
        /// Статус  Клиента
        /// </summary>
        public int Status { get => status;  }
        /// <summary>
        /// Место работы  Клиента
        /// </summary>
        public int Adress { get => adress;  }
        /// <summary>
        /// Место работы  Клиента
        /// </summary>
        public int WorkPlace { get => workPlace; }
        /// <summary>
        /// активность  Клиента
        /// </summary>
        public int Activ { get => activ; }
        /// <summary>
        /// Начало активности Клиента
        /// </summary>
        public int Firsttranse { get => firsttranse; }
        /// <summary>
        /// Имя Компании
        /// </summary>
        public int CompName { get => compName;  }
        /// <summary>
        /// День Создания Компании
        /// </summary>
        public int CompCreateDate { get => compCreateDate; }
        ///  <summary>
        /// Номер инн Компании
        /// </summary>
        public int Inn { get => inn;  }
        ///<summary>
        /// Средства  Компании
        /// </summary>
        public int Compfinance { get => compfinance;  }
        /// <summary>
        /// Рейтинг Компании
        /// </summary>
        public int CompRating { get => compRating; }
        /// <summary>
        /// Статус Компании
        /// </summary>
        public int CompStatus { get => compStatus;  }
        /// <summary>
        /// Адрес Компании
        /// </summary>
        public int CompAdress { get => compAdress; }
        /// /// <summary>
        /// Активность Компании
        /// </summary>
        public int CompActiv { get => compActiv;  }
        /// <summary>
        /// начало активности Компании
        /// </summary>
        public int CompFstTranse { get => compFstTranse; }
    }
}
