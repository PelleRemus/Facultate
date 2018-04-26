using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatori
{ 
    class Date
    {
        public int an, luna, zi;
        public Date(int z, int l, int a)
        {
            zi = z; luna = l; an = a;
        }
        public Date(string date)
        {
            zi = int.Parse(date.Split('.')[0]);
            luna = int.Parse(date.Split('.')[1]);
            an = int.Parse(date.Split('.')[2]);
        }

        public static bool operator ==(Date d1, Date d2)
        {
            if (d1.an == d2.an && d1.luna == d2.luna && d1.zi == d2.zi) return true;
            return false;
        }
        public static bool operator !=(Date d1, Date d2)
        {
            if (d1 == d2) return false;
            return true;
        }

        public static bool operator <(Date d1, Date d2)
        {
            if (d1.an < d2.an) return true;
            if (d1.an == d2.an && d1.luna < d2.luna) return true;
            if (d1.an == d2.an && d1.luna == d2.luna && d1.zi < d2.zi) return true;
            return false;
        }

        public static bool operator >(Date d1, Date d2)
        {
            if (d1 < d2 || d1 == d2) return false;
            return true;
        }

        public static bool operator <=(Date d1, Date d2)
        {
            if (d1 < d2 || d1 == d2) return true;
            return false;
        }

        public static bool operator >=(Date d1, Date d2)
        {
            if (d1 < d2) return false;
            return true;
        }
        public static int operator -(Date d1, Date d2)
        {
            int nrZile1 = NrZile(d1);
            int nrZile2 = NrZile(d2);
            return (int)Math.Abs(nrZile1 - nrZile2);
        }

        public static int NrZile(Date d)
        {
            int nrZile = 0;
            for (int i = 0; i < d.an; i++)
            {
                if ((i % 4 == 0 && i % 100 != 0) || i % 400 == 0)
                    nrZile += 366;
                else nrZile += 365;
            }
            for (int i = 1; i < d.luna; i++)
                switch (i)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                        {
                            nrZile += 31;
                            break;
                        }
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        {
                            nrZile += 30;
                            break;
                        }
                    case 2:
                        {
                            if ((d.an % 4 == 0 && d.an % 100 != 0) || d.an % 400 == 0)
                                nrZile += 29;
                            else nrZile += 28;
                            break;
                        }
                }
            nrZile += d.zi;
            return nrZile;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}.{1}.{2}", zi, luna, an);
            return s.ToString();
        }
    }

    class Time
    {
        public int h, m, s, miliS;
        public Time(int ora, int min)
        {
            h = ora;
            m = min;
            s = 0;
            miliS = 0;
        }
        public Time(int ora, int min, int sec)
        {
            h = ora;
            m = min;
            s = sec;
            miliS = 0;
        }
        public Time(int ora, int min, int sec, int sutimi)
        {
            h = ora;
            m = min;
            s = sec;
            miliS = sutimi;
        }
        public static Time operator +(Time time1, Time time2)
        {
            Time time = new Time(0, 0);
            time.miliS = time1.miliS + time2.miliS;
            time.s = time1.s + time2.s;
            time.m = time1.s + time2.s;
            time.h = time1.h + time2.h;
            if (time.miliS>60)
            {
                time.miliS %= 60;
                time.s += 1;
            }
            if (time.s > 60)
            {
                time.s %= 60;
                time.m += 1;
            }
            if (time.m > 60)
            {
                time.m %= 60;
                time.h += 1;
            }
            return time;
        }
        public static Time operator -(Time t1, Time t2)
        {
            Time time = new Time(0, 0);
            time.miliS = t1.miliS - t2.miliS;
            time.s = t1.s - t2.s;
            time.m = t1.s - t2.s;
            time.h = t1.h - t2.h;
            if (time.miliS > 60)
            {
                time.miliS += 60;
                time.s -= 1;
            }
            if (time.s < 0)
            {
                time.s += 60;
                time.m -= 1;
            }
            if (time.m < 0)
            {
                time.m += 60;
                time.h -= 1;
            }
            return time;
        }

        public static bool operator ==(Time t1, Time t2)
        {
            if (t1.h == t2.h && t1.m == t2.m && t1.s == t2.s && t1.miliS == t2.miliS) return true;
            return false;
        }
        public static bool operator !=(Time t1, Time t2)
        {
            if (t1 == t2) return false;
            return true;
        }

        public static bool operator <(Time t1, Time t2)
        {
            if (t1.h < t2.h) return true;
            if (t1.h == t2.h && t1.m < t2.m) return true;
            if (t1.h == t2.h && t1.m == t2.m && t1.s < t2.s) return true;
            if (t1.h == t2.h && t1.m == t2.m && t1.s == t2.s && t1.miliS < t2.miliS) return true;
            return false;
        }
        public static bool operator >(Time t1, Time t2)
        {
            if (t1 < t2 || t1 == t2) return false;
            return true;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            if (t1 < t2 || t1 == t2) return true;
            return false;
        }
        public static bool operator >=(Time t1, Time t2)
        {
            if (t1 > t2 || t1 == t2) return true;
            return false;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}:{1}:{2}:{3}", h, m, s, miliS);
            return s.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Date d1 = new Date(10, 10, 1999);
            Date d2 = new Date("23.04.2003");
            Console.WriteLine("d1: {0}; d2: {1}", d1, d2);
            Console.WriteLine("{0} < {1}: {2}", d1, d2, d1 < d2);
            Console.WriteLine("{0} > {1}: {2}", d1, d2, d1 > d2);
            Console.WriteLine("{0} <= {1}: {2}", d1, d2, d1 <= d2);
            Console.WriteLine("{0} >= {1}: {2}", d1, d2, d1 >= d2);
            Console.WriteLine("{0} == {1}: {2}", d1, d2, d1 == d2);
            Console.WriteLine("{0} != {1}: {2}", d1, d2, d1 != d2);
            Console.WriteLine("{0} - {1} = {2}", d1, d2, d1 - d2);
            Console.WriteLine();

            Time t1 = new Time(13, 2, 3, 5);
            Time t2 = new Time(12, 15, 16, 7);
            Console.WriteLine("t1: {0}; t2: {1}", t1, t2);
            Console.WriteLine("{0} < {1}: {2}", t1, t2, t1 < t2);
            Console.WriteLine("{0} > {1}: {2}", t1, t2, t1 > t2);
            Console.WriteLine("{0} <= {1}: {2}", t1, t2, t1 <= t2);
            Console.WriteLine("{0} >= {1}: {2}", t1, t2, t1 >= t2);
            Console.WriteLine("{0} == {1}: {2}", t1, t2, t1 == t2);
            Console.WriteLine("{0} != {1}: {2}", t1, t2, t1 != t2);
            Console.WriteLine("{0} - {1} = {2}", t1, t2, t1 - t2);
            Console.WriteLine("{0} + {1} = {2}", t1, t2, t1 + t2);
            Console.ReadKey();
        }
    }
}
