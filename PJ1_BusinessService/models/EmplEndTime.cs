using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ1_BusinessService.models
{
    /// <summary>
    /// Dto времени окончания
    /// </summary>
    public class EmplEndTime
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int IdUser { get; set; }
        
        /// <summary>
        /// Время окончания
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
