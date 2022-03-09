using System.Collections.Generic;
using System.Linq;
namespace GestionAbsence
{
    public class User
    {

        public int Id
        {
            get;
            set;
        }

        public string Nom
        {
            get;
            set;
        }

        public string Prenom
        {
            get;
            set;
        }

        public string Mail
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public int RoleId
        {
            get;
            set;
        }

        public Role Role
        {
            get;
            set;
        }

        public List<Absence> Absences
        {
            get;
            set;
        } = new List<Absence>();


        public void GetAbsences()
        {
            using GestionAbsenceDbContext db = new();
            Absences = db.Absences.Where(c => c.UserId == Id).ToList();
        }


        public void GetRole()
        {
            using GestionAbsenceDbContext db = new();
            Role = db.Roles.Where(c => c.Id == RoleId).First();

        }

    }
}