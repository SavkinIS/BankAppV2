//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankAppV2
{
    using System;
    using System.Collections.Generic;
    
    public partial class CashAccounts
    {
        public string NumCashAcc { get; set; }
        public string NumClientPassport { get; set; }
        public string NumClientINN { get; set; }
        public decimal AccFinance { get; set; }
        public string TypeAcc { get; set; }
        public System.DateTime PeriodAcc { get; set; }
        public bool Active { get; set; }
    }
}
