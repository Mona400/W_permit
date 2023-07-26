using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkPermit.DAL.Models;

namespace WorkPermit.DAL.Config
{
    public class StatusModelConfiguration : IEntityTypeConfiguration<StatusModel>
    {


        public void Configure(EntityTypeBuilder<StatusModel> builder)
        {
            builder.HasNoKey();
        }
    }
}