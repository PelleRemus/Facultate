namespace Oras
{
    public class Strada
    {
        public int nod1, nod2;
        public int lungime;
        public string Nume { get; set; }

        public Strada(int i, int j, int lungime, string Nume)
        {
            nod1 = i;
            nod2 = j;
            this.lungime = lungime;
            this.Nume = Nume;
        }
    }
}
