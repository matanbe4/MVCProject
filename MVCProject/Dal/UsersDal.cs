using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Dal
{
    public class UsersDal : DbContext
    {
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<CustomerDal>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
        }

    }
}