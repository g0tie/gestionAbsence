﻿// <auto-generated />
using System;
using GestionAbsence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionAbsence.Migrations
{
    [DbContext(typeof(GestionAbsenceDbContext))]
    [Migration("20220310081317_updateUser")]
    partial class updateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GestionAbsence.Models.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Commentaire")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duree")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsJournee")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMatin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRetard")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("GestionAbsence.Models.Justificatif", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbsenceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chemin")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceId");

                    b.ToTable("Justificatifs");
                });

            modelBuilder.Entity("GestionAbsence.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Libelle")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Libelle = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Libelle = "Formateur"
                        },
                        new
                        {
                            Id = 3,
                            Libelle = "Secretaire"
                        },
                        new
                        {
                            Id = 4,
                            Libelle = "Apprenant"
                        });
                });

            modelBuilder.Entity("GestionAbsence.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Mail = "Admin@gmail.com",
                            Nom = "Admin",
                            Password = "Admin",
                            Prenom = "Admin",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Mail = "Formateur@gmail.com",
                            Nom = "Formateur",
                            Password = "Formateur",
                            Prenom = "Formateur",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Mail = "Secretaire@gmail.com",
                            Nom = "Secretaire",
                            Password = "Secretaire",
                            Prenom = "Secretaire",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 4,
                            Mail = "Apprenant@gmail.com",
                            Nom = "Apprenant",
                            Password = "Apprenant",
                            Prenom = "Apprenant",
                            RoleId = 4
                        });
                });

            modelBuilder.Entity("GestionAbsence.Models.Absence", b =>
                {
                    b.HasOne("GestionAbsence.Models.User", null)
                        .WithMany("Absences")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionAbsence.Models.Justificatif", b =>
                {
                    b.HasOne("GestionAbsence.Models.Absence", null)
                        .WithMany("Justificatifs")
                        .HasForeignKey("AbsenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionAbsence.Models.User", b =>
                {
                    b.HasOne("GestionAbsence.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GestionAbsence.Models.Absence", b =>
                {
                    b.Navigation("Justificatifs");
                });

            modelBuilder.Entity("GestionAbsence.Models.User", b =>
                {
                    b.Navigation("Absences");
                });
#pragma warning restore 612, 618
        }
    }
}
