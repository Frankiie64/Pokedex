using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TiposPokemones> TiposPokemones { get; set; }
        public DbSet<Regiones> Regiones { get; set; }
        public DbSet<Pokemones> Pokemones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API

            #region Tables

            modelBuilder.Entity<TiposPokemones>().ToTable("TipoPokemones"); //display name in DataBase
            modelBuilder.Entity<Regiones>().ToTable("Regiones");
            modelBuilder.Entity<Pokemones>().ToTable("Pokemones");
            #endregion

            #region constraint

            //Primary Key
            modelBuilder.Entity<TiposPokemones>().HasKey(x => x.Id);
            modelBuilder.Entity<Regiones>().HasKey(x => x.Id);
            modelBuilder.Entity<Pokemones>().HasKey(x => x.Id);

            //Relationships

            modelBuilder.Entity<TiposPokemones>()
                .HasMany<Pokemones>(tp => tp.PokemonP)
                .WithOne(p => p.TipoHabilidadPrincipal)
                .HasForeignKey(p => p.IdHabilidadPrincipal)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            modelBuilder.Entity<TiposPokemones>()
                .HasMany<Pokemones>(tp => tp.PokemonS)
                .WithOne(p => p.TipoHabilidadSecundaria)
                .HasForeignKey(p => p.IdHabilidadSecundaria)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            modelBuilder.Entity<Regiones>()
                .HasMany<Pokemones>(r => r.Pokemones)
                .WithOne(p => p.Region)
                .HasForeignKey(p => p.IdRegion)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            #endregion

            #region "Validaciones Requeridas"

                #region "Tipo Pokemones"

                modelBuilder.Entity<TiposPokemones>()
                .Property(tp => tp.Titulo)
                .IsRequired();

            modelBuilder.Entity<TiposPokemones>()
                .Property(tp => tp.Description)
                .IsRequired();

            modelBuilder.Entity<TiposPokemones>()
                .Property(tp => tp.ImagenUrl)
                .IsRequired();
            #endregion

            #region Regiones

            modelBuilder.Entity<Regiones>()
                .Property(r => r.Nombre)
                .IsRequired();


            #endregion

            #region Pokemones

            modelBuilder.Entity<Pokemones>()
                .Property(p => p.Nombre)
                .IsRequired();

            modelBuilder.Entity<Pokemones>()
                .Property(p => p.IdHabilidadPrincipal)
                .IsRequired();

            modelBuilder.Entity<Pokemones>()
               .Property(p => p.IdHabilidadSecundaria)
               .IsRequired();

            modelBuilder.Entity<Pokemones>()
                 .Property(p => p.IdRegion)
                 .IsRequired();           

            modelBuilder.Entity<Pokemones>()
                 .Property(p => p.ImagenUrl)
                 .IsRequired();

            #endregion

            #endregion
        }
    }
}
