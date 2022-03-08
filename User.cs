using System.Collections.Generic;

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

        public List<Retard> Retards
        {
            get;
            set;
        } = new List<Retard>();

        public List<Absence> Absences
        {
            get;
            set;
        } = new List<Absence>();

        public void GetAbsences()
        {
            throw new System.NotImplementedException();
        }

        public void GetRetards()
        {
            throw new System.NotImplementedException();
        }

        public void GetRole()
        {
            throw new System.NotImplementedException();
        }
    }
}