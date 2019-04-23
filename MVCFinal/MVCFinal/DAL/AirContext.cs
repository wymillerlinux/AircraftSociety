using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MVCFinal.Models;

namespace MVCFinal.DAL
{
    public class AirContext : DbContext
    {
        public AirContext() : base("AirContext")
        {
        }

        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}