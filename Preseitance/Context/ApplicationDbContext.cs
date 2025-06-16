using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public  class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
        public DbSet<Trips> Trips { get; set; } = null!; // Assuming Trips is a model class representing a trip entity
        public DbSet<Reviews> Reviews { get; set; } = null!; // Assuming Reviews is a model class representing a review entity
    }
}
