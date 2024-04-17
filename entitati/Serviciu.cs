using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Serviciu : ProdusAbstract
    {
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
    }
}
