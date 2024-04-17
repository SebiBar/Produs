namespace entitati
{
    public class Produs : ProdusAbstract
    {
        private string? producator;

        public Produs(int id, string? nume, string? codIntern, int? pret, string? categorie, string? producator) 
            : base(id, nume, codIntern, pret, categorie)
        {
           Producator = producator;
        }

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
    }

}
