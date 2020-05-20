using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/*
 *  Collide
 *  Eine Simulation im 2-dimensionalen Raum
 *  Aufgabenverteilung
 *  a) Ausserer Alex
 *  b) Ritsch Julian
 *  c) Verdorfer Martin
 *  d) Pircher Marjan
 * / Teil C Martin Verdorfer
 * 2020 TFO-Meran
 */

namespace ConsoleApplication1
{
    class Program
    {
        const int seite = 50;
        static int[,] feld = new int[seite, seite];

        class einer
        {
            // Private Eigenschaften

            // Öffentliche Eigenschaften
            Random random = new Random();
            public int posx, posy;
            public ConsoleColor farbe;
            // Konstruktor
            public einer()
            {
                farbe = (ConsoleColor)(random.Next(Enum.GetNames(typeof(ConsoleColor)).Length));
                System.Threading.Thread.Sleep(20);
                do
                {
                    posy = random.Next(0, seite);
                    posx = random.Next(0, seite);
                } while (feld[posx, posy] == 1);
                feld[posx, posy] = 1;
            }

            //Private Methoden
            void show()
            {
                Console.SetCursorPosition(posx, posy); //Hier wird der Cursor auf die Position X,Y gesetzt
                Console.ForegroundColor = farbe;       // Textfarbe wird gewählt
                Console.Write("■");                     //das Objekt wird gezeichnet

            }
            void hide()
            {
                Console.SetCursorPosition(posx, posy); //Hier wird der Cursor auf die Position X,Y gesetzt
                Console.Write(" ");                    //Es wird gelöscht

            }

            /// <summary>
            /// i glab des isch folsch //by Ritsch
            /// </summary>
            void collide()
            {
                Console.SetCursorPosition(posx, posy);  //Hier wird der Cursor auf die Position X,Y gesetzt
                Console.ForegroundColor = farbe;         // Textfarbe wird gewählt
                Console.Write("x");                     //Es wird markiert
                Move();                                 //Die Move Methode wird aufgerufen
            }
            //Öffentliche Methoden
            public void Move()
            {
                Random rndDirection = new Random();
                hide();
                switch (rndDirection.Next(4))
                {
                    ///Up
                    case 0:
                        posy = (posy != seite) ? posy++ : posy--;
                        break;

                    ///Down
                    case 1:
                        posy = (posy != 0) ? posy-- : posy++;
                        break;

                    ///Right
                    case 2:
                        posx = (posx != seite) ? posx++ : posx--;
                        break;

                    ///Left
                    case 3:
                        posx = (posx != 0) ? posx-- : posx++;
                        break;
                }

                ///Kontroliert ob eine Kollision besteht
                Console.SetCursorPosition(posx, posy);
                if (Console.Read() == ' ')
                {
                    show();
                }
                else
                {
                    collide();
                }

            }

        }

        static void Main(string[] args)
        {
            Console.WindowWidth = seite * 2;
            Console.WindowHeight = seite;
            Console.Clear();
            Random ZG = new Random();
            int Anzahl = ZG.Next(1, 6);
            einer[] meineEiner = new einer[Anzahl];
            for (int i = 0; i < Anzahl; i++)
            {
                meineEiner[i] = new einer();
            }
            Console.CursorVisible = false;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < Anzahl; j++)
                {
                    meineEiner[j].Move();
                }
                System.Threading.Thread.Sleep(10);

            }
        }
    }
}
