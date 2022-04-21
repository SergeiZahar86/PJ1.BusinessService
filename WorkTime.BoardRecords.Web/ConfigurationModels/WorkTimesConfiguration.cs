using Microsoft.EntityFrameworkCore;
using WorkTime.BoardRecords.Web.models;

namespace WorkTime.BoardRecords.Web.ConfigurationModels
{
    /// <summary>
    /// Класс конфигурации WorkedTimes
    /// </summary>
    public class WorkTimesConfiguration : IEntityTypeConfiguration<WorkedTimes>
    {
        public void Configure(
            Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WorkedTimes> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}