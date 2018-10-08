using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stiva_genetica
{
    class Program
    {
        class Stiva<T>
        {
            int size;
            List<T> st;
            public Stiva(int x)
            {
                st = new List<T>();
                size = x;
            }
            public T this[int index]
            {
                get
                {
                    return st[index];
                }
                set
                {
                    st[index] = value;
                }
            }

            public void Push(T x)
            {
                if (st.Count < size)
                    st.Add(x);
                else
                    Console.WriteLine("Limita de spatiu a fost atinsa");
            }
            public void Pop(T x)
            {
                if (st.Count != 0)
                    st.Remove(x);
                else
                    Console.WriteLine("Nu exista elemente in stiva");
            }
        }

        static void Main(string[] args)
        {
            Stiva<int> st = new Stiva<int>(10);
            st.Push(5);
            st.Pop(3);
        }
    }
}
