using EFCoreAssignment01.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreAssignment01.Data
{
    internal class ItiDbContext:DbContext
    {
        public ItiDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UDFSA0T ; Database=Iti ; Trusted_Connection=True ; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course_Inst>(ci => {
                ci.HasKey(e => new { e.Course_Id, e.Inst_Id });
                ci.Property(nameof(Course_Inst.Evaluate))
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
                ci.HasOne(e => e.Instructor)
                  .WithMany()
                  .HasForeignKey(e => e.Inst_Id)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);

                ci.HasOne(e => e.Course)
                  .WithMany()
                  .HasForeignKey(e => e.Course_Id)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);
            }
            );

            modelBuilder.Entity<Stud_Course>(sc => {
                sc.HasKey(e => new { e.Stud_Id, e.Course_Id });
                sc.Property(nameof(Stud_Course.Grade))
                .IsRequired();
                sc.HasOne(e => e.Student)
                  .WithMany()
                  .HasForeignKey(e => e.Stud_Id)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);

                sc.HasOne(e => e.Course)
                  .WithMany()
                  .HasForeignKey(e => e.Course_Id)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Cascade);
            }
            );

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // Mapping By Convention
        public DbSet<Student> Students { get; set; }

        // Data Annotations
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }

        //Fluent APIs
        public DbSet<Course_Inst> Course_Insts { get; set; }
        public DbSet<Stud_Course> Stud_Courses { get; set; }

        //Configuration classes
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}
