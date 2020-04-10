using Microsoft.EntityFrameworkCore;
using PopulationHouseholdWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationHouseholdWebAPI.DB
{
    public class StateDBContext : DbContext
    {
        public StateDBContext(DbContextOptions<StateDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Actucals> Actuals { get; set; }
        public DbSet<Estimates> Estimates { get; set; }
    }
}
