﻿// <auto-generated />
using System;
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

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.CobroDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ValorCobrado")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("CobroId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("CobroDetalle");
                });

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeudorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly?>("Fecha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Monto")
                        .HasColumnType("INTEGER");

                    b.HasKey("CobroId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DeudorId");

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            Nombres = "Frailyn"
                        },
                        new
                        {
                            DeudorId = 2,
                            Nombres = "Celainy"
                        },
                        new
                        {
                            DeudorId = 3,
                            Nombres = "Abel"
                        });
                });

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conceptos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Deudores")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Montos")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrestamosId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.CobroDetalle", b =>
                {
                    b.HasOne("FrailynGarcia_Ap1_p1.Models.Cobros", "Cobro")
                        .WithMany()
                        .HasForeignKey("CobroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrailynGarcia_Ap1_p1.Models.Prestamos", "Prestamo")
                        .WithMany()
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobro");

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("FrailynGarcia_Ap1_p1.Models.Cobros", b =>
                {
                    b.HasOne("FrailynGarcia_Ap1_p1.Models.Deudores", "Deudor")
                        .WithMany()
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudor");
                });
#pragma warning restore 612, 618
        }
    }
}
