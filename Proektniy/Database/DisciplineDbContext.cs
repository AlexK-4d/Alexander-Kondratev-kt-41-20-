using Microsoft.EntityFrameworkCore;
using Proektniy.Database.Configurations;
using Proektniy.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Proektniy.Database
{
    public class DisciplineDbContext : DbContext
    {
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Prepod> Prepods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new PrepodConfiguration());
        }

        public DisciplineDbContext(DbContextOptions<DisciplineDbContext> options) : base(options)
        {

        }
    }
}
