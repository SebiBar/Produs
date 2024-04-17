using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class CriteriuCategorie : ICriteriu
    {
        private string categorieCriteriu;

        public CriteriuCategorie(string categorie)
        {
            categorieCriteriu = categorie;
        }

        public bool IsIndeplinit(ProdusAbstract elem)
        {
            return elem.Categorie == categorieCriteriu;
        }
    }
}
