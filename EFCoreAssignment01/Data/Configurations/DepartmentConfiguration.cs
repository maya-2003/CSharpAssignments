using EFCoreAssignment01.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder.Property(d => d.Ins_Id);
            builder.Property(d => d.HiringDate)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
