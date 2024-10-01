﻿// <auto-generated />
using FrailynGarcia_Ap1_p1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FrailynGarcia_Ap1_p1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conceptos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Deudores")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Montos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamosId");

                    b.ToTable("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
