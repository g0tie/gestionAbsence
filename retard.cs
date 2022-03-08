using System;
using System.Collections.Generic;

namespace GestionAbsence
{
    public class Retard
    {

        public int Id
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int Duree
        {
            get;
            set;
        }

        public bool IsMatin
        {
            get;
            set;
        }

        public List<Justificatif> Justificatifs
        {
            get;
            set;

        } = new List<Justificatif>();

        public void GetJustificatifs()
        {
            throw new System.NotImplementedException();
        }
    }
}