using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionAbsence
{
    public class User
    {

        public int id
        {
            get => default;
            set
            {
            }
        }

        public String nom
        {
            get => default;
            set
            {
            }
        }

        public String prenom
        {
            get => default;
            set
            {
            }
        }

        public string mail
        {
            get => default;
            set
            {
            }
        }

        public string password
        {
            get => default;
            set
            {
            }
        }

        public int role_id
        {
            get => default;
            set
            {
            }
        }

        public Role role
        {
            get => default;
            set
            {
            }
        }

        public List<Retard> retards
        {
            get => default;
            set
            {
            }
        }

        public List<Absence> absences
        {
            get => default;
            set
            {
            }
        }

        public void getAbsences()
        {
            throw new System.NotImplementedException();
        }

        public void getRetards()
        {
            throw new System.NotImplementedException();
        }

        public void getRole()
        {
            throw new System.NotImplementedException();
        }
    }

    public class CopyOfUser
    {
    }
}