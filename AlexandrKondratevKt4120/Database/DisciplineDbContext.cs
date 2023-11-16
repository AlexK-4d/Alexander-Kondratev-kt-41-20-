using Microsoft.EntityFrameworkCore;
using AlexandrKondratevKt4120.Database.Configurations;
using AlexandrKondratevKt4120.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AlexandrKondratevKt4120.Database
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
