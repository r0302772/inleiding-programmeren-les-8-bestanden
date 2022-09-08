using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestanden
{
    public static class Methodes
    {
        public static void DrukOpEnter()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine();
            Console.Write("\tDruk op enter om verder te gaan!");
            Console.ReadLine();
        }
        public static void PasSchermkleurenAan(int oefening)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.Title = $"Oefening {oefening} - {DateTime.Now.ToLongDateString()} - {DateTime.Now.ToShortTimeString()}";
        }
        public static void DrukMelding(string boodschap)
        {
            Console.Clear();
            Console.WriteLine($"\t{boodschap}");
        }

        #region Oefening 1

        public static void LeesBestandOef1(string bestandsnaam, ref string overzicht)
        {
            using (StreamReader reader = new StreamReader(bestandsnaam))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    overzicht += Environment.NewLine + "\t" + record;
                }
            }
        }

        public static void BehandelVriendenBestand(string bestandsnaam)
        {
            string overzicht = "", boodschap;

            LeesBestandOef1(bestandsnaam, ref overzicht);

            Console.Clear();

            Console.ForegroundColor = overzicht == "" ? ConsoleColor.Red : ConsoleColor.Green;
            boodschap = overzicht == "" ? "\n\tSpijtig dat je geen vriendenkring hebt!" : $"\n\tMijn vriendekring:\n {overzicht}";

            Console.WriteLine(boodschap);

            /*if (overzicht == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tSpijtig dat je geen vriendenkring hebt!");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\tMijn vriendekring:\n {overzicht}");
            }*/
        }

        #endregion

        #region Oefening 2

        public static void DrukSupportersTitel(string ploeg)
        {
            Console.Clear();
            string titel = $"Supporterssjaal {ploeg}";
            Console.WriteLine($"\n\t{titel}");
            Console.WriteLine($"\t{new string('*', titel.Length)}");
        }

        public static void DrukSjaal(string streep1, string streep2, int lengte)
        {
            Console.WriteLine();

            for (int i = 1; i <= lengte; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"\t{streep1}");
                }
                else
                {
                    Console.Write($"\t{streep2}");
                }

                Console.WriteLine();
            }
        }
        public static void BehandelSupportersRecord(string record)
        {
            string ploegnaam, symbool1, symbool2;
            int lengte, breedte, positie;

            //record = City Pirates;b;g;6;3
            positie = record.IndexOf(';');
            ploegnaam = record.Substring(0, positie);
            record = record.Substring(positie + 1);

            //record = b;g;6;3
            positie = record.IndexOf(';');
            symbool1 = record.Substring(0, positie);
            record = record.Substring(positie + 1);

            //record = g;6;3
            positie = record.IndexOf(';');
            symbool2 = record.Substring(0, positie);
            record = record.Substring(positie + 1);

            //record = 6;3
            positie = record.IndexOf(';');
            lengte = int.Parse(record.Substring(0, positie));
            record = record.Substring(positie + 1);

            //record = 3
            breedte = int.Parse(record);

            DrukSupportersTitel(ploegnaam);
            DrukSjaal(new string(char.Parse(symbool1), breedte), new string(char.Parse(symbool2), breedte), lengte);
        }
        public static void BehandelSupportersBestand(string bestandsnaam)
        {
            if (File.Exists(bestandsnaam))
            {
                bool leeg = true;
                using (StreamReader reader = new StreamReader(bestandsnaam))
                {
                    while (!reader.EndOfStream)
                    {
                        leeg = false;
                        string record = reader.ReadLine();
                        BehandelSupportersRecord(record);
                        DrukOpEnter();
                    }
                }

                if (leeg)
                {
                    DrukMelding($"{bestandsnaam} bevat geen gegevens.");
                    DrukOpEnter();
                }
            }
            else
            {
                DrukMelding($"{bestandsnaam} bestaat niet!");
                DrukOpEnter();
            }
        }

        #endregion

        #region Oefening 3

        public static void DrukStudentenTitel()
        {
            Console.Clear();
            string titel = $"\tStudentenlijst van {DateTime.Now.ToShortDateString()}";
            Console.WriteLine(titel);
            Console.WriteLine($"\t{new string('=', titel.Length)}\n");
        }
        public static void ZetBepaaldeLettersInHoofdletters(ref string naam, string symbool)
        {
            naam = naam.Substring(0, 1).ToUpper() + naam.Substring(1);

            int positie = naam.IndexOf(symbool);
            int startpositie;

            while (positie != -1)
            {
                naam = naam.Substring(0, positie) + symbool + naam.Substring(positie + 1, 1).ToUpper() + naam.Substring(positie + 2);

                startpositie = positie + 1;

                positie = naam.IndexOf(symbool, startpositie);
            }
        }
        public static void DrukStudentenInfo(string nummer, string naam, string voornaam)
        {
            Console.WriteLine($"\t{nummer.PadRight(10)}{voornaam.PadRight(40)}{naam}");
        }
        public static void BehandelStudentenRecord(string record, ref bool isTitelGedrukt)
        {
            string studentennummer, familienaam, voornaam, symboolfamilienaam, symboolvoornaam;
            int positie = 8;

            //record = r0487012de meulemeester*yannick
            studentennummer = record.Substring(0, positie);
            record = record.Substring(positie);

            //record = de meulemeester*yannick
            positie = record.IndexOf('*');
            familienaam = record.Substring(0, positie).Trim();
            voornaam = record.Substring(positie + 1).Trim();

            symboolfamilienaam = familienaam.IndexOf('-') != -1 ? "-" : " ";
            symboolvoornaam = voornaam.IndexOf('-') != -1 ? "-" : " ";

            ZetBepaaldeLettersInHoofdletters(ref familienaam, symboolfamilienaam);
            ZetBepaaldeLettersInHoofdletters(ref voornaam, symboolvoornaam);

            if (!isTitelGedrukt)
            {
                DrukStudentenTitel();
                isTitelGedrukt = true;
            }

            DrukStudentenInfo(studentennummer, familienaam, voornaam);
        }
        public static void LeesBestandOef3(string bestandsnaam)
        {
            bool titelGedrukt = false;

            using (StreamReader reader = new StreamReader(bestandsnaam))
            {
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    BehandelStudentenRecord(record, ref titelGedrukt);
                }
            }
        }
        public static void BehandelStudenten(string bestandsnaam)
        {
            if (File.Exists(bestandsnaam))
            {
                LeesBestandOef3(bestandsnaam);
            }
            else
            {
                DrukMelding($"{bestandsnaam} bestaat niet!");
            }
        }

        #endregion

        #region Oefening 4

        public static string StelMenuSamen(int aantalItems)
        {
            string menu = "0. Stoppen";

            for (int i = 1; i <= aantalItems; i++)
            {
                menu += $"\n\t{i}. Gedicht {i}";
            }

            return menu;
        }
        public static void DrukGedichtenTitel(string titel)
        {
            Console.Clear();
            Console.WriteLine($"\n\t{titel}");
            Console.WriteLine($"\t{new string('=', titel.Length)}");
        }
        public static void DrukDetail(string informatie, bool nieuweLijn)
        {
            if (nieuweLijn)
            {
                Console.WriteLine($"\t{informatie}");
            }
            else
            {
                Console.Write($"\t{informatie}");
            }
        }
        public static int LeesKeuze(string menu, int aantalKeuzes)
        {
            string invoer;
            int keuze;

            do
            {
                do
                {
                    Console.Clear();
                    DrukGedichtenTitel("Gedichten een wereld van ...");
                    DrukDetail(menu, true);
                    Console.WriteLine();
                    DrukDetail("Maak je keuze: ", false);
                    invoer = Console.ReadLine();

                } while (!int.TryParse(invoer, out keuze));

            } while ((keuze >= 0 && keuze <= aantalKeuzes) == false);

            return keuze;
        }
        public static void BehandelGedichtenBestand(string bestand)
        {
            using (StreamReader reader = new StreamReader(bestand))
            {
                //Gedicht1.txt wordt Gedicht1
                string titel = bestand.Replace(".txt", "");
                titel = titel.Replace("txt/", "");
                //Gedicht1 wordt Gedicht 1
                titel = titel.Insert(7, " ");
                DrukGedichtenTitel(titel);
                while (!reader.EndOfStream)
                {
                    string record = reader.ReadLine();
                    DrukDetail(record, true);
                }
            }
        }

        #endregion
    }
}
