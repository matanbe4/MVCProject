using HW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW.Dal
{
    public class EmployeeDal : DbContext
    {

        //tables mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("tblEmployees");
        }

        public DbSet<Employee> Employees { get; set; }

        public static Employee empToChange;

    }
}