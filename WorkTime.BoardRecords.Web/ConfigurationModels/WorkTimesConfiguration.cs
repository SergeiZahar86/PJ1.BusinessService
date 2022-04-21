using Microsoft.EntityFrameworkCore;
using WorkTime.BoardRecords.Web.models;

namespace WorkTime.BoardRecords.Web.ConfigurationModels
{
    public class WorkTimesConfiguration : IEntityTypeConfiguration<WorkedTimes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WorkedTimes> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
