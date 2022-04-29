using System;
using Microsoft.AspNetCore.Identity;

namespace PJ1_BusinessService.models
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