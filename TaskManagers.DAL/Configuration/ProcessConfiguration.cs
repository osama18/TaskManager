using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagers.DAL.Entities;

namespace TaskManagers.DAL.Configuration
{
    public class ProcessConfiguration : IEntityTypeConfiguration<ProcessEntity>
    {
        public void Configure(EntityTypeBuilder<ProcessEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.GroupName)
                .IsRequired();

            builder.Property(e => e.Priority)
                .IsRequired();

            builder.HasIndex(x => new { x.GroupName })
            .HasDatabaseName("IX_Process_GroupName");
        }
    }
}
