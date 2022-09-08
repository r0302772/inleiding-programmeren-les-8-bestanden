using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestanden
{
    class Oefening_1
    {
        static void Main(string[] args)
        {
            Methodes.PasSchermkleurenAan(1);

            Methodes.BehandelVriendenBestand("txt/vrienden0.txt");

            Methodes.DrukOpEnter();

            Methodes.BehandelVriendenBestand("txt/vrienden.txt");

            Methodes.DrukOpEnter();
        }
    }
}
