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
        private char? semnCriteriu;

        public CriteriuPret(int pret)
        {
            pretCriteriu = pret;
        }

        public CriteriuPret(char semn, int pret)
        {
            pretCriteriu = pret;
            semnCriteriu = semn;
        }

        public bool IsIndeplinit(ProdusAbstract elem)
        {
            if (semnCriteriu == null)
                return elem.Pret == pretCriteriu;
            else if (semnCriteriu == '>')
                return elem.Pret >= pretCriteriu;
            else if (semnCriteriu == '<')
                return elem.Pret <= pretCriteriu;
            else
                return elem.Pret == pretCriteriu;
        }
    }
}
