using System.Collections.Generic;
using System.Linq;


namespace GestionAbsence
{
    public class RetardRepo
    {
        public static Retard Get(int id)
        {
            using GestionAbsenceDbContext db = new();
            return db.Retards.Find(id);
        }

        public static List<Retard> GetAll()
        {
            using GestionAbsenceDbContext db = new();
            return db.Retards.ToList();
        }

        public static void Add(Retard retard)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Retards.Add(retard);
        }

        public static void Delete(Retard retard)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Retards.Remove(retard);
        }

        public static void Update(Retard retard)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Retards.Update(retard);
        }
    }
}
