using HW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW.Dal
{
    public class UserDal : DbContext
    {

        //Tables mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("tblUsers");
        }

        public DbSet<User> Users { get; set; }



    }
}