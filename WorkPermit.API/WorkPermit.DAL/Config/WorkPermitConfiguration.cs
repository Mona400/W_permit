using Microsoft.EntityFrameworkCore;
using WorkPermit.DAL.Models;

namespace WorkPermit.DAL.Config
{
    public class WorkPermitConfiguration : IEntityTypeConfiguration<WorkPermitRequest>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WorkPermitRequest> builder)
        {
            builder
                 .HasOne(p => p.Employee)
                 .WithMany()
                 .HasForeignKey(p => p.EmployeeId)
                 .OnDelete(DeleteBehavior.Cascade);

            //builder
            //    .HasMany(p => p.Activities)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("WorkPermitRequestActivities"));

            //builder
            //    .HasMany(p => p.Equipment)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("WorkPermitRequestEquipment"));

            builder
            .Property(p => p.Status)
            .HasConversion<string>() // Convert enum to string when storing in database
            .HasDefaultValue(WorkPermitRequest.WorkPermitStatus.New); // Set default value to WorkPermitStatus.New

        }
    }
}
