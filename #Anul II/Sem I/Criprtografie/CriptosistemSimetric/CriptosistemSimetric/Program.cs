using System.IO;

namespace CriptosistemSimetric
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader dataLoad = new StreamReader(@"..\..\Intrare.txt");
            string buffer, s = "";
            while ((buffer = dataLoad.ReadLine()) != null)
                s += buffer;
            StreamWriter data = new StreamWriter(@"..\..\Iesire.txt");

            CriptosistemSimetric c = new Cezar(s);
            AtribuireValori(c);
            data.WriteLine("--------------Cezar--------------");
            Afisare(c, data);

            c = new Rot13(s);
            AtribuireValori(c);
            data.WriteLine("--------------Rot13--------------");
            Afisare(c, data);

            c = new RotN(s, 7);
            AtribuireValori(c);
            data.WriteLine("--------------RotN--------------");
            Afisare(c, data);

            c = new MonoSubstitutie(s);
            AtribuireValori(c);
            data.WriteLine("--------------Substitutie MonoAlfabetica--------------");
            Afisare(c, data);

            c = new PoliSubstitutie(s);
            AtribuireValori(c);
            data.WriteLine("--------------Substitutie PoliAlfabetica--------------");
            Afisare(c, data);

            data.Close();
        }

        static void AtribuireValori(CriptosistemSimetric c)
        {
            c.Criptare();
            c.Decriptare();
            c.CalculeazaProcent();
        }

        static void Afisare(CriptosistemSimetric c, StreamWriter data)
        {
            data.WriteLine();
            data.WriteLine("   Text Criptat:");
            data.WriteLine(c.textCriptat);
            data.WriteLine();
            data.WriteLine("   Text Decriptat:");
            data.WriteLine(c.textDecriptat);
            data.WriteLine("   Acuratete: " + c.procent);
            data.WriteLine();

            if (!(c is PoliSubstitutie))
            {
                c.CriptAnaliza();
                data.WriteLine("   Text Decriptat prin Criptanaliza:");
                data.WriteLine(c.textDecriptat);
                c.CalculeazaProcent();
                data.WriteLine("   Acuratete: " + c.procent);
                data.WriteLine();
            }
            data.WriteLine();
        }
    }
}
