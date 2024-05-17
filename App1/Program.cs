using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using entitati;

namespace App1
{
    internal class Program
    {
        //main
        static void Main(string[] args)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Produse.xml");
            string filePath = Path.GetFullPath(sFile);

            PachetMgr mgrPachete = new PachetMgr();

            Console.WriteLine("Introdu comanda dorita." +
                " Introdu comanda HELP pentru a vedea o lista cu toate comenzile.");

            string? input;
            string command = "";
            do
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("Comanda invalida."); 
                    continue;
                }
                else
                    input = input.ToUpper();

                string[] tokens = input.Split(' ');

                command = tokens[0];
                string[] arguments = tokens.Skip(1).ToArray();

                switch (command)
                {
                    case "TEST":
                        {
                            mgrPachete.loadFromXML(filePath!);
                            mgrPachete.Write2Console();
                            mgrPachete.save2XML(filePath!);
                        }
                        break;
                    case "READ":
                        {
                            if (arguments.Length == 0)
                                mgrPachete.ReadElement();
                            else if (arguments.Length == 1)
                                if (arguments[0] == "XML")
                                {
                                    mgrPachete.loadFromXML(filePath!);
                                    Console.WriteLine("Initializare cu succes.");
                                }
     
                                else if (arguments[0].All(char.IsDigit))
                                {
                                    mgrPachete.ReadElemente(uint.Parse(arguments[0]));
                                    Console.WriteLine("Citire cu succes.");
                                }
                                else
                                    Console.WriteLine("Argumente invalide.");
                        }
                        break;
                    case "SHOW":
                        {
                            mgrPachete.Write2Console();
                        }
                        break;
                    case "SORT":
                        {
                            mgrPachete.SortByPrice();
                        }
                        break;
                    case "FILTER":
                        {
                            if (arguments.Length < 2)
                                Console.WriteLine("Argumente invalide.");
                            else if (arguments[0] == "PRICE")
                            {
                                try
                                {
                                    char sign = arguments[1][0];
                                    if (!sign.Equals('<') && !sign.Equals('>') && !sign.Equals('='))
                                    {
                                        Console.WriteLine("Argumente invalide.");
                                        continue;
                                    }

                                    string strValue = arguments[1].Substring(1);
                                    int value = int.Parse(strValue);

                                    CriteriuPret critPret = new CriteriuPret(sign, value);
                                    IEnumerable<ProdusAbstract> filterList = mgrPachete.GetElemente(critPret);
                                    foreach (ProdusAbstract elem in filterList)
                                        Console.WriteLine(elem.ToString());
                                }
                                catch { Console.WriteLine("Argumente invalide."); }
                            }
                            else if (arguments[0] == "CATEGORY")
                            {
                                try
                                {
                                    string strValue = arguments[1].ToLower();
                                    strValue = char.ToUpper(strValue[0]) + strValue.Substring(1);

                                    CriteriuCategorie critCat = new CriteriuCategorie(strValue);
                                    IEnumerable<ProdusAbstract> filterList = mgrPachete.GetElemente(critCat);
                                    foreach (ProdusAbstract elem in filterList)
                                        Console.WriteLine(elem.ToString());
                                }
                                catch { Console.WriteLine("Argumente invalide."); }
                            }
                        }
                        break;
                    case "SAVE":
                        {
                            mgrPachete.save2XML(filePath!);
                        }
                        break;
                    case "CHANGEFILE":
                        {
                            string? tmp = Console.ReadLine();
                            if (tmp != null)
                                filePath = tmp;
                        }
                        break;
                    case "HELP":
                        {
                            Console.WriteLine("COMMAND [] -> Esential, () -> Optional");
                            Console.WriteLine("TEST -> DEV test");
                            Console.WriteLine("READ (XML / NR) -> Citeste pachet/e");
                            Console.WriteLine("SHOW -> Afiseaza toate pachetele");
                            Console.WriteLine("SORT -> Sorteaza pachetele dupa pret");
                            Console.WriteLine("SAVE -> salveaza pachetele curente");
                            Console.WriteLine("CHANGEFILE -> Alege fisierul XML folosit pentru salvare");
                            Console.WriteLine("FILTER [PRICE / CATEGORY] [VALUE] -> Filtreaza printre pachete");
                            Console.WriteLine("QUIT -> Inchide aplicatia");
                        }
                        break;
                    case "QUIT": break;
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            } while (command != "QUIT");
        }
    }
}

