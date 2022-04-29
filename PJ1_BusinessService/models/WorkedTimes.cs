using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PJ1_BusinessService.models
{
    /// <summary>
    /// Модель отработанного времени
    /// </summary>
    public class WorkedTimes
    {
        /// <summary>
        /// Id записи
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Время начала
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// Время окончания
        /// </summary>
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// Пользователь
        /// </summary>
        [Required]
        public AppUser User { get; set; }
    }
}
