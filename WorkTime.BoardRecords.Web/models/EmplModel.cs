using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTime.BoardRecords.Web.models
{
    /// <summary>
    /// Модель работника
    /// </summary>
    public class EmplModel
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
