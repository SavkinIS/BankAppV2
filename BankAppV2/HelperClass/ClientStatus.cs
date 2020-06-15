using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.HelperClass
{
    /// <summary>
    /// Описывает статус клинта
    /// </summary>
    class ClientStatus
    {
        string status;

        public ClientStatus(string status)
        {
            Status = status;
        }

        public string Status { get => status; set => status = value; }
    }
}
