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
            return db.Users.Find(id);
        }
        public static List<User> GetAll()
        {
            using GestionAbsenceDbContext db = new();
            return db.Users.ToList();
        }

        public static void Add(User user)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Users.Add(user);
        }

        public static void Delete(User user)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Users.Remove(user);
        }

        public static void Update(User user)
        {
            using GestionAbsenceDbContext db = new();
            _ = db.Users.Update(user);
        }
    }
}