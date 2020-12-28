using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Definition).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Detail).HasColumnType("ntext");

            builder.HasOne(I => I.Mission).WithMany(I => I.Reports).HasForeignKey(I => I.MissionId);
        }
    }
}
