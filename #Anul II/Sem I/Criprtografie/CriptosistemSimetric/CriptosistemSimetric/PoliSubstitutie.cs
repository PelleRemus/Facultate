using System;

namespace CriptosistemSimetric
{
    internal class PoliSubstitutie : CriptosistemSimetric
    {
        internal Random r = new Random();

        internal PoliSubstitutie(string text)
        {
            GenerareCheie(text);
            cheieGasita = cheie;
        }

        protected override void GenerareCheie(string text)
        {
            textInitial = text;
            cheie.n = r.Next(2, 5);
            cheie.values = new char[cheie.n][];
            char a = 'a';

            int[] v = new int[26];
            for (int i = 0; i < 26; i++)
                v[i] = i;

            for (int i = 0; i < cheie.n; i++)
            {
                cheie.values[i] = new char[26];
                for (int j = 25; j >= 0; j--)
                {
                    int index = r.Next(j);
                    int temp = v[j];
                    v[j] = v[index];
                    v[index] = temp;
                }

                for (int j = 0; j < 26; j++)
                    cheie.values[i][j] = (char)(a + v[j]);
            }
        }

        internal override void CriptAnaliza()
        {
            
        }
    }
}
