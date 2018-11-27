namespace CriptosistemSimetric
{
    internal abstract class CriptosistemSimetric
    {
        internal string textInitial;
        internal string textCriptat;
        internal string textDecriptat;

        static internal double[] procenteImplicite = new double[]
        { 0.08167, 0.01492, 0.02782, 0.04253, 0.12702, 0.02228, 0.02015, 0.06094, 0.06966, 0.00153, 0.03872, 0.04025, 0.02406, 0.06749, 0.07507, 0.01929, 0.00095, 0.05987, 0.06327, 0.09256, 0.02758, 0.00978, 0.05370, 0.00150, 0.03978, 0.00074};
        internal double[] procenteLaDecriptare = new double[26];
        internal double procent;

        protected struct Key
        {
            internal int n;
            internal char[][] values;
        }
        protected Key cheie;
        protected Key cheieGasita;

        protected abstract void GenerareCheie(string text);
        internal abstract void CriptAnaliza();

        internal virtual void Criptare()
        {
            string tf = "";
            string ti = textInitial;
            int k = 0;
            for (int i = 0; i < ti.Length; i++)
            {
                if (!char.IsLetter(ti[i]))
                    tf += ti[i];
                else
                {
                    char a = 'a';
                    char aux = ti[i];
                    if (char.IsUpper(aux))
                    {
                        a = 'A';
                        tf += (char)(cheieGasita.values[k][aux - a] - 32);
                    }
                    else
                        tf += cheieGasita.values[k][aux - a];

                    k++;
                    if (k == cheieGasita.n)
                        k = 0;
                }
            }
            textCriptat = tf;
        }

        internal virtual void Decriptare()
        {
            string tf = "";
            string ti = textCriptat;
            int k = 0;
            for (int i = 0; i < ti.Length; i++)
            {
                if (!char.IsLetter(ti[i]))
                    tf += ti[i];
                else
                {
                    char a = 'a';
                    char aux = ti[i];
                    if (char.IsUpper(aux))
                    {
                        a = 'A';
                        aux = (char)(aux + 32);
                    }

                    string temp = "";
                    foreach (char c in cheieGasita.values[k])
                        temp += c;
                    tf += (char)(a + temp.IndexOf(aux));

                    k++;
                    if (k == cheieGasita.n)
                        k = 0;
                }
            }
            textDecriptat = tf;
        }

        internal void CalculeazaAparitii(string check, double[] procente)
        {
            int length = textInitial.Length;
            for(int i=0; i< check.Length; i++)
            {
                char temp = check[i];
                if (char.IsLetter(temp))
                {
                    if (char.IsUpper(temp))
                        temp = (char)(temp + 32);
                    procente[temp - 97]++;
                }
                else
                    length--;
            }

            for (int i = 0; i < procente.Length; i++)
                procente[i] /= length;
        }

        protected bool isCorrect()
        {
            for (int i = 0; i < procenteLaDecriptare.Length; i++)
                if (!(procenteLaDecriptare[i] - 0.001 < procenteImplicite[i]
                    || procenteLaDecriptare[i] + 0.001 > procenteImplicite[i]))
                    return false;
            return true;
        }

        internal void CalculeazaProcent()
        {
            double k = 0;
            for (int i = 0; i < textInitial.Length; i++)
                if (textInitial[i] == textDecriptat[i])
                    k++;
            procent = k / textInitial.Length;
        }
    }
}
