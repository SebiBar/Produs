using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace App1
{
    internal class PachetMgr : ProduseAbstractMgr
    {
        private ServiciiMgr? mgrServicii;
        private ProduseMgr? mgrProduse;

        public PachetMgr()
        {
            mgrServicii = new ServiciiMgr();
            mgrProduse = new ProduseMgr();
        }

        public override void InitializareElementeXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            try { doc.Load(filePath); }
            catch { Console.WriteLine("Nu s-a gasit fisierul"); }

            XmlNodeList? lista_noduri = doc.SelectNodes("Produse/Pachet");

            if (lista_noduri != null)
                foreach (XmlNode nod in lista_noduri) // Fiecare <Pachet>
                {
                    Pachet pac = new Pachet(
                        elemente.Count,
                        nod["Nume"]!.InnerText,
                        nod["CodIntern"]!.InnerText,
                        nod["Categorie"]!.InnerText);

                    foreach (XmlNode elem in nod["Elemente"]!.ChildNodes) // Fiecare copil al nodului <Elemente>
                    {                                                     // al parintelui <Pachet>
                        if (elem.Name == "Produs")
                        {
                            Produs prod = new Produs(
                                elemente.Count,
                                elem["Nume"]!.InnerText,
                                elem["CodIntern"]!.InnerText,
                                int.Parse(elem["Pret"]!.InnerText),
                                elem["Categorie"]!.InnerText,
                                elem["Producator"]!.InnerText);

                            pac.Adauga(prod);
                        }
                        else if (elem.Name == "Serviciu")
                        {
                            Serviciu serv = new Serviciu(
                                elemente.Count,
                                elem["Nume"]!.InnerText,
                                elem["CodIntern"]!.InnerText,
                                int.Parse(elem["Pret"]!.InnerText),
                                elem["Categorie"]!.InnerText);

                            pac.Adauga(serv);
                        }
                    }

                    if (!(elemente.Contains(pac)))
                        elemente.Add(pac);
                }

        }

        public override void ReadElement()
        {
            string? numeTmp, codInternTmp, categorieTmp;

            Console.WriteLine("Introdu pachetul, impreuna cu produsul si serviciile:");

            Console.Write("Numele pachetului: ");
            numeTmp = Console.ReadLine();

            Console.Write("Codul intern al pachetului: ");
            codInternTmp = Console.ReadLine();

            Console.Write("Categoria pachetului:");
            categorieTmp = Console.ReadLine();

            Pachet pac = new Pachet(
                elemente.Count,
                numeTmp,
                codInternTmp,
                categorieTmp);

            // ADAUGAM PRODUSE
            Console.Write($"Cate produse va avea pachetul (Maxim {Pachet.MaxP}): ");
            uint nrProduse;
            try { nrProduse = uint.Parse(Console.ReadLine() ?? string.Empty); }
            catch { Console.WriteLine("Nu a fost introdus un numar"); nrProduse = 0; }

            if (nrProduse > Pachet.MaxP)
            {
                nrProduse = Pachet.MaxP;
                Console.WriteLine($"Numarul maxim de produse al unui pachet este {Pachet.MaxP}");
            }
            mgrProduse!.ReadElemente(nrProduse);
            pac.Adauga(mgrProduse.GetElemente());


            // ADAUGAM SERVICII
            Console.Write($"Cate servicii va avea pachetul (Maxim {Pachet.MaxS}): ");
            uint nrServicii;
            try { nrServicii = uint.Parse(Console.ReadLine() ?? string.Empty); }
            catch { Console.WriteLine("Nu a fost introdus un numar"); nrServicii = 0; }

            if (nrServicii > Pachet.MaxS)
            {
                nrServicii = Pachet.MaxS;
                Console.WriteLine($"Numarul maxim de servicii al unui pachet este {Pachet.MaxS}");
            }
            mgrServicii!.ReadElemente(nrServicii);
            pac.Adauga(mgrServicii.GetElemente());

            if (!(elemente.Contains(pac)))
                elemente.Add(pac);
        }

        public void SortByPrice() => elemente.Sort();

        public override void Write2Console()
        {
            Console.WriteLine();
            Console.WriteLine("Lista pachete: ");
            base.Write2Console();
        }

    }
}
