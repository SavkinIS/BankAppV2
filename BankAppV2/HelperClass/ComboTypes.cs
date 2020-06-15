using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.HelperClass
{

    /// <summary>
    /// Класс опредиляет список запросов
    /// </summary>
    class ComboTypes
    {
        /// <summary>
        /// Список Типов Запросов
        /// </summary>
        List<ComboType> types = new List<ComboType>
        {
            new ComboType("Фамилия"),
            new ComboType("Номер паспорта"),
            new ComboType("Номер ИНН"),
             new ComboType("Название Компании"),
             new ComboType("Номер Счета")
        };

        /// <summary>
        /// Список Типов Запросов
        /// </summary>
        internal List<ComboType> Types { get => types;}
    }
    
    
}

