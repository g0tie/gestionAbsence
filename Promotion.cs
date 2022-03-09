using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionAbsence
{
    public class Promotion
    {
        public int Libelle
        {
            get;
            set;
        }

        public int DateDebut
        {
            get;
            set;
        }

        public int DateFin
        {
            get;
            set;
        }

        public List<User> Users
        {
            get;
            set;
        } = new List<User>();

        public void GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}