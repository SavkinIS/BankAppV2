using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewAddCompany
    {/// <summary>
     /// Номер пасспорта или ИНН
     /// </summary>
        string NumbInn { get; set; }

        /// <summary>
        /// Статус нового клиента
        /// </summary>
        string Status { get; set; }

        string CompName { get; set; }

        string Finance { get; set; }

        string Adress { get; set; }

        string Rating { get; set; }
     
        DateTime CreateDay { get; set; }

        Company co { get; }
    }
}
