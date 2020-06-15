using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewTransferClientsAcc
    {
        /// <summary>
        /// Счет с которого будет произведён перевод
        /// </summary>
        string CurentAcc { get; set; }
        
        /// <summary>
        /// Сумма средст на текущем счете
        /// </summary>
        string CurentFinance { get; set; }

        /// <summary>
        /// Счет yf который будет произведён перевод
        /// </summary>
        string SelectedAcc { get; set; }

        /// <summary>
        /// Сумма средств на счете, на готорый будет произведён перевод
        /// </summary>
        string SelectedFinance { get; set; }

        /// <summary>
        /// Сумма перевода
        /// </summary>
        string SumTransfer { get; set; }

        /// <summary>
        /// номер покоторому будет произведен поиск Счета
        /// </summary>
        //string NumCashAcc { set; }

        /// <summary>
        /// Статус клиента владельца счета
        /// </summary>
       // string Status { get; }
        
    }
}
