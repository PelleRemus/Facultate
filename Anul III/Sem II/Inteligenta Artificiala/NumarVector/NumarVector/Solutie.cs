﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumarVector
{
    public class Solutie
    {
        public Gene[] genes = new Gene[Engine.n];

        public int[] getValues()
        {
            int[] r = new int[Gene.n * Engine.n];
            int k = 0;
            for(int i = 0; i<Engine.n; i++)
            {
                for(int j=0; j<Gene.n; j++)
                {
                    r[k] = genes[i].cifre[j];
                    k++;
                }
            }
            return r;
        }

        public Solutie()
        {
            initRandom();
        }

        public Solutie(int[] cifre)
        {
            initRandom();
            int k = 0;
            for (int i = 0; i < Engine.n; i++)
            {
                for (int j = 0; j < Gene.n; j++)
                {
                    genes[i].cifre[j] = cifre[k];
                    k++;
                }
            }
        }

        public void initRandom()
        {
            for (int i = 0; i < Engine.n; i++)
                genes[i] = new Gene();
        }

        public void View()
        {
            for(int i=0; i<Engine.n; i++)
            {
                genes[i].View();
            }
            Console.WriteLine();
        }

        public void ViewValue()
        {
            for (int i = 0; i < Engine.n; i++)
            {
                Console.Write(genes[i].ConvertToDouble() + ", ");
            }
            Console.WriteLine();
        }
    }
}