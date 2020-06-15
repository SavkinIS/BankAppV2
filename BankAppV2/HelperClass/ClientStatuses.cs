using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.HelperClass
{
    /// <summary>
    /// Определяет список статусов клинта
    /// </summary>
    class ClientStatuses
    {
        /// <summary>
        /// список статусов клиента
        /// </summary>
        List<ClientStatus> li = new List<ClientStatus>
        {
            new ClientStatus("STANDART"),
            new ClientStatus("VIP"),
            
        };


        /// <summary>
        /// список статусов юрдиц и предпринимателей
        /// </summary>
        List<ClientStatus> licom = new List<ClientStatus>
        {
            new ClientStatus("COMPANY"),
        };


        /// <summary>
        /// список статусов клиента
        /// </summary>
        internal List<ClientStatus> Li { get => this.li; }

        /// <summary>
        /// список статусов юрдиц и предпринимателей
        /// </summary>
        internal List<ClientStatus> LiCom { get => this.licom; }
    }
}
