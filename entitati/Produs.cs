using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    public class Produs : ProdusAbstract
    {
        private string? producator;

        public Produs() { }
        public Produs(int id, string? nume, string? codIntern, int? pret, string? categorie, string? producator) 
            : base(id, nume, codIntern, pret, categorie)
        {
           Producator = producator;
        }

        [XmlElement("Producator")]
        public string? Producator { get => producator; set => producator = value; }

        public override string isA() => "Produs";

        public override bool Equals(object? obj)
        {
            Produs? elem = obj as Produs;
            return base.Equals(elem) && this.Producator == elem.Producator;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Produs: " + base.ToString() + "(" + Producator + ") ";
        }

        public override bool canAddToPackage(Pachet pachet)
        {
            return pachet.CurrentProduse < Pachet.MaxP;
        }

        public override void save2XML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Produs));
            StreamWriter sw = new StreamWriter(fileName);
            xs.Serialize(sw, this);
            sw.Close();
        }

        public override Produs? loadFromXML(string fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Produs));
            FileStream fs = new FileStream(fileName, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            Produs? produs = (Produs?)xs.Deserialize(reader);
            fs.Close();
            return produs;
        }
    }

}
