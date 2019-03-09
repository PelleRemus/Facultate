namespace Oras
{
    public class Strada
    {
        public int Nod1 { get; set; }

        public int Nod2 { get; set; }

        public int Lungime { get; set; }

        public string Nume { get; set; }

        public Strada(int Nod1, int Nod2, int Lungime, string Nume)
        {
            this.Nod1 = Nod1;
            this.Nod2 = Nod1;
            this.Lungime = Lungime;
            this.Nume = Nume;
        }
    }
}
