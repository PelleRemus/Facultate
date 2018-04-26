using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portofoliu
{
    class Program
    {
        static void Main(string[] args)
        {
            //2
            /*int a, b, c, d, e;
            Random r = new Random();
            a = r.Next(10); b = r.Next(10); c = r.Next(10); d = r.Next(10); e = r.Next(10);
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", a, b, c, d, e);
            if (a==b&&a==c&&a==d&&a==e)
                Console.WriteLine("Toate valorile sunt identice");
            else if((a==b&&a==c&&a==d)||(a==b&&a==c&&a==e)||(a==b&&a==d&&a==e)||(a==c&&a==d&&a==e)||(b==c&&b==d&&b==e))
                Console.WriteLine("Exista 4 valori identice");
            else if ((a==b&&a==c&&d==e)||(a==b&&a==d&&c==e)||(a==b&&a==e&&c==d)||(a==c&&a==d&&b==e)||(a==c&&a==e&&b==d)||(a==d&&a==e&&b==c)||(b==c&&b==d&&a==e)||(b==c&&b==e&&a==d)||(b==d&&b==e&&a==c)||(c==d&&c==e&&a==b))
                Console.WriteLine("Exista 3 valori identice, iar celelalte doua sunt si ele identice");
            else if((a==b&&a==c)||(a==b&&a==d)||(a==b&&a==e)||(a==c&&a==d)||(a==c&&a==e)||(a==d&&a==e)||(b==c&&b==d)||(b==c&&b==e)||(b==d&&b==e)||(c==d&&c==e))
                Console.WriteLine("Exista 3 valori identice");
            else if((a==b&&c==d)||(a==b&&d==e)||(a==b&&c==e)||(a==c&&b==d)||(a==c&&b==e)||(a==c&&d==e)||(a==d&&b==c)||(a==d&&b==e)||(a==d&&c==e)||(a==e&&b==c)||(a==e&&b==d)||(a==e&&c==d))
                Console.WriteLine("Exista doua cate doua valori identice");
            else if(a==b||a==c||a==d||a==e||b==c||b==d||b==e||c==d||c==e||d==e)
                Console.WriteLine("Exista doua valori identice");
            else Console.WriteLine("Nimic special");
            Console.ReadKey();
            */

            //3
            /*Random r = new Random();
            int n = r.Next(1, 100);
            if (Prim(n))
                Console.WriteLine("Numarul " + n + " este prim");
            else
                Console.WriteLine("Numarul " + n + " nu este prim");
            Console.ReadKey();
            */

            //4
            /*Random r = new Random();
            int n = r.Next(10000, 100000);
            Console.Write("Cifrele numarului " + n + " sunt: ");
            while (n>0)
            {
                Console.Write(n % 10 + " ");
                n /= 10;
            }
            Console.ReadKey();
            */

            //5
            /*int n = int.Parse(Console.ReadLine());
            int min = n, nr = 1;
            while(true)
            {
                n = int.Parse(Console.ReadLine());
                if (n == 0) break;
                if (n == min) nr++;
                if (n < min)
                {
                    min = n;
                    nr = 1;
                }
            }
            Console.WriteLine(min + ", " + nr);
            Console.ReadKey();
            */

            //6
            /*int n = int.Parse(Console.ReadLine());
            if (n == Oglindit(n))
                Console.WriteLine(n + " este palindrom");
            else
                Console.WriteLine(n + " nu este palindrom");
            Console.ReadKey();
            */

            //7
            /*int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Cel mai mare divizor comun al acestor numere este " + CMMDC(a, b));
            Console.WriteLine("Cel mai mic multiplu comun al acestor numere este " + CMMMC(a, b));
            Console.ReadKey();
            */

            //8
            /*int n = 10, s = 0, p = 1;
            int[] v = new int[n];
            DauValoareVector(v, 10);
            AfisareVector(v);
            for (int i = 0; i < n; i++)
            {
                s += v[i];
                p *= v[i];
            }
            Console.WriteLine("Suma elementelor vectorului este: " + s);
            Console.WriteLine("Produsul elementelor vectorului este: " + p);
            Console.ReadKey();
            */

            //9
            /*int n = 20;
            int[] v = new int[n];
            DauValoareVector(v, 100);
            AfisareVector(v);
            int min = v[0], max = v[0];
            for (int i=0; i<n; i++)
            {
                if (min > v[i]) min = v[i];
                if (max < v[i]) max = v[i];
            }
            Console.WriteLine("Minimul vectorului este " + min + " iar maximul este " + max);
            Console.ReadKey();
            */

            //10
            /*Random r = new Random();
            int n = 20;
            int[] v = new int[n];
            for (int i = 0; i < 7; i++)
                v[i] = r.Next(-100, 100);
            AfisareVector(v);
            int[] semn = new int[n];
            int s = 0, d = n - 1;
            for (int i=0; i<n; i++)
            {
                if (v[i]<0)
                {
                    semn[s] = v[i];
                    s++;
                }
                if (v[i]>0)
                {
                    semn[d] = v[i];
                    d--;
                }
            }
            for (int i = 0; i < n; i++)
                Console.Write(semn[i] + " ");
            Console.ReadKey();
            */

            //11
            /*int n = 20;
            int[] v = new int[n];
            DauValoareVector(v, 100);
            AfisareVector(v);
            BubbleSort(v);
            AfisareVector(v);
            Console.ReadKey();
            */

            //12
            /*int n = 20;
            int[] v = new int[n];
            DauValoareVector(v, 100);
            AfisareVector(v);
            SelectionSort(v);
            AfisareVector(v);
            Console.ReadKey();
            */

            //14
            /*int n = 20;
            int[] v = new int[n];
            DauValoareVector(v, 100);
            AfisareVector(v);
            InsertionSort(v);
            AfisareVector(v);
            Console.ReadKey();
            */

            //15
            /*int n = 10;
            int[] v1 = new int[n];
            int[] v2 = new int[n];
            int[] v3 = new int[2 * n];
            DauValoareVector(v1, 100);
            DauValoareVector(v2, 100);
            AfisareVector(v1);
            AfisareVector(v2);
            for (int i = 0; i < 2 * n; i++)
            {
                if (i < n)
                    v3[i] = v1[i];
                else
                    v3[i] = v2[i - n];
            }
            AfisareVector(v3);
            Console.ReadKey();
            */

            //16
            /*int n = 10, limita = 20;
            int[] v1 = new int[n];
            int[] v2 = new int[n];
            DauValoareVector(v1, limita);
            DauValoareVector(v2, limita);
            AfisareVector(v1);
            AfisareVector(v2);
            List<int> reuniune = Reuniune(v1, v2, limita);
            for (int i = 0; i < reuniune.Count; i++)
                Console.Write(reuniune[i] + " ");
            Console.ReadKey();
            */

            //17
            /*int n = 10, limita = 20;
            int[] v1 = new int[n];
            int[] v2 = new int[n];
            DauValoareVector(v1, limita);
            DauValoareVector(v2, limita);
            AfisareVector(v1);
            AfisareVector(v2);
            List<int> intersectie = Intersectie(v1, v2, limita);
            for (int i = 0; i < intersectie.Count; i++)
                Console.Write(intersectie[i] + " ");
            Console.ReadKey();
            */

            //18
            /*int n = 10, limita = 20;
            int[] v1 = new int[n];
            int[] v2 = new int[n];
            DauValoareVector(v1, limita);
            DauValoareVector(v2, limita);
            AfisareVector(v1);
            AfisareVector(v2);
            List<int> intersectie = Intersectie(v1, v2, limita);
            int[] diferenta = new int[n-intersectie.Count];
            int k = 0;
            for (int i=0; i<n; i++)
                if (!intersectie.Contains(v1[i]))
                {
                    diferenta[k] = v1[i];
                    k++;
                }
            AfisareVector(diferenta);
            Console.ReadKey();
            */

            //19
            /*int n = 10, m = 20, count = 0;
            int[] v1 = new int[n];
            int[] v2 = new int[m];
            DauValoareVector(v1, 5);
            DauValoareVector(v2, 5);
            AfisareVector(v1);
            AfisareVector(v2);
            for (int i=0; i<m; i++)
            {
                bool ok = false;
                if (v2[i] == v1[0] && i + n < m)
                {
                    ok = true;
                    for (int j = 1; j < n; j++)
                        if (v1[i + j] != v2[j])
                        {
                            ok = false;
                            break;
                        }
                }
                if (ok) count++;
            }
            Console.WriteLine("Vectorul v1 apare de " + count + " ori in vectorul v2");
            Console.ReadKey();
            */

            //22
            /*int n = 5, m = 8;
            int[,] matrix = new int[n, m];
            int[] v = new int[n * m];
            int k = 0, prim = 2;
            while (k < n * m)
            {
                if (Prim(prim))
                {
                    v[k] = prim;
                    k++;
                }
                prim++;
            }
            k = 0;
            for (int i=0; i<n; i++)
                for (int j=0; j<m; j++)
                {
                    matrix[i, j] = v[k];
                    k++;
                }
            AfisareMatrice(matrix);
            Console.ReadKey();
            */

            //23
            /*int n = 10;
            int[,] m = new int[n, n];
            for (int i = 0; i<n; i++)
                for(int j=0; j<n; j++)
                {
                    if (i < n / 2 && j < n / 2) m[i, j] = 1;
                    if (i < n / 2 && j >= n / 2) m[i, j] = 2;
                    if (i >= n / 2 && j < n / 2) m[i, j] = 3;
                    if (i >= n / 2 && j >= n / 2) m[i, j] = 4;
                }
            AfisareMatrice(m);
            for (int i = 0; i < n / 2; i++)
                for (int j = i; j < n - i; j++)
                {
                    m[i, j] = 1;
                    m[n - 1 - j, n - 1 - i] = 2;
                    m[n - 1 - i, j] = 3;
                    m[j, i] = 4;
                }
            AfisareMatrice(m);
            Console.ReadKey();
            */

            //24
            /*int n = 10;
            int[,] m = new int[n, n];
            int k = 0, x = 0;
            while (k <= n / 2)
            {
                for (int i = k; i < n - 1 - k; i++)
                {
                    m[k, i] = x;
                    x++;
                }
                for (int i = k; i < n - 1 - k; i++)
                {
                    m[i, n - 1 - k] = x;
                    x++;
                }
                for (int i = k; i < n - 1 - k; i++)
                {
                    m[n - 1 - k, n - 1 - i] = x;
                    x++;
                }
                for (int i = k; i < n - 1 - k; i++)
                {
                    m[n - 1 - i, k] = x;
                    x++;
                }
                k++;
            }
            AfisareMatrice(m);
            Console.ReadKey();
            */

            //27
            /*Random r = new Random();
            int n = 10, count = 0;
            int[,] m1 = new int[n, n];
            int[,] m2 = new int[n / 2, n / 2];
            for (int i=0; i<n; i++)
                for (int j=0; j<n; j++)
                {
                    m1[i, j] = r.Next(10);
                    if (i < n / 2 && j < n / 2) m2[i, j] = r.Next(10);
                }
            AfisareMatrice(m1);
            AfisareMatrice(m2);
            for (int i=0; i<n; i++)
                for (int j=0; j<n; j++)
                {
                    bool ok = false;
                    if (m1[i, j] == m2[0, 0] && i < n / 2 && j < n / 2)
                    {
                        ok = true;
                        for (int k=0; k<n/2; k++)
                            for (int l=0; l<n/2; l++)
                                if (m1[i+k, j+l]!=m2[k,l])
                                    ok = false;
                    }
                    if (ok) count++;
                }
            if (count == 0)
                Console.WriteLine("Matricea m2 nu se include in matricea m1");
            else
                Console.WriteLine("Matricea m2 se include in matricea m1 de " + count + " ori");
            Console.ReadKey();
            */

            //28
            /*int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
            Console.ReadKey();
            */

            //29
            /*int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n));
            Console.ReadKey();
            */


        }

        public static void AfisareMatrice(int[,] matrix)
        {
            for(int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void AfisareVector(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i] + " ");
            Console.WriteLine();
        }

        public static void DauValoareVector(int[] v, int limita)
        {
            Random r = new Random();
            for (int i = 0; i < v.Length; i++)
                v[i] = r.Next(limita);
        }
        //
        //29
        //
        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fibonacci(n - 2) + Fibonacci(n - 1);
        }
        //
        //28
        //
        static int Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }
        //
        //17
        //
        static List<int> Intersectie(int[] v1, int[] v2, int limita)
        {
            int n1 = v1.Length, n2 = v2.Length;
            int[] c1 = new int[limita];
            int[] c2 = new int[limita];
            List<int> intersectie = new List<int>();
            for (int i = 0; i < n1; i++)
                c1[v1[i]]++;
            for (int i = 0; i < n2; i++)
                c2[v2[i]]++;
            for (int i = 0; i < limita; i++)
                if (c1[i] != 0 && c2[i] != 0)
                    intersectie.Add(i);
            return intersectie;
        }
        //
        //16
        //
        static List<int> Reuniune(int[]v1, int[]v2, int limita)
        {
            int n1 = v1.Length, n2 = v2.Length;
            int[] c = new int[limita];
            List<int> reuniune = new List<int>();
            for (int i = 0; i < n1; i++)
                c[v1[i]]++;
            for (int i = 0; i < n2; i++)
                c[v2[i]]++;
            for (int i = 0; i < limita; i++)
                if (c[i] != 0)
                    reuniune.Add(i);
            return reuniune;
        }
        //
        //14
        //
        static void InsertionSort(int[] v)
        {
            for (int j = 1; j < v.Length; j++)
                for (int i = j; i > 0; i--)
                    if (v[i] < v[i - 1])
                    {
                        int aux = v[i];
                        v[i] = v[i - 1];
                        v[i - 1] = aux;
                    }
        }
        //
        //12
        //
        static void SelectionSort(int[] v) 
        {
            for (int j = 0; j < v.Length; j++)
            {
                int poz = j;
                for (int i = j + 1; i < v.Length; i++)
                    if (v[i] < v[poz])
                        poz = i;
                int aux = v[j];
                v[j] = v[poz];
                v[poz] = aux;
            }
        }
        //
        //11
        //
        static void BubbleSort(int[] v) 
        {
            int k = 0;
            bool ok;
            do
            {
                ok = false;
                for (int i = 0; i < v.Length - 1 - k; i++)
                    if (v[i] > v[i + 1])
                    {
                        int aux = v[i];
                        v[i] = v[i + 1];
                        v[i + 1] = aux;
                        ok = true;
                    }
                k++;
            } while (ok);
        }
        //
        //7
        //
        static int CMMMC(int a, int b) 
        {
            return a * b / CMMDC(a, b);
        }

        static int CMMDC(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }
            return a;
        }
        //
        //6
        //
        static int Oglindit(int n) 
        {
            int x = n, o = 0;
            while (x!=0)
            {
                o = o * 10 + x % 10;
                x /= 10;
            }
            return o;
        }
        //
        //3
        //
        static bool Prim(int n) 
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 3; i * i < n; i += 2)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
