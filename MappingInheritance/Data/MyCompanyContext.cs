using MappingInheritance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingInheritance.Data
{
    internal class MyCompanyContext : DbContext
    {
        public MyCompanyContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UDFSA0T ; Database= InheritanceCompany ;Trusted_Connection=True ; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //modelBuilder.Entity<FullTimeEmployee>()
            //    .HasBaseType(typeof(Employee));
            //modelBuilder.Entity<PartTimeEmployee>()
            //    .HasBaseType(typeof(Employee));

            //modelBuilder.Entity<Employee>()
            //            .HasDiscriminator<string>("EmpType")
            //            .HasValue<FullTimeEmployee>("FTE")
            //            .HasValue<PartTimeEmployee>("PTE");

            modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");
            modelBuilder.Entity<PartTimeEmployee>().ToTable("PartTimeEmployee");
        }

        #region TPCT
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion

        #region TPH
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion

        #region TPT
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        #endregion
    }
}
