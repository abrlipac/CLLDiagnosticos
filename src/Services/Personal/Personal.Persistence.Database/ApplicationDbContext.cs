﻿using Personal.Domain;
using Microsoft.EntityFrameworkCore;
using Personal.Persistence.Database.Configuration;

namespace Personal.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        )
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Personal");

            ModelConfig(modelBuilder);
        }

        public DbSet<Admin> Administradores { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            AdminConfiguration.Configure(modelBuilder.Entity<Admin>());
        }
    }
}
