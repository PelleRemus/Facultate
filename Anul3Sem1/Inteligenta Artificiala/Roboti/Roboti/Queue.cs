using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboti
{
    public class Node
    {
        public int i, j, value;

        public Node() { }
        public Node(int i, int j, int value)
        {
            this.i = i;
            this.j = j;
            this.value = value;
        }

        public override string ToString()
        {
            return "(" + i + ", " + j + ", " + value + ")";
        }
    }

    public class Queue
    {
        public Node[] values;
        public int n;

        public Queue()
        {
            n = 0;
            values = new Node[n];
        }

        public void Push(Node node)
        {
            n++;
            Node[] temp = new Node[n];
            for (int i = 0; i < n - 1; i++)
                temp[i + 1] = values[i];
            temp[0] = node;
            values = temp;
        }

        public Node Pop()
        {
            n--;
            Node[] temp = new Node[n];
            for (int i = 0; i < n; i++)
                temp[i] = values[i];
            Node toReturn = values[n];
            values = temp;
            return toReturn;
        }

        public override string ToString()
        {
            string toReturn = "";
            for(int i=0; i<n; i++)
                toReturn += values[i].ToString() + " \n";
            return toReturn;
        }
    }
}
