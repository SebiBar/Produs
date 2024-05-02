using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    [XmlRoot("ElemParticularizat")]
    public abstract class ProdusAbstract : IPackageable
    {

        private int id;
        private string? nume;
        private string? codIntern;
        private int? pret;
        private string? categorie;

        public ProdusAbstract() { }
        public ProdusAbstract(int id, string? nume, string? codIntern, int? pret, string? categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Pret = pret;
            Categorie = categorie;
        }

        [XmlElement("ID")]
        public int Id { get => id; set => id = value; }
        [XmlElement("Numele")]
        public string? Nume { get => nume; set => nume = value; }
        [XmlElement("CodulIntern")]
        public string? CodIntern { get => codIntern; set => codIntern = value; }
        [XmlElement("Pretul")]
        public int? Pret { get => pret; set => pret = value; }
        [XmlElement("Categoria")]
        public string? Categorie { get => categorie; set => categorie = value; }

        public override string ToString()
        {
            return this.Nume + " [" + this.CodIntern + "] " + this.Pret + "RON " + this.Categorie + " ";
        }

        public virtual string isA() => "ProdusAbstract";

        public override bool Equals(object? obj)
        {
            ProdusAbstract? elem = obj as ProdusAbstract;

            if (elem == null) return false;
            return this.Nume == elem.Nume && this.CodIntern == elem.CodIntern
                && this.Pret == elem.Pret && this.Categorie == elem.Categorie;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public virtual bool canAddToPackage(Pachet pachet)
        {
            return false;
        }

        public virtual void save2XML(string fileName) { throw new NotImplementedException { }; }
        public virtual ProdusAbstract? loadFromXML(string fileName) {  return null; }
    }
}
