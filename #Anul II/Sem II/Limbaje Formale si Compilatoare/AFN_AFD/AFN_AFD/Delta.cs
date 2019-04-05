namespace AFN_AFD
{
    public class Delta
    {
        public string stare1;
        public char litera;
        public string stare2;

        public Delta(string stare1, char litera, string stare2)
        {
            this.stare1 = stare1;
            this.litera = litera;
            this.stare2 = stare2;
        }

        public string View(string cuvant)
        {
            return "delta(" + stare1 + ", " + cuvant + ") = " + stare2;
        }

        public override string ToString()
        {
            return "delta(" + stare1 + ", " + litera + ") = " + stare2;
        }
    }
}
