using System.Collections.Generic;

namespace Oras
{
    public class Transport
    {
        public Strada strada;
        public Transporturi Tip { get; set; }
        public List<Oras> Destinatii;

        public Transport(Strada strada, Transporturi Tip, List<Oras> Destinatii)
        {
            this.strada = strada;
            this.Tip = Tip;
            this.Destinatii = Destinatii;
        }
    }
}
