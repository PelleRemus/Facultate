namespace CriptosistemSimetric
{
    internal class RotN: CriptosistemSimetric
    {
        internal int n;

        internal RotN(string text, int value)
        {
            n = value;
            GenerareCheie(text);
            cheieGasita = cheie;
        }

        protected override void GenerareCheie(string text)
        {
            textInitial = text;
            cheie.n = 1;
            cheie.values = new char[1][];
            cheie.values[0] = new char[26];

            for (char i = 'a'; i <= 'z'; i++)
            {
                if (i + n <= 'z')
                    cheie.values[0][i-97] = (char)(i + n);
                else
                    cheie.values[0][i - 97] = (char)(i - 26 + n);
            }
        }

        internal override void CriptAnaliza()
        {
            for (int i = 1; i < 26; i++)
            {
                cheieGasita.values = new char[1][];
                cheieGasita.values[0] = new char[26];
                for (char j = 'a'; j <= 'z'; j++)
                {
                    if (j + i <= 'z')
                        cheieGasita.values[0][j - 97] += (char)(j + i);
                    else
                        cheieGasita.values[0][j - 97] += (char)(j - 26 + i);
                }

                Decriptare();
                CalculeazaAparitii(textDecriptat, procenteLaDecriptare);
                if (isCorrect())
                    return;
            }
        }
    }
}
