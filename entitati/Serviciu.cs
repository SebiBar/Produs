using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    public class Serviciu : ProdusAbstract
    {
        public Serviciu() { }

        public Serviciu(int id, string? nume, string? codIntern, int? pret, string? categorie)
            : base(id, nume, codIntern, pret, categorie)
        {
            
        }

        public override string isA() => "Serviciu";

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Serviciu: " + base.ToString();
        }

        public override bool canAddToPackage(Pachet pachet)
        {
            return pachet.CurrentServicii < Pachet.MaxS;
        }

        public override void save2XML (string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            StreamWriter sw = new StreamWriter(fileName);
            xs.Serialize(sw,this);
            sw.Close();
        }

        public override Serviciu? loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Serviciu));
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            Serviciu? serviciu = (Serviciu?)xs.Deserialize(reader);
            fs.Close();
            return serviciu;
        }
    }
}
