using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Mapping
{
    public class MissionMap : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Ad).HasMaxLength(100);
            builder.Property(I => I.Aciklama).HasColumnType("ntext");

            builder.HasOne(I => I.Urgency).WithMany(I => I.Missions).HasForeignKey(I => I.UrgencyId);
            
        }
    }
}
