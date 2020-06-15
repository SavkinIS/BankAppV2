using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewRequest
    {
        /// <summary>
        /// Статус клиента
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Номер Паспорта или ИНН в зависимости от статусат клиента
        /// </summary>
        string NumPass { get; }

        /// <summary>
        /// Таблица для отображения счетов
        /// </summary>
        DataTable dataTable { set; }

        /// <summary>
        /// Номер Паспорта или ИНН в зависимости от статусат клиента
        /// </summary>
        string NumInn { get; }
    }
}
