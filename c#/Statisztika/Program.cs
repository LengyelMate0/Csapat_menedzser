using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Focicsapat_menedzser;

namespace Statisztika
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Jatekos> keret = InicializalKeret();

            // statiztika
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("====================================================");
            Console.ResetColor();
            Console.WriteLine("MAGYAR VÁLOGATOTT KERET STATISZTIKÁK (2024)");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================================");
            Console.ResetColor();

            Console.WriteLine($"Keret létszáma: {keret.Count} fő");
            Console.WriteLine($"Összes válogatott gól: {keret.Sum(j => j.Golok)} db");
            Console.WriteLine($"Átlagos mérkőzésszám: {keret.Average(j => j.Meccsek):F1}");

            Console.WriteLine("====================================================");

            // legtöbb gól, legtöbb meccs
            var golkiraly = keret.OrderByDescending(j => j.Golok).First();
            var legtapasztaltabb = keret.OrderByDescending(j => j.Meccsek).First();

            Console.WriteLine($"Gólkirály: {golkiraly.Nev} ({golkiraly.Golok} gól)");
            Console.WriteLine($"Legtapasztaltabb: {legtapasztaltabb.Nev} ({legtapasztaltabb.Meccsek} meccs)");

            Console.WriteLine("====================================================");

            // posztok
            Console.WriteLine("Posztonkénti létszám:");
            var posztok = keret.GroupBy(j => j.Poszt);
            foreach (var csoport in posztok)
            {
                Console.WriteLine($"- {csoport.Key}: {csoport.Count()} fő");
            }

            // kereső
            Console.WriteLine("====================================================");
            Console.WriteLine("JÁTÉKOS KERESÉS");
            Console.WriteLine("====================================================");

            while (true)
            {
                Console.Write("\nKeresés: ");
                string keresett = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(keresett)) continue;

                var talalat = keret.FirstOrDefault(j => j.Nev.ToLower().Contains(keresett.ToLower()));

                if (talalat != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("====================================================");
                    Console.ResetColor();
                    Console.WriteLine($"Név: {talalat.Nev}");
                    Console.WriteLine($"Poszt: {talalat.Poszt}");
                    Console.WriteLine($"Mérkőzések: {talalat.Meccsek}");
                    Console.WriteLine($"Gólok: {talalat.Golok}");

                    double arany = talalat.Meccsek > 0 ? (double)talalat.Golok / talalat.Meccsek : 0;
                    Console.WriteLine($"Gólátlag: {arany:F2}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("====================================================");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"Nincs találat erre: '{keresett}'");
                }
            }
        }

        static List<Jatekos> InicializalKeret()
        {
            return new List<Jatekos>
            {
                new Jatekos("Dibusz Dénes", "Kapus", 0, 41),
                new Jatekos("Gulácsi Péter", "Kapus", 0, 57),
                new Jatekos("Szappanos Péter", "Kapus", 0, 1),
                new Jatekos("Willi Orbán", "Védő", 6, 54),
                new Jatekos("Dárdai Márton", "Védő", 0, 11),
                new Jatekos("Botka Endre", "Védő", 1, 31),
                new Jatekos("Fiola Attila", "Védő", 2, 63),
                new Jatekos("Balogh Botond", "Védő", 0, 7),
                new Jatekos("Szűcs Kornél", "Védő", 0, 3),
                new Jatekos("Szoboszlai Dominik", "Középpályás", 15, 51),
                new Jatekos("Nagy Ádám", "Középpályás", 2, 89),
                new Jatekos("Schäfer András", "Középpályás", 3, 34),
                new Jatekos("Bolla Bendegúz", "Középpályás", 0, 25),
                new Jatekos("Nagy Zsolt", "Középpályás", 3, 28),
                new Jatekos("Kata Mihály", "Középpályás", 0, 4),
                new Jatekos("Nikitscher Tamás", "Középpályás", 0, 6),
                new Jatekos("Gera Dániel", "Középpályás", 0, 4),
                new Jatekos("Sallai Roland", "Csatár", 13, 58),
                new Jatekos("Varga Barnabás", "Csatár", 7, 19),
                new Jatekos("Csoboth Kevin", "Csatár", 1, 15),
                new Jatekos("Gruber Zsombor", "Csatár", 0, 1),
                new Jatekos("Szabó Levente", "Csatár", 0, 2),
                new Jatekos("Dárdai Palkó", "Csatár", 0, 2),
                new Jatekos("Horváth Krisztofer", "Csatár", 0, 4)
            };
        }
    }
}