using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionAbsence
{
    public class Absence
    {

        public int id
        {
            get => default;
            set
            {
            }
        }

        public bool isJournee
        {
            get => default;
            set
            {
            }
        }

        public DateTime date
        {
            get => default;
            set
            {
            }
        }

        public int user_id
        {
            get => default;
            set
            {
            }
        }

        public List<Justificatif> Justificatifs
        {
            get => default;
            set
            {
            }
        }

        public bool isMatin
        {
            get => default;
            set
            {
            }
        }

        public void getJustificatifs()
        {
            throw new System.NotImplementedException();
        }
    }
}