using System;
using Microsoft.AspNetCore.Identity;

namespace WorkTime.BoardRecords.Web.models
{
    /// <summary>
    /// Модель роли
    /// </summary>
    public class AppRole : IdentityRole<int>
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
    }
}