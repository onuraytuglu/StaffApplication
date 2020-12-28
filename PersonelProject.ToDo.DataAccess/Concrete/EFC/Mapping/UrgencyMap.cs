using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonelProject.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonelProject.ToDo.DataAccess.Concrete.EFC.Mapping
{
    public class UrgencyMap : IEntityTypeConfiguration<Urgency>
    {
        public void Configure(EntityTypeBuilder<Urgency> builder)
        {
            builder.Property(I => I.Definition).HasMaxLength(100);
        }
    }
}
