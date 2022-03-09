using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionAbsence
{
    public class Absence
    {

        public int Id
        {
            get;
            set;
        }

        public bool IsJournee
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public List<Justificatif> Justificatifs
        {
            get;
            set;

        } = new List<Justificatif>();

        public bool IsMatin
        {
            get;
            set;
        }

        public bool IsRetard
        {
            get;
            set;
        }

        public string Commentaire
        {
            get;
            set;
        }

        public int Duree

        {
            get;
            set;
        }

        public int UserId

        {
            get;
            set;
        }

        public void GetJustificatifs()
        {
            using GestionAbsenceDbContext db = new();
            Justificatifs = db.Justificatifs.Where(c => c.AbsenceId == Id).ToList();
        }

        public void GetUser()
        {
        }
    }
}