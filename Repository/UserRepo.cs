using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using GestionAbsence.Models;
namespace GestionAbsence
{
    public class UserRepo
    {
        public static User Get(int id)
        {
            using GestionAbsenceDbContext db = new();
            return db.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
        }
        public static List<User> GetAll()
        {
            using GestionAbsenceDbContext db = new();
            return db.Users.Include(x => x.Role).ToList();
        }

        public static void Add(User user)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Users.Add(user);
            _ = db.SaveChanges();
        }

        public static void Delete(User user)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Users.Remove(user);
            _ = db.SaveChanges();
        }

        public static void Update(User user)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Users.Update(user);
            _ = db.SaveChanges();
        }
    }
}