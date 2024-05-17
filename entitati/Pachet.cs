using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace entitati
{
    public class Pachet : ProdusAbstract, IComparable
    {
        public static uint MaxP = 1;
        public static uint MaxS = 5;

        private uint currentProduse;
        private uint currentServicii;

        [XmlIgnore]
        public uint CurrentProduse { get => currentProduse; set => currentProduse = value; }
        [XmlIgnore]
        public uint CurrentServicii { get => currentServicii; set => currentServicii = value; }


        [XmlArray("Elemente"), XmlArrayItem(typeof(ProdusAbstract), ElementName = "Element")]
        public List<ProdusAbstract> Elem_pachet { get; set; } = new List<ProdusAbstract>();

        public Pachet() 
        {
            CurrentProduse = 0;
            CurrentServicii = 0;
        }
        public Pachet(int id, string? nume, string? codIntern, string? categorie,
            List<ProdusAbstract>? elem_pachet) : base(id, nume, codIntern, 0, categorie)
        {
            currentProduse = 0;
            currentServicii = 0;
            if (elem_pachet != null)
                foreach (ProdusAbstract elem in elem_pachet)
                    this.Adauga(elem);
        }
        public Pachet(int id, string? nume, string? codIntern, string? categorie)
             : base(id, nume, codIntern, 0, categorie)
        {
            currentProduse = 0;
            currentServicii = 0;
        }

        public void Adauga(IPackageable element)
        {
            if (element.canAddToPackage(this))
            {
                ProdusAbstract elem = (ProdusAbstract)element;
                if (elem.isA() == "Serviciu") CurrentServicii++;
                else if (elem.isA() == "Produs") CurrentProduse++;

                Elem_pachet!.Add(elem);
                Pret += elem.Pret;
            }
        }
        public void Adauga(IEnumerable<IPackageable> lista)
        {
            foreach(ProdusAbstract elem in lista)
                this.Adauga(elem);
        }

        public override string isA() => "Pachet";

        public override bool Equals(object? obj)
        {
            Pachet? pac = obj as Pachet;

            // Compara elementele pachetului
            foreach (ProdusAbstract elemThis in this.Elem_pachet!)
                foreach (ProdusAbstract elemPac in pac!.Elem_pachet!)
                    if (elemThis.Equals(elemPac))
                        return false;

            return base.Equals(pac);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Returneaza elementele pachetului ca un singur string
        public string ElemPachetToString()
        {
            if (Elem_pachet == null)
                return String.Empty;
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (ProdusAbstract el in this.Elem_pachet)
                    sb.Append('\t' + el.ToString() + '\n');
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return "Pachet: " + base.ToString() + '\n'
                + ElemPachetToString();
        }

        public override bool canAddToPackage(Pachet pachet)
        {
            return false;
        }

        //Pentru Sort(), le ia dupa Pret
        public int CompareTo(object? obj)
        {
            Pachet? pachet = obj as Pachet;
            if (pachet == null) return 1;

            if (pachet.Pret < this.Pret) return 1;
            else if (pachet.Pret > this.Pret) return -1;
            return 0;
        }
    }
}
