using BankAppV2.HelperClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewAddClient
    {
        /// <summary>
        /// Номер пасспорта или ИНН
        /// </summary>
        string NumDoc { get; set; }

        /// <summary>
        /// Статус нового клиента
        /// </summary>
        string Status { get; set; }
        
        string FName { get; set;}
        
        string LName { get; set;}

        string Finance { get; set;}

        string Adress { get; set;}

        string Rating { get; set;}

        string WorkPlace { get; set;}
        DateTime brthDay { get; set;}

        Client cl { get; }

    }
}
