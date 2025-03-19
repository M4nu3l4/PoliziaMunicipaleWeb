﻿// <auto-generated />
using System;
using Cops.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cops.Migrations
{
    [DbContext(typeof(CopsContext))]
    [Migration("20250318210643_UpdateSchema")]
    partial class UpdateSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cops.Models.Anagrafica", b =>
                {
                    b.Property<int>("IdAnagrafica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAnagrafica"));

                    b.Property<string>("CAP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cod_Fisc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cod_Fisc");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PuntiDecurtati")
                        .HasColumnType("int");

                    b.Property<int>("PuntiRimanenti")
                        .HasColumnType("int");

                    b.HasKey("IdAnagrafica");

                    b.ToTable("Anagrafica");
                });

            modelBuilder.Entity("Cops.Models.Statistiche", b =>
                {
                    b.Property<int>("IdStatistiche")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStatistiche"));

                    b.Property<int>("IdAnagrafica")
                        .HasColumnType("int");

                    b.Property<decimal>("ImportoTotale")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalePuntiDecurtati")
                        .HasColumnType("int");

                    b.Property<int>("TotaleVerbali")
                        .HasColumnType("int");

                    b.HasKey("IdStatistiche");

                    b.HasIndex("IdAnagrafica");

                    b.ToTable("Statistiche");
                });

            modelBuilder.Entity("Cops.Models.TipoViolazione", b =>
                {
                    b.Property<int>("IdViolazione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdViolazione"));

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PuntiDecurtati")
                        .HasColumnType("int");

                    b.HasKey("IdViolazione");

                    b.ToTable("TipoViolazione");
                });

            modelBuilder.Entity("Cops.Models.Verbale", b =>
                {
                    b.Property<int>("IdVerbale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVerbale"));

                    b.Property<string>("Cod_Fisc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cod_Fisc");

                    b.Property<DateTime>("DataTrascrizioneVerbale")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataViolazione")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DecurtamentoPunti")
                        .HasColumnType("int");

                    b.Property<int>("IdAnagrafica")
                        .HasColumnType("int");

                    b.Property<int>("IdViolazione")
                        .HasColumnType("int");

                    b.Property<decimal?>("Importo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("IndirizzoViolazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nominativo_Agente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoViolazioneIdViolazione")
                        .HasColumnType("int");

                    b.HasKey("IdVerbale");

                    b.HasIndex("IdAnagrafica");

                    b.HasIndex("IdViolazione");

                    b.HasIndex("TipoViolazioneIdViolazione");

                    b.ToTable("Verbale");
                });

            modelBuilder.Entity("Cops.Models.Statistiche", b =>
                {
                    b.HasOne("Cops.Models.Anagrafica", "Anagrafica")
                        .WithMany()
                        .HasForeignKey("IdAnagrafica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anagrafica");
                });

            modelBuilder.Entity("Cops.Models.Verbale", b =>
                {
                    b.HasOne("Cops.Models.Anagrafica", "Anagrafica")
                        .WithMany("Verbali")
                        .HasForeignKey("IdAnagrafica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cops.Models.TipoViolazione", "TipoViolazione")
                        .WithMany()
                        .HasForeignKey("IdViolazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cops.Models.TipoViolazione", null)
                        .WithMany("Verbale")
                        .HasForeignKey("TipoViolazioneIdViolazione");

                    b.Navigation("Anagrafica");

                    b.Navigation("TipoViolazione");
                });

            modelBuilder.Entity("Cops.Models.Anagrafica", b =>
                {
                    b.Navigation("Verbali");
                });

            modelBuilder.Entity("Cops.Models.TipoViolazione", b =>
                {
                    b.Navigation("Verbale");
                });
#pragma warning restore 612, 618
        }
    }
}
