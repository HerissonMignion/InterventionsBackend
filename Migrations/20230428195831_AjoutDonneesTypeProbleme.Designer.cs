﻿// <auto-generated />
using System;
using InterventionsBackend.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterventionsBackend.Migrations
{
    [DbContext(typeof(InterventionsDbContext))]
    [Migration("20230428195831_AjoutDonneesTypeProbleme")]
    partial class AjoutDonneesTypeProbleme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("InterventionsBackend.Entities.Probleme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("courriel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("courrielConfirmation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dateProbleme")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("descriptionProbleme")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("noTypeProbleme")
                        .HasColumnType("int");

                    b.Property<string>("noUnite")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("notification")
                        .HasColumnType("int");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Problemes");
                });

            modelBuilder.Entity("InterventionsBackend.Entities.TypeProbleme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TypesProbleme");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Problème d'écran"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Problème avec le disque dur"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Problème de connexion réseau"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Problème avec la souris"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Problème de clavier"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Problème d'ouverture du logiciel Ms-Word"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Problème d'ouverture du logiciel Ms-Excel"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Problème d'imprimante"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Problème entre la chaise et le clavier..."
                        },
                        new
                        {
                            Id = 10,
                            Name = "Autre"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}