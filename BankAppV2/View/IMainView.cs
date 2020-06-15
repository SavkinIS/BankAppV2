using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    /// <summary>
    /// ViewModel для Главног окна
    /// </summary>
    interface IMainView
    {
        /// <summary>
        /// Запрос
        /// </summary>
        string Request { get; }

        /// <summary>
        /// К кому обащен запрос
        /// </summary>
        string About { get; }

    }
}
