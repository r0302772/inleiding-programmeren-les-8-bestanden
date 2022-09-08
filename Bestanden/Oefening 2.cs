using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestanden
{
    class Oefening_2
    {
        static void Main(string[] args)
        {
            Methodes.PasSchermkleurenAan(2);

            Methodes.BehandelSupportersBestand("txt/supporters0.txt");
            Methodes.BehandelSupportersBestand("txt/supportersGeen.txt");
            Methodes.BehandelSupportersBestand("txt/supporters.txt");
        }
    }
}
