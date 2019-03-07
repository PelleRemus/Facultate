using System.Collections.Generic;

namespace Oras
{
    public class ZonaDeRecreere
    {
        public Strada strada;
        public float Suprafata { get; set; }
        public ZoneDeRecreere Tip { get; set; }
        public List<Persoana> vizitatori;

        public ZonaDeRecreere(Strada strada, float arie, ZoneDeRecreere Tip, List<Persoana> vizitatori)
        {
            this.strada = strada;
            Suprafata = arie;
            this.Tip = Tip;
            this.vizitatori = vizitatori;
        }
    }
}
