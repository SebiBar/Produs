using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using entitati;

namespace App1
{
    public abstract class ProduseAbstractMgr
    {
        protected List<ProdusAbstract> elemente = new List<ProdusAbstract>();

        public abstract void InitializareElementeXML();

        public abstract void ReadElement();

        public void ReadElemente(uint nr)
        {
            for (int cnt = 0; cnt < nr; cnt++)
                ReadElement();
        }

        public virtual void Write2Console()
        {
            foreach (ProdusAbstract element in elemente)
                Console.WriteLine(element.ToString() + " ");
        }

        public IEnumerable<ProdusAbstract> GetElemente()
        {
            return elemente;
        }
        public IEnumerable<ProdusAbstract> GetElemente(String nume_elem)
        {
            IEnumerable<ProdusAbstract> interrog =
                from elem in elemente
                where elem.Nume == nume_elem
                orderby elem.Nume
                select elem;

            return interrog;
        }
    }
}
