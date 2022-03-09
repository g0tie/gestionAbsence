using Microsoft.EntityFrameworkCore;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace GestionAbsence
{

    public class GestionAbsenceDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            using var reader = new StreamReader("import.csv");

            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Role>();
            _ = modelBuilder.Entity<Role>().HasData(records);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=gestionAbsence.db");
        public DbSet<Role> Roles { get; set; }
        public DbSet<Justificatif> Justificatifs { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
