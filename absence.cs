using System;
using System.Collections.Generic;

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

        public void GetJustificatifs()
        {
            throw new System.NotImplementedException();
        }
    }
}