using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    internal class CriteriuPret : ICriteriu
    {
        private int pretCriteriu;

        public CriteriuPret(int pret)
        {
            pretCriteriu = pret;
        }

        public bool IsIndeplinit(ProdusAbstract elem)
        {
            return elem.Pret == pretCriteriu;
        }
    }
}
