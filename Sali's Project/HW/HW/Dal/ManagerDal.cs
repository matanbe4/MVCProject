using HW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW.Dal
{
    public class ManagerDal : DbContext
    {
        //tables mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manager>().ToTable("tblManagers");
        }

        public DbSet<Manager> Managers { get; set; }



    }
}