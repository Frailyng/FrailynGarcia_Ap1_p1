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
    }
}
