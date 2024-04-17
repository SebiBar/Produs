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
            string filePath = "C:\\Users\\Alex\\Desktop\\Produs\\App1\\Produse.xml";
            PachetMgr mgrPachete = new PachetMgr();

            mgrPachete.InitializareElementeXML(filePath);

            Console.Write("Nr pachete: ");
            uint nrPachete = uint.Parse(Console.ReadLine() ?? string.Empty);
            mgrPachete.ReadElemente(nrPachete);

            mgrPachete.SortByPrice();
            mgrPachete.Write2Console();

            //Afisam elementele cu categoria "Clienti"
            CriteriuCategorie criteriuCategorie = new CriteriuCategorie("Clienti");
            FiltrareCriteriu filtrare = new FiltrareCriteriu();

            Console.WriteLine("Filru:");
            IEnumerable<ProdusAbstract> li = filtrare.Filtrare(mgrPachete.GetElemente(), criteriuCategorie);
            foreach(ProdusAbstract c in li)
                Console.WriteLine(c.ToString());

        }
    }
}

