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

            //Afisam elementele cu categoria "Clienti" si pret peste 1000
            CriteriuCategorie criteriuCategorie = new CriteriuCategorie("Clienti");
            CriteriuPret criteriuPret = new CriteriuPret(1000);
            FiltrareCriteriu filtrare = new FiltrareCriteriu();

            Console.WriteLine("Filru:");
            IEnumerable<ProdusAbstract> li = filtrare.Filtrare(mgrPachete.GetElemente(),
                criteriuCategorie, criteriuPret);
            foreach(ProdusAbstract c in li)
                Console.WriteLine(c.ToString());

        }
    }
}

