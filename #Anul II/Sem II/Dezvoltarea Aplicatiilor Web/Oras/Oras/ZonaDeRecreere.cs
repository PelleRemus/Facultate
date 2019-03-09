using System.Collections.Generic;

namespace Oras
{
    public class ZonaDeRecreere
    {
        public Strada Strada { get; set; }

        public float Suprafata { get; set; }

        public ZoneDeRecreere Tip { get; set; }

        public List<Persoana> vizitatori;

        public ZonaDeRecreere(Strada Strada, float Suprafata, ZoneDeRecreere Tip, List<Persoana> vizitatori)
        {
            this.Strada = Strada;
            this.Suprafata = Suprafata;
            this.Tip = Tip;
            this.vizitatori = vizitatori;
        }
    }
}
