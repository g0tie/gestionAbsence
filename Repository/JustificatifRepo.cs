using System.Collections.Generic;
using System.Linq;
using GestionAbsence.Models;

namespace GestionAbsence.Repository
{
    public class JustificatifRepo
    {
        public static Justificatif Get(int id)
        {
            using GestionAbsenceDbContext db = new();
            return db.Justificatifs.Find(id);
        }

        public static List<Justificatif> GetAll()
        {
            using GestionAbsenceDbContext db = new();
            return db.Justificatifs.ToList();
        }

        public static void Add(Justificatif justificatif)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Justificatifs.Add(justificatif);
            _ = db.SaveChanges();
        }

        public static void Delete(Justificatif justificatif)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Justificatifs.Remove(justificatif);
            _ = db.SaveChanges();
        }

        public static void Update(Justificatif justificatif)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Justificatifs.Update(justificatif);
            _ = db.SaveChanges();
        }
    }
}
