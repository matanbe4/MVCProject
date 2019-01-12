using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProject.Dal
{
    //A Data Access Layer to the Complaints Table.
    public class ComplaintsDal : DbContext
    {

        public DbSet<Complaint> complaints { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Complaint>().ToTable("Complaints");
        }

    }

}