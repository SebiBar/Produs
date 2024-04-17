using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;

namespace App1
{
    internal class Program
    {
        //main
        static void Main(string[] args)
        {
            PachetMgr mgrPachete = new PachetMgr();

            CriteriuCategorie criteriuCategorie = new CriteriuCategorie("Clienti");
            FiltrareCriteriu filtrare = new FiltrareCriteriu();

            mgrPachete.InitializareElementeXML();

            Console.Write("Nr pachete: ");
            uint nrPachete = uint.Parse(Console.ReadLine() ?? string.Empty);
            mgrPachete.ReadElemente(nrPachete);

            mgrPachete.SortByPrice();
            mgrPachete.Write2Console();

            IEnumerable<ProdusAbstract> li = filtrare.Filtrare(mgrPachete.GetElemente(), criteriuCategorie);
            foreach(ProdusAbstract c in li)
                Console.WriteLine(c.ToString());

        }
    }
}

