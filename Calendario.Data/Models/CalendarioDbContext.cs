using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Calendario.Data.Models
{
    public partial class CalendarioDbContext : DbContext
    {
        public CalendarioDbContext()
        {
        }

        public CalendarioDbContext(DbContextOptions<CalendarioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<Repeticion> Repeticiones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("Evento", "dbo");
            modelBuilder.Entity<Repeticion>().ToTable("Repeticion", "dbo");
        }
    }
}
