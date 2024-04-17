using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using entitati;

namespace App1
{
    internal class ServiciiMgr : ProduseAbstractMgr
    {
        public override void InitializareElementeXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            try { doc.Load(filePath); }
            catch { Console.WriteLine("Nu s-a gasit fisierul");}

            XmlNodeList? lista_noduri = doc.SelectNodes("Produse/Serviciu");

            if (lista_noduri != null) 
                foreach (XmlNode nod in lista_noduri)
                {
                    string nume = nod["Nume"]!.InnerText;
                    string codIntern = nod["CodIntern"]!.InnerText;
                    int pret = int.Parse(nod["Pret"]!.InnerText);
                    string categorie = nod["Categorie"]!.InnerText;

                    Serviciu serv = new Serviciu(elemente.Count, nume, codIntern, pret, categorie);

                    if (!(elemente.Contains(serv)))
                        elemente.Add(serv);
                }
        }
        public override void ReadElement()
        {
            string? numeTmp, codInternTmp, categorieTmp;
            int? pretTmp;

            Console.WriteLine();
            Console.WriteLine("Introdu serviciul:");

            Console.Write("Numele: ");
            numeTmp = Console.ReadLine();

            Console.Write("Codul intern: ");
            codInternTmp = Console.ReadLine();

            Console.Write("Pretul (RON):");
            pretTmp = Convert.ToInt32(Console.ReadLine());

            Console.Write("Categoria:");
            categorieTmp = Console.ReadLine();

            Serviciu serv = new Serviciu(elemente.Count, numeTmp, codInternTmp, pretTmp, categorieTmp);

            if (!(elemente.Contains(serv)))
                elemente.Add(serv);
        }

        public override void Write2Console()
        {
            Console.WriteLine();
            Console.WriteLine("Lista servicii: ");
            base.Write2Console();
        }
    }
}
