using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adresa
{
    public enum TipAdresa
    {
        simpla,
        medie,
        extinsa
    }

    public static class Engine
    {
        public static List<Adresa> adrese = new List<Adresa>();

        public static void Init()
        {
            Adresa a = new AdresaSimpla("Alfa", "0722752222");
            adrese.Add(a);
            Adresa b = new AdresaSimpla("Beta", "0777777777");
            adrese.Add(b);

            Adresa c = new AdresaMedie("alfa", "0771503874");
            c.Add("fdsliHASFOIJV");
            c.Add("sawirucvma");
            c.Add("sdryicnjhmd26ii");
            adrese.Add(c);

            Adresa d = new AdresaExtinsa("beta", "0753115749", "beta_2@gmail.com");
            d.Add("fdsliHASFOIJV");
            d.Add("sawirucvma");
            d.Add("sdryicnjhmd26ii");

            (d as AdresaExtinsa).AddDataC("fdsASFOI");
            (d as AdresaExtinsa).AddDataC("sawivma");
            adrese.Add(d);

            adrese[3].Save(@"../../Adrese.txt");
        }
    }
}
