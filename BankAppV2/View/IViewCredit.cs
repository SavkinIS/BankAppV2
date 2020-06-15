using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.View
{
    interface IViewCredit
    {
        string SumCredit{get; set;}

        string Months { get; set; }

        string PayFormonth { get; set; }

        string EndProcent { get; set; }

        string Rating { get; set; }
    }
}
