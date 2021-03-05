using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BookPenaltyAPI.Models;

namespace BookPenaltyAPI.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Data Source=DESKTOP-661ODQ1;Integrated Security=SSPI;Initial Catalog=BookPenaltyDB;Trusted_Connection=yes") { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryBusinessDaysConfig> CountryBusinessDaysConfigs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}