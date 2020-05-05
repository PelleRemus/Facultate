using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LicentaDemo
{
    public static class Engine
    {
        public static Random rnd = new Random();
        public static List<Planet> planets = new List<Planet>();
        public static List<Player> players = new List<Player>();
        public static Player crtPlayer;
        public static int crtPlayerIDX = 0;

        public static List<HelpPage> helpPages = new List<HelpPage>();

        public static int[,] ma;
        public static int n;
        public static float zoomX = 1, zoomY = 1;

        public static Color backColor = Color.FromArgb(20, 20, 50);
        public static PictureBox display;
        public static Graphics grp;
        public static Bitmap bmp;

        public static void InitGraph(PictureBox p)
        {
            display = p;
            bmp = new Bitmap(p.Width, p.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(backColor);

            display.Image = bmp;
        }

        public static void InitDemo()
        {
            players.Add(new Player("player1", Color.Red));
            players.Add(new Player("player2", Color.Blue));
            players.Add(new Player("player3", Color.Green));
            players.Add(new Player("player4", Color.PeachPuff));
            crtPlayer = players[crtPlayerIDX];
        }

        public static void SelectNextPlayer()
        {
            crtPlayerIDX++;
            if (crtPlayerIDX == players.Count)
                crtPlayerIDX = 0;
            crtPlayer = players[crtPlayerIDX];
        }

        public static void Load(string fileName, string fileName2)
        {
            TextReader dataLoad = new StreamReader(fileName);
            string buffer;

            while ((buffer = dataLoad.ReadLine()) != "end_planets")
            {
                planets.Add(new Planet(buffer));
            }

            n = planets.Count;
            ma = new int[n, n];
            while ((buffer = dataLoad.ReadLine()) != null)
            {
                string[] local = buffer.Split(' ');
                int i = int.Parse(local[0]);
                int j = int.Parse(local[1]);
                int value = int.Parse(local[2]);
                ma[i, j] = value;
                ma[j, i] = value;
            }

            dataLoad = new StreamReader(fileName2);
            while((buffer = dataLoad.ReadLine()) != null)
            {
                Fleet temp = new Fleet(buffer);
                while ((buffer = dataLoad.ReadLine()) != "end_fleet")
                {
                    if (buffer == null)
                        break;
                    temp.ships.Add(new Ship(buffer));
                }
            }
        }

        public static void ReadXmlHelp()
        {
            XmlTextReader xmlReader = new XmlTextReader(@"..\..\Resources\XML\help.xml");
            Paragraph buffer = new Paragraph();
            HelpPage local = new HelpPage();
            bool isTitle = false;
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name == "page")
                            local = new HelpPage();
                        if (xmlReader.Name == "title")
                            isTitle = true;
                        if (xmlReader.Name == "paragraph")
                            buffer = new Paragraph();
                        break;

                    case XmlNodeType.Text:
                        if (isTitle)
                            local.title = xmlReader.Value;
                        else
                            buffer.Add(xmlReader.Value);
                        break;

                    case XmlNodeType.EndElement:
                        if (xmlReader.Name == "page")
                            helpPages.Add(local);
                        if (xmlReader.Name == "title")
                            isTitle = false;
                        if (xmlReader.Name == "paragraph")
                            local.AddParagraph(buffer);
                        break;
                }
            }
        }

        public static void DrawMap()
        {
            for(int i=0; i<n-1; i++)
                for(int j=i+1; j<n; j++)
                {
                    if (ma[i, j] != 0)
                        grp.DrawLine(new Pen(Color.White, 5), new Point((int)(planets[i].location.X * zoomX), (int)(planets[i].location.Y * zoomY)), 
                            new Point((int)(planets[j].location.X * zoomX), (int)(planets[j].location.Y * zoomY)));
                }

            foreach (Planet p in planets)
            {
                p.Draw();
            }
        }

        public static void RefreshMap()
        {
            display.Image = bmp;
        }

        public static void BattleWave(Fleet a, Fleet b)
        {
            foreach(Ship ship in a.ships)
            {
                int target = rnd.Next(b.ships.Count);
                float attack = ship.beam - b.ships[target].shield;
                if (attack < 0)
                    attack = 0;

                attack += ship.gun - b.ships[target].armor;
                if (attack < 0)
                    attack = 0;

                attack += ship.missile - b.ships[target].pointDef;
                if (attack < 0)
                    attack = 0;

                if (attack > 0)
                    b.ships[target].damage += attack;

                if (b.ships[target].damage >= b.ships[target].size)
                    b.ships[target].destroyed = true;
            }
        }

        public static void BattleCycle(Fleet a, Fleet b)
        {
            BattleWave(a, b);
            BattleWave(b, a);
        }

        public static void Battle(List<Fleet> A, List<Fleet> B)
        {
            foreach(Fleet fleet in A)
            {
                int target = rnd.Next(B.Count);
                BattleCycle(fleet, B[target]);
            }
            foreach (Fleet fleet in B)
            {
                int target = rnd.Next(A.Count);
                BattleCycle(fleet, A[target]);
            }

            foreach (Fleet fleet in A)
            {
                RemoveDestroyedShips(fleet);
            }
            foreach (Fleet fleet in B)
            {
                RemoveDestroyedShips(fleet);
            }

            RemoveDestroyedFleets(A);
            RemoveDestroyedFleets(B);
        }

        public static void RemoveDestroyedShips(Fleet A)
        {
            A.ships = A.ships.FindAll(delegate (Ship ship)
            {
                return !ship.destroyed;
            });
        }
        public static void RemoveDestroyedFleets(List<Fleet> A)
        {
            A = A.FindAll(delegate (Fleet fleet)
            {
                return fleet.ships.Count != 0;
            });
        }
    }
}
