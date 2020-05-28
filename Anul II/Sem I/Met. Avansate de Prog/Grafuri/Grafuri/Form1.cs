using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Grafuri
{
    public partial class Form1 : Form
    {
        int[,] ma;
        bool[] b;
        int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextReader dataLoad = new StreamReader(@"../../TextFile1.txt");
            string buffer = dataLoad.ReadLine();
            n = int.Parse(buffer);
            ma = new int[n, n];
            b = new bool[n];

            for (int i = 0; i < n; i++)
                b[i] = false;

            while ((buffer = dataLoad.ReadLine()) != null)
            {
                int nStart = int.Parse(buffer.Split(' ')[0]);
                int nEnd = int.Parse(buffer.Split(' ')[1]);
                ma[nStart - 1, nEnd - 1] = 1;
                ma[nEnd - 1, nStart - 1] = 1;
            }

            string t = "";
            for(int i=0; i<n; i++)
            {
                t = "";
                for (int j = 0; j < n; j++)
                    t += ma[i, j] + " ";
                listBox1.Items.Add(t);
            }
            listBox1.Items.Add("");

            PA(0);
            listBox1.Items.Add("");

            PL(0);
            listBox1.Items.Add("");
            listBox1.Items.Add(Bipartit());
        }

        //Parcurgere in adancime
        public void PA(int nStart)
        {
            b[nStart] = true;
            listBox1.Items.Add((nStart + 1) + " ");
            for (int i = 0; i < n; i++)
                if (ma[nStart, i] == 1 && !b[i])
                    PA(i);
        }

        //Parcurgerea in latime
        public void PL(int nStart)
        {
            for (int i = 0; i < n; i++)
                b[i] = false;
            b[nStart] = true;

            Coada c = new Coada();
            c.Add(nStart);
            listBox1.Items.Add((nStart + 1) + " ");

            while (c.n != 0)
            {
                int v = c.Delete();
                for (int i = 0; i < n; i++)
                    if (ma[v, i] == 1 && !b[i])
                    {
                        c.Add(i);
                        b[i] = true;
                        listBox1.Items.Add((i + 1) + " ");
                    }
            }
        }

        public bool Bipartit()
        {
            int[] colors = new int[n];
            for (int i = 0; i < n; i++)
                b[i] = false;

            Coada c = new Coada();
            c.Add(0);
            b[0] = true;
            colors[0] = 1;

            while (c.n != 0)
            {
                int value = c.Delete();
                for(int i=0; i<n; i++)
                {
                    if(ma[value, i]==1)
                    {
                        if(!b[i])
                        {
                            colors[i] = colors[value] % 2 + 1; // 1 sau 2
                            b[i] = true;
                            c.Add(i);
                        }
                        else
                        {
                            if (colors[i] != colors[value] % 2 + 1)
                                return false;
                        }
                    }

                }
            }

            return true;
        }
    }
}
