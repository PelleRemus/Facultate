using System.Collections.Generic;

namespace Oras
{
    public class Transport
    {
        public Strada Strada { get; set; }

        public Transporturi Tip { get; set; }

        public List<Oras> Destinatii;

        public Transport(Strada Strada, Transporturi Tip, List<Oras> Destinatii)
        {
            this.Strada = Strada;
            this.Tip = Tip;
            this.Destinatii = Destinatii;
        }
    }
}
