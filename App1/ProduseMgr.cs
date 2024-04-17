using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using entitati;

namespace App1
{
    internal class ProduseMgr : ProduseAbstractMgr
    {
        public override void InitializareElementeXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            try {doc.Load(filePath);}
            catch { Console.WriteLine("Nu s-a gasit fisierul");}

            XmlNodeList? lista_noduri = doc.SelectNodes("Produse/Produs");

            if (lista_noduri != null)
                foreach (XmlNode nod in lista_noduri)
                {
                    string nume = nod["Nume"]!.InnerText;
                    string codIntern = nod["CodIntern"]!.InnerText;
                    int pret = int.Parse(nod["Pret"]!.InnerText);
                    string categorie = nod["Categorie"]!.InnerText;
                    string producator = nod["Producator"]!.InnerText;

                    Produs prod = new Produs(elemente.Count, nume, codIntern, pret, categorie, producator);

                    if (!(elemente.Contains(prod)))
                        elemente.Add(prod);
                }
        }

        public override void ReadElement()
        {
            string? numeTmp, codInternTmp, producatorTmp, categorieTmp;
            int? pretTmp;

            Console.WriteLine();
            Console.WriteLine("Introdu produsul: ");

            Console.Write("Numele:");
            numeTmp = Console.ReadLine();

            Console.Write("Codul intern:");
            codInternTmp = Console.ReadLine();

            Console.Write("Pretul (RON):");
            try { pretTmp = Convert.ToInt32(Console.ReadLine()); }
            catch { pretTmp = 0; }


            Console.Write("Categoria:");
            categorieTmp = Console.ReadLine();

            Console.Write("Producatorul:");
            producatorTmp = Console.ReadLine();

            Produs prod = new Produs(elemente.Count, numeTmp, codInternTmp, pretTmp, categorieTmp, producatorTmp);

            if (!(elemente.Contains(prod)))
                elemente.Add(prod);

        }

        public override void Write2Console()
        {
            Console.WriteLine();
            Console.WriteLine("Lista produse: ");
            base.Write2Console();
        }
    }
}
