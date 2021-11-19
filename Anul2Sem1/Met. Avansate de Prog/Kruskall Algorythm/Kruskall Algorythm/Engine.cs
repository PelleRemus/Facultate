using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Kruskall_Algorythm
{
    public static class Engine
    {
        public static int[,] matrix;
        public static int n;
        public static List<Edge> edges = new List<Edge>();
        public static bool[] vis;

        public static void Load()
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");
            n = int.Parse(dataLoad.ReadLine());
            matrix = new int[n, n];
            string buffer;
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                int i = int.Parse(buffer.Split(' ')[0]);
                int j = int.Parse(buffer.Split(' ')[1]);
                int t = int.Parse(buffer.Split(' ')[2]);
                matrix[i - 1, j - 1] = t;
                matrix[j - 1, i - 1] = t;

                edges.Add(new Edge(i, j, t));
            }
        }

        public static void View(ListBox list)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - i; j++)
                {
                    string s = (i + 1) + " " + (j + 1) + " " + matrix[i, j];
                    if (matrix[i, j] != 0)
                        list.Items.Add(s);
                }
        }

        public static void EdgeView(ListBox list)
        {
            foreach(Edge a in edges)
            {
                list.Items.Add(a.ToString());
            }
        }

        public static void EdgeSort()
        {
            edges.Sort(delegate (Edge a, Edge b)
            {
                return a.cost.CompareTo(b.cost);
            });
        }

        public static void ArborePartialCostMinim(ListBox list)
        {
            List<Edge> tempEdges = new List<Edge>();

            for (int i=0; i<n; i++)
            {
                tempEdges.Add(edges[i]);
                if (CycleDetection(tempEdges))
                    tempEdges.Remove(edges[i]);
            }

            foreach(Edge a in tempEdges)
            {
                list.Items.Add(a);
            }
        }

        public static bool CycleDetection(List<Edge> tempEdges)
        {
            for(int i=0; i<tempEdges.Count; i++)
            {
                vis = new bool[n];
                for (int j = 0; j < n; j++)
                    vis[i] = false;
                vis[i] = true;
                if (!BFS(tempEdges, i, vis, -1))
                    return false;
            }
            return true;
        }

        public static bool BFS(List<Edge> tempEdges, int ns, bool[] vis, int parent)
        {
            for (int i = 0; i < tempEdges.Count; i++)
                if (tempEdges[i].nodS == ns)
                {
                    if (!vis[tempEdges[i].nodS])
                    {
                        vis[tempEdges[i].nodS] = false;
                        BFS(tempEdges, tempEdges[i].nodE, vis, tempEdges[i].nodS);
                    }
                    else
                    {
                        if (tempEdges[i].nodE != parent)
                            return true;
                    }
                }
            return false;
        }
    }
}
