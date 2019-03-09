using System.Collections.Generic;

namespace Oras
{
    public class Oras
    {
        public string Nume { get; set; }

        public string Judet { get; set; }

        public string Tara { get; set; }

        public List<int> intersectii;

        public List<Strada> strazi;

        public List<Cladire> cladiri;

        public List<Persoana> locuitori;

        public List<ZonaDeRecreere> zoneDeRecreere;

        public List<Transport> transporturi;

        public Oras(string Nume, string Judet, string Tara, Strada[] strazi = null, Cladire[] cladiri = null, 
            Persoana[] locuitori = null, List<ZonaDeRecreere> zoneDeRecreere = null, List<Transport> transporturi = null)
        {
            this.Nume = Nume;
            this.Judet = Judet;
            this.Tara = Tara;
            this.cladiri = new List<Cladire>();
            this.intersectii = new List<int>();
            this.strazi = new List<Strada>();
            this.locuitori = new List<Persoana>();
            this.zoneDeRecreere = new List<ZonaDeRecreere>();
            this.transporturi = new List<Transport>();

            if (strazi != null)
            {
                for (int i = 0; i < strazi.Length; i++)
                    AdaugaStrada(strazi[i]);
            }

            if (cladiri != null)
            {
                for (int i = 0; i < cladiri.Length; i++)
                    AdaugaCladire(cladiri[i]);
            }

            if (locuitori != null)
            {
                for (int i = 0; i < locuitori.Length; i++)
                    AdaugaPersoana(locuitori[i]);
            }

            if (zoneDeRecreere != null)
            {
                this.zoneDeRecreere = zoneDeRecreere;
            }

            if (transporturi != null)
            {
                this.transporturi = transporturi;
            }
        }

        public void AdaugaStrada(Strada strada)
        {
            if (!strazi.Contains(strada))
            {
                AdaugaIntersectie(strada.Nod1);
                AdaugaIntersectie(strada.Nod2);
                strazi.Add(strada);
            }
        }

        public void AdaugaIntersectie(int intersectie)
        {
            if (!intersectii.Contains(intersectie))
                intersectii.Add(intersectie);
        }

        public void AdaugaCladire(Cladire cladire)
        {
            if (!cladiri.Exists(x => x.Strada.Equals(cladire.Strada) && x.Numar == cladire.Numar))
                cladiri.Add(cladire);
        }

        public void AdaugaPersoana(Persoana persoana)
        {
            if (!locuitori.Exists(x => x.CNP.Equals(persoana.CNP)))
                locuitori.Add(persoana);
        }
    }
}
