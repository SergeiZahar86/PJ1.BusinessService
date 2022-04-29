using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ1_BusinessService.models
{
    /// <summary>
    /// Dto времени начала пользователя
    /// </summary>
    public class EmplStartTime
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int IdUser { get; set; }
        /// <summary>
        /// Время начала
        /// </summary>
        public DateTime StartTime { get; set; }
    }
}
