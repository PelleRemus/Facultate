using System.Collections.Generic;

namespace Oras
{
    public abstract class Cladire
    {
        public Strada Strada { get; set; }

        public int Numar { get; set; }

        public float Suprafata { get; set; }

        public Cladire(Strada Strada, int Numar, float Suprafata)
        {
            this.Strada = Strada;
            this.Numar = Numar;
            this.Suprafata = Suprafata;
        }
    }

    public class Institutie: Cladire
    {
        public Persoana Administrator { get; set; }

        public List<Persoana> angajati;

        public List<Persoana> interni;

        public Institutii Tip { get; set; }

        public string Nume { get; set; }

        public Institutie(Strada strada, int numar, float arie, Persoana Administrator, List<Persoana> angajati,
            List<Persoana> interni, Institutii Tip, string Nume): base(strada, numar, arie)
        {
            this.Administrator = Administrator;
            this.angajati = angajati;
            this.interni = interni;
            this.Tip = Tip;
            this.Nume = Nume;
        }
    }

    public class Comerciala: Cladire
    {
        public Persoana Administrator;

        public List<Persoana> angajati;

        public List<Persoana> clienti;

        public CladiriComerciale Tip { get; set; }

        public string Nume { get; set; }

        public int OraDeschidere { get; set; }

        public int OraInchidere { get; set; }

        public Comerciala(Strada strada, int numar, float arie, Persoana Administrator, List<Persoana> angajati,
            List<Persoana> clienti, CladiriComerciale Tip, string Nume, int OraDeschidere, int OraInchidere)
            :base(strada, numar, arie)
        {
            this.Administrator = Administrator;
            this.angajati = angajati;
            this.clienti = clienti;
            this.Tip = Tip;
            this.Nume = Nume;
            this.OraDeschidere = OraDeschidere;
            this.OraInchidere = OraInchidere;
        }
    }

    public class Rezidentiala: Cladire
    {
        public List<Persoana> rezidenti;

        public Rezidentiala(Strada strada, int numar, float arie, List<Persoana> rezidenti)
            :base(strada, numar, arie)
        {
            this.rezidenti = rezidenti;
        }
    }
}
