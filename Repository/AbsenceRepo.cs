using System.Collections.Generic;
using System.Linq;
using GestionAbsence.Models;

namespace GestionAbsence
{
    public class AbsenceRepo
    {
        public static Absence Get(int id)
        {
            using GestionAbsenceDbContext db = new();
            return db.Absences.Find(id);
        }

        public static List<Absence> GetAll()
        {
            using GestionAbsenceDbContext db = new();
            return db.Absences.ToList();
        }

        public static void Add(Absence absence)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Absences.Add(absence);
            _ = db.SaveChanges();
        }

        public static void Delete(Absence absence)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Absences.Remove(absence);
            _ = db.SaveChanges();
        }

        public static void Update(Absence absence)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Absences.Update(absence);
            _ = db.SaveChanges();
        }
    }
}
