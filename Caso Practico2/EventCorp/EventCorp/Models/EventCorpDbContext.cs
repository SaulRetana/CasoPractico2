using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventCorp.Data;
using EventCorp.Services;
using System;
using System.Collections.Generic;
using EventCorp.Models;

namespace EventCorp.Data
{
    public class EventCorpDbContext : DbContext
    {
        public EventCorpDbContext(DbContextOptions<EventCorpDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User Entity Configuration
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>().Property(u => u.NombreUsuario).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Usuario>().Property(u => u.Correo).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).IsRequired();
            modelBuilder.Entity<Usuario>().Property(u => u.Rol).IsRequired().HasMaxLength(20);

            // Category Entity Configuration
            modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
            modelBuilder.Entity<Categoria>().Property(c => c.Nombre).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Categoria>().Property(c => c.Descripcion).HasMaxLength(200);
            modelBuilder.Entity<Categoria>().Property(c => c.FechaRegistro).HasDefaultValueSql("GETDATE()");

            // Event Entity Configuration
            modelBuilder.Entity<Evento>().HasKey(e => e.Id);
            modelBuilder.Entity<Evento>().Property(e => e.Titulo).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Evento>().Property(e => e.Descripcion).HasMaxLength(500);
            modelBuilder.Entity<Evento>().Property(e => e.FechaRegistro).HasDefaultValueSql("GETDATE()");

            // Event-Categoria Relationship Configuration
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Categoria)  // Asegúrate de que la propiedad "Categoria" esté presente en el modelo Evento
                .WithMany()  // Un evento tiene una categoría
                .HasForeignKey(e => e.CategoriaId)  // La clave externa a la categoría
                .OnDelete(DeleteBehavior.Restrict);

            // Inscription Entity Configuration
            //modelBuilder.Entity<Inscripcion>().HasKey(i => i.Id);
            //  modelBuilder.Entity<Inscripcion>()
            //   .HasOne(i => i.Evento)  // Cada inscripción está asociada a un evento
            //   .WithMany(e => e.Inscripciones)  // Un evento tiene muchas inscripciones
            //  .HasForeignKey(i => i.EventoId)
            //  .OnDelete(DeleteBehavior.Cascade);  // Al eliminar el evento, se eliminan las inscripciones

            // modelBuilder.Entity<Inscripcion>()
            //  .HasOne(i => i.Usuario)  // Cada inscripción está asociada a un usuario
            //   .WithMany(u => u.Inscripciones)  // Un usuario tiene muchas inscripciones
            //  .HasForeignKey(i => i.UsuarioId)
            //  .OnDelete(DeleteBehavior.Cascade);  // Al eliminar el usuario, se eliminan las inscripciones
        }
    }
}
