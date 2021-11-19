using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoadaListaStiva
{
    public class ListaOrdonata
    {
        public int n;
        public int[] v;

        public ListaOrdonata()
        {
            n = 0;
            v = new int[0];
        }

        public void AdaugareOrdonata(int value)
        {
            n++;
            int[] newV = new int[n];
            int index = 0;

            //cat timp valorile vectorului sunt mai mici decat valoarea pe care dorim sa o adaugam, copiem aceste valori in noul vector (verificam ca index sa nu depaseasca dimensiunea lui v)
            while (index < n - 1 && v[index] < value)
            {
                newV[index] = v[index];
                index++;
            }

            //adaugam valoarea la locul potrivit
            newV[index] = value;

            //si adaugam restul valorilor in vector
            while (index < n - 1)
            {
                newV[index + 1] = v[index];
                index++;
            }
            v = newV;
        }

        public void StergereElement(int value)
        {
            //dorim sa stergem toate numerele value din vector, deci numaram de cate ori apare 
            int count = 0;
            for (int i = 0; i < n; i++)
                if (v[i] == value)
                    count++;
            int[] newV = new int[n - count];

            //avem nevoie de inca un index pentru noul vector; adaugam valorile in el doar daca acestea nu sunt value
            int index = 0;
            for (int i = 0; i < n; i++)
                if (v[i] != value)
                {
                    newV[index] = v[i];
                    index++;
                }
            n = index;
            v = newV;
        }

        public void Afisare()
        {
            for (int i = 0; i < n; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }
    }
}
