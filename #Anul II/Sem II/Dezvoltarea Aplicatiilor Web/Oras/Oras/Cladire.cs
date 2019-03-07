using System.Collections.Generic;

namespace Oras
{
    public abstract class Cladire
    {
        public Strada strada;
        public int Numar { get; set; }
        public float Suprafata { get; set; }

        public Cladire(Strada strada, int numar, float arie)
        {
            this.strada = strada;
            Numar = numar;
            Suprafata = arie;
        }
    }

    public class Institutie: Cladire
    {
        public Persoana administrator;
        public List<Persoana> angajati;
        public List<Persoana> interni;
        public Institutii Tip { get; set; }
        public string Nume { get; set; }

        public Institutie(Strada strada, int numar, float arie, Persoana administrator, List<Persoana> angajati,
            List<Persoana> interni, Institutii Tip, string Nume): base(strada, numar, arie)
        {
            this.administrator = administrator;
            this.angajati = angajati;
            this.interni = interni;
            this.Tip = Tip;
            this.Nume = Nume;
        }
    }

    public class Comerciala: Cladire
    {
        public Persoana administrator;
        public List<Persoana> angajati;
        public List<Persoana> clienti;
        public CladiriComerciale Tip { get; set; }
        public string Nume { get; set; }
        public int oraDeschidere;
        public int oraInchidere;

        public Comerciala(Strada strada, int numar, float arie, Persoana administrator, List<Persoana> angajati,
            List<Persoana> clienti, CladiriComerciale Tip, string Nume, int oraDeschidere, int oraInchidere)
            :base(strada, numar, arie)
        {
            this.administrator = administrator;
            this.angajati = angajati;
            this.clienti = clienti;
            this.Tip = Tip;
            this.Nume = Nume;
            this.oraDeschidere = oraDeschidere;
            this.oraInchidere = oraInchidere;
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
