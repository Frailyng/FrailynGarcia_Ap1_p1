﻿using FrailynGarcia_Ap1_p1.Models;
using Microsoft.EntityFrameworkCore;


namespace FrailynGarcia_Ap1_p1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Prestamos> Prestamos { get; set; }

        public DbSet<Deudores> Deudores { get; set; }

        public DbSet<Cobros> Cobros { get; set; }

        public DbSet<CobroDetalle> CobroDetalle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deudores>().HasData(new List<Deudores>()
            {
                new Deudores(){DeudorId = 1, Nombres = "Frailyn" },
                new Deudores(){DeudorId = 2, Nombres = "Celainy"},
                new Deudores(){DeudorId = 3, Nombres = "Abel"}

                });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TiposTelefonos>().HasData(new List<TiposTelefonos>()
            {
                new TiposTelefonos(){TipoId=1, Descripcion="Telefono" },
                new TiposTelefonos(){TipoId=2, Descripcion="Celular" },
                new TiposTelefonos(){TipoId=3, Descripcion="Oficina" }

            });
        }


    }
}
