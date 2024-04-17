using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    internal class FiltrareCriteriu : IFiltrare
    {
        public IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> lista_elem, ICriteriu criteriu)
        {
            IEnumerable<ProdusAbstract> elemFiltrate =
                from elem in lista_elem
                where criteriu.IsIndeplinit(elem)
                select elem;

            return elemFiltrate;
        }

        public IEnumerable<ProdusAbstract> Filtrare(IEnumerable<ProdusAbstract> lista_elem,
            params ICriteriu[] criterii)
        {
            IEnumerable<ProdusAbstract> elemFiltrate =
                from elem in lista_elem
                where criterii.All(criteriu => criteriu.IsIndeplinit(elem))
                select elem;

            return elemFiltrate;
        }
    }
}
