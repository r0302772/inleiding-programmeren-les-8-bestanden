using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestanden
{
    class Oefening_4
    {
        static void Main(string[] args)
        {
            Methodes.PasSchermkleurenAan(4);

            int aantal = 11;
            string menu = Methodes.StelMenuSamen(aantal);

            int keuze = Methodes.LeesKeuze(menu, aantal);

            while (keuze != 0)
            {
                string bestandsnaam = $"txt/Gedicht{keuze}.txt";

                if (!File.Exists(bestandsnaam))
                {
                    bestandsnaam = bestandsnaam.Replace("txt/", "");
                    Methodes.DrukDetail($"\n\tBestand \"{bestandsnaam}\" bestaat niet!", true);
                }
                else
                {
                    Methodes.BehandelGedichtenBestand(bestandsnaam);
                }
                Methodes.DrukOpEnter();
                keuze = Methodes.LeesKeuze(menu, aantal);
            }

            Methodes.DrukOpEnter();
        }
    }
}
