using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entitati;
using System.Xml;
using System.Xml.Serialization;

namespace App1
{
    public abstract class ProduseAbstractMgr
    {
        protected List<ProdusAbstract> elemente = new List<ProdusAbstract>();

        public virtual void InitializareElementeXML(string filePath) { throw new NotImplementedException(); }

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

        public virtual void save2XML(string filePath)
        {
            Type[] prodAbstractTypes =
                {typeof(Pachet), typeof(Produs), typeof(Serviciu)};

            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            StreamWriter sw = new StreamWriter(filePath);
            xs.Serialize(sw, elemente);
            sw.Close();
        }
        public virtual void loadFromXML(string filePath)
        {
            Type[] prodAbstractTypes =
                {typeof(Pachet), typeof(Produs), typeof(Serviciu)};

            XmlSerializer xs = new XmlSerializer(typeof(List<ProdusAbstract>), prodAbstractTypes);
            FileStream fs = new FileStream(filePath, FileMode.Open);
            XmlReader reader = new XmlTextReader(fs);
            List<ProdusAbstract> liProduse = (List<ProdusAbstract>)xs.Deserialize(reader)!;

            fs.Close();

            if (liProduse != null)
                foreach (ProdusAbstract elem in liProduse)
                    elemente.Add(elem);
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
        public IEnumerable<ProdusAbstract> GetElemente(ICriteriu criteriu)
        {
            FiltrareCriteriu filtru = new FiltrareCriteriu();
            return filtru.Filtrare(elemente, criteriu);
        }
        public IEnumerable<ProdusAbstract> GetElemente(params ICriteriu[] criterii)
        {
            FiltrareCriteriu filtru = new FiltrareCriteriu();
            return filtru.Filtrare(elemente, criterii);
        }
    }
}
