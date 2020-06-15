using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewDataComp
    {
        /// <summary>
        /// Статус клиента
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Номер Паспорта или ИНН в зависимости от статусат клиента
        /// </summary>
        string NumPassOrInn { get; }

        /// <summary>
        /// Таблица для отображения счетов
        /// </summary>
        List<Company> dataTable { set; }
    }
}
