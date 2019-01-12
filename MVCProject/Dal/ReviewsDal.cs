using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCProject.Models;

namespace MVCProject.Dal
{
    public class ReviewsDal : DbContext
    {
        public DbSet<Review> reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Review>().ToTable("Reviews");
        }
    }
}