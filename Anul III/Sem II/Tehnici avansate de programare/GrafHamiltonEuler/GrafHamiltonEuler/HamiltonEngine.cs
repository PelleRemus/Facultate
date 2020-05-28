using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafHamiltonEuler
{
    class HamiltonEngine
    {
        public static int[,] matrix;
        public static int n;

        public static void InitMatrix()
        {
            StreamReader s = new StreamReader(@"..\..\graph_hamil.txt");

            string buffer;
            int i = 0;
            n = Int32.Parse(s.ReadLine());
            matrix = new int[n, n];
            while ((buffer = s.ReadLine()) != null)
            {
                string[] strArray = buffer.Split();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = Int32.Parse(strArray[j]);
                i++;
            }
        }

        public static void ShowMatrix()
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static bool IsConex()
        {
            Queue<int> q = new Queue<int>();
            int[] visited = new int[5];
            int startNode = 1;
            q.Enqueue(startNode);
            while (q.Count != 0)
            {
                int currentNode = q.Dequeue();
                for (int i = 0; i < n; i++)
                    if (matrix[currentNode, i] == 1 && visited[i] == 0) //if they are connected
                    {
                        visited[i] = 1;
                        q.Enqueue(i);
                    }
            }

            for (int i = 0; i < n; i++)
                if (visited[i] == 0)
                    return false; //the graph isn't conex
            return true;
        }

        static bool IsSafe(int v, int[] path, int pos)
        {
            if (matrix[path[pos - 1], v] == 0) //if there is an edge from the last vertice added to the one we want to add now
                return false;

            for (int i = 0; i < pos; i++) //you cannot add a duplicate vertice
                if (path[i] == v)
                    return false;

            return true;
        }

        static int HamiltonianUtil(int[] path, int pos)
        {
            if (pos == n) //if the backtracking solution is complete
            {
                if (matrix[path[n - 1], path[0]] == 1) //and there is a path from last vertice to first
                    return 1; //cycle
                else
                    return 2; //path
            }

            for (int v = 1; v < n; v++)
            {
                if (IsSafe(v, path, pos)) //if the next vertice to add in the path is a suitable one
                {
                    path[pos] = v; //we add it

                    int result;
                    if ((result = HamiltonianUtil(path, pos + 1)) != 0)
                        return result;

                    path[pos] = -1; // and if not we remove it
                }
            }
            return 0;
        }

        public static void FindH()
        {
            int[] path = new int[n];
            for (int i = 0; i < n; i++)
                path[i] = -1;  // -1 means that slot is free to try another vertex

            path[0] = 0; // we begin from vertice 0, because if we have a cycle, it doesn't matter from where we start
            if (HamiltonianUtil(path, 1) == 0) //if backtracking didn't find any solution
                Console.WriteLine("Solution does not exist");
            else
            {
                for (int i = 0; i < n; i++)
                    Console.Write($"{path[i]} ");
                Console.WriteLine();
            }
        }

        public static void FindHamiltonian()
        {
            if (IsConex())
            {
                int[] path = new int[n];
                for (int i = 0; i < n; i++)
                    path[i] = -1;  // -1 means that slot is free to try another vertex

                int start = 0;
                path[0] = start; // we begin from vertice 0, because if we have a cycle, it doesn't matter from where we start
                int result = HamiltonianUtil(path, 1);
                switch (result)
                {
                    case 0:
                        Console.WriteLine("Not Eulerian");
                        break;
                    case 1:
                        Console.Write("Cycle: ");
                        for (int i = 0; i < n; i++)
                            Console.Write($"{path[i]} ");
                        Console.Write(start);
                        break;
                    case 2:
                        Console.Write("Path: ");
                        for (int i = 0; i < n; i++)
                            Console.Write($"{path[i]} ");
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
            }
            else
                Console.WriteLine("The graph is not conex, nor hamltonian.");
        }
    }
}
