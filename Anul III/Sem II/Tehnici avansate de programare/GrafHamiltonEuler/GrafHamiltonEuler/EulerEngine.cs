using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafHamiltonEuler
{
    class EulerEngine
    {
        public static int[,] matrix;
        public static int n;
        public static List<int> path = new List<int>();
        public static int oddDegreeVertex = -1;

        public static void InitMatrix()
        {
            StreamReader s = new StreamReader(@"..\..\graph_euler.txt");

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

        public static int VerticesHaveEvenDegree()
        {
            int nrOfOddDegrees = 0;
            for (int i = 0; i < n; i++)
            {
                int degree = 0;
                for (int j = 0; j < n; j++)
                    degree = degree + matrix[i, j];
                if (degree % 2 == 1)
                {
                    nrOfOddDegrees++;
                    oddDegreeVertex = i;
                }
            }
            if (nrOfOddDegrees == 0) //eulerian
                return 1;
            if (nrOfOddDegrees == 2)  //semi-eulerian
                return 2;
            return 0; //not eulerian at all

        }

        public static int GetUnvisitedEdge(int vertex)
        {
            for (int i = 0; i < n; i++)
                if (matrix[vertex, i] == 1)
                    return i;
            return -1;
        }
        public static void DFS(int vertex)
        {
            int nextVertex;
            while ((nextVertex = GetUnvisitedEdge(vertex)) != -1) //until we have unvisited edges for that vertex
            {
                matrix[vertex, nextVertex] = matrix[nextVertex, vertex] = 2; //we mark edge as visited(=2)
                DFS(nextVertex);
                path.Insert(0, nextVertex);
            }
        }

        public static void FindEulerian()
        {
            if (IsConex())
            {
                int result = VerticesHaveEvenDegree();
                int start;
                switch (result)
                {
                    case 0:
                        Console.WriteLine("Not Eulerian");
                        break;
                    case 1:
                        start = 0; //it doesn't matter where you start because it's a circuit
                        DFS(start);
                        path.Insert(0, start);
                        Console.Write("Cycle: ");
                        for (int i = 0; i < path.Count; i++)
                            Console.Write($"{path[i]} ");

                        Console.WriteLine();
                        break;
                    case 2:
                        start = oddDegreeVertex; //you have to start with one odd degree vertex because it'a a path
                        DFS(start);
                        path.Insert(0, start);
                        Console.Write("Path: ");
                        for (int i = 0; i < path.Count; i++)
                            Console.Write($"{path[i]} ");

                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Something went wrong");
                        break;
                }
            }
            else
                Console.WriteLine("The graph is not conex, nor eulerian.");
        }
    }
}
