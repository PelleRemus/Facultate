using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortari_eficiente
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int[] v = new int[] { 12, 1, 4, 3, 7, 8, 5, 6, 9, 11, 10, 21, 14, 18, 15, 19, 24 };
            //MergeSort(v, 0, v.Length - 1);
            Quicksort(ref v, 0, v.Length - 1);

            for(int i=0; i<v.Length; i++)
                Console.Write(v[i]+" ");
            Console.ReadKey();
        }

        //pana la urmatorul comentariu, este cod pt Merge Sort
        static void MergeSort(int[] v, int st, int dr)
        {
            if (st < dr)
            {
                int m = (st + dr) / 2;
                MergeSort(v, st, m);
                MergeSort(v, m + 1, dr);
                Interclasare(v, st, m, dr);
            }
        }
        static void Interclasare(int[] v, int st, int m, int dr)
        {
            int[] _v = new int[dr - st + 2];
            int i = st, j = m + 1, k = 0;
            while (i <= m && j <= dr)
            {
                if (v[i] <= v[j])
                    _v[++k] = v[i++];
                else
                    _v[++k] = v[j++];
            }

            while (i <= m)
                _v[++k] = v[i++];
            while (j <= dr)
                _v[++k] = v[j++];
            for (i = 1; i <= k; ++i)
                v[st + i - 1] = _v[i];
        }

        //QuickSort // st = 0, dr = v.Length -1
        //Exista un pivot, elem. de la stanga la el sa fie mai mic decat el si la dr mai mare decat el.
        static int Partitie(int[] v, int st, int dr)
        {
            int poz = st + rnd.Next(0, dr - st + 1); //Se ia pozitia pivot la intamplare
            int tmp = v[poz];
            v[poz] = v[st];
            v[st] = tmp;
            int V = v[st];
            --st; ++dr;
            //Se reorganizeaza lista in functie de pivot a.i cele mai mici fata de pivot sunt inainte pivotului, iar cele
            //mai mari decat pivotul sa fie in partea dreapta.
            while (st < dr)
            {
                do
                    --dr;
                while (st < dr && v[dr] > V);
                do
                    ++st;
                while (st < dr && v[st] < V);
                if (st < dr)
                {
                    int aux = v[st];
                    v[st] = v[dr];
                    v[dr] = aux;
                }
            }
            return dr;
        }

        static void Quicksort(ref int[] v, int st, int dr)
        {
            while (st < dr)
            {
                int P = Partitie(v, st, dr);
                if (P - st < dr - P - 1)
                {
                    Quicksort(ref v, st, P);
                    st = P + 1;
                }
                else
                {
                    Quicksort(ref v, P + 1, dr);
                    dr = P;
                }
            }
        }
    }
}
