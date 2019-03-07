using System;

namespace Oras
{
    public class Persoana
    {
        public string CNP { get; set; }
        public DateTime DataNasterii { get; set; }
        public int Varsta { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Sex { get; set; }

        public Persoana(string cnp, DateTime an, string nume, string prenume, string sex)
        {
            CNP = cnp;
            DataNasterii = an;
            Varsta = (int)(float)((DateTime.Now - DataNasterii).Days / 365.25);
            Nume = nume;
            Prenume = prenume;
            Sex = sex;
        }

        public void UpdateVarsta()
        {
            if (DateTime.Now.Month == DataNasterii.Month && DateTime.Now.Day == DataNasterii.Day)
                Varsta++;
        }

        public bool isMajor()
        {
            if (Varsta >= 18)
                return true;
            return false;
        }
    }
}
