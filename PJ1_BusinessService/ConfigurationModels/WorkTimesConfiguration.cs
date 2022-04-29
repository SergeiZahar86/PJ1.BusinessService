using Microsoft.EntityFrameworkCore;
using PJ1_BusinessService.models;

namespace PJ1_BusinessService.ConfigurationModels
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