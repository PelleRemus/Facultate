using System;

namespace CriptosistemSimetric
{
    internal class MonoSubstitutie : CriptosistemSimetric
    {
        internal Random r = new Random();
        double[] procenteIntermediare = new double[26];

        internal MonoSubstitutie(string text)
        {
            GenerareCheie(text);
            cheieGasita = cheie;
        }

        protected override void GenerareCheie(string text)
        {
            textInitial = text;
            cheie.n = 1;
            cheie.values = new char[1][];
            cheie.values[0] = new char[26];
            char a = 'a';

            int[] v = new int[26];
            for (int i = 0; i < 26; i++)
                v[i] = i;

            for (int i = 25; i >= 0; i--)
            {
                int index = r.Next(i);
                int temp = v[i];
                v[i] = v[index];
                v[index] = temp;
            }

            for(int i=0; i<26; i++)
                cheie.values[0][i] = (char)(a + v[i]);
        }

        internal override void CriptAnaliza()
        {
            cheieGasita.values[0] = new char[26];
            bool[] parcurs = new bool[26];
            CalculeazaAparitii(textCriptat, procenteIntermediare);

            for(int i=0; i<procenteImplicite.Length; i++)
            {
                for(int j=0; j<procenteIntermediare.Length; j++)
                {
                    if (!(procenteIntermediare[j] - 0.001 < procenteImplicite[i]
                        || procenteIntermediare[j] + 0.001 > procenteImplicite[i])
                        && !parcurs[j])
                    {
                        parcurs[j] = true;
                        cheieGasita.values[0][i] = (char)(97 + j);
                        break;
                    }
                }
            }

            Decriptare();
            CalculeazaAparitii(textDecriptat, procenteLaDecriptare);
        }
    }
}
