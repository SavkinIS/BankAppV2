using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppV2.HelperClass
{
    /// <summary>
    /// Класс определяей тип который может быть у запроса
    /// </summary>
   class ComboType
   {

        /// <summary>
        /// тип
        /// </summary>
    string type;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="type"></param>
    public ComboType(string type)
    {
        Type = type;
    }
        /// <summary>
        /// свойство
        /// </summary>
    public string Type { get => type; set => type = value; }
   }
}
