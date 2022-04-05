using Microsoft.EntityFrameworkCore;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;
using GestionAbsence.Models;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Linq;
using GestionAbsence.Services;

namespace GestionAbsence
{
    public class GestionAbsenceDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new Role[]
            {
                new Role { Id = 1, Libelle = "Admin"},
                new Role { Id = 2, Libelle = "Formateur"},
                new Role { Id = 3, Libelle = "Secretaire"},
                new Role { Id = 4, Libelle = "Apprenant"}
            };

            var users = new User[]
            {
                new User { Id = 1, Nom= "Admin", Prenom="Admin", Mail="Admin@gmail.com", Password=BcryptService.HashPassword( "Admin"), RoleId=1},
                new User { Id = 2, Nom= "Formateur", Prenom="Formateur", Mail="Formateur@gmail.com", Password=BcryptService.HashPassword( "Formateur"), RoleId=2},
                new User { Id = 3, Nom= "Secretaire", Prenom="Secretaire", Mail="Secretaire@gmail.com", Password=BcryptService.HashPassword( "Secretaire"), RoleId=3},
                new User { Id = 4, Nom= "Apprenant", Prenom="Apprenant", Mail="Apprenant@gmail.com", Password=BcryptService.HashPassword( "Apprenant"), RoleId=4},
            };

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=gestionAbsence.db");
        public DbSet<Role> Roles { get; set; }
        public DbSet<Justificatif> Justificatifs { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
