﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTime.BoardRecords.Web.models;

namespace WorkTime.BoardRecords.Web.ConfigurationModels
{
    /// <summary>
    /// Класс конфигурации AppUser
    /// </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
