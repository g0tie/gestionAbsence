using Microsoft.EntityFrameworkCore;

namespace GestionAbsence
{
    public class GestionAbsenceDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=gestionAbsence.db");

        public DbSet<Role> Roles { get; set; }
        public DbSet<Justificatif> Justificatifs { get; set; }
        public DbSet<Retard> Retards { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
