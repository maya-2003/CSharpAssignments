using EFCoreAssignment01.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace EFCoreAssignment01.Data.Configurations
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(d => d.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder.Property(i => i.Address)
                    .HasColumnType("varchar")
                    .HasMaxLength(200);
            builder.Property(i => i.Salary)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

            builder.Property(i => i.Bonus)
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.HourRate)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(i => i.Department)
                      .WithMany(d => d.instructors)
                      .HasForeignKey(i => i.DepartmentId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
