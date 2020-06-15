using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewDeposite
    {
        string SumDep { get; set; }
        string TypeDep { get; set; }
        string MonthsDep { get; set; }
        string FinanceEnd { get; set; }
        string Rating { get; set; }
        string Procents { get; set; }
    }
}
