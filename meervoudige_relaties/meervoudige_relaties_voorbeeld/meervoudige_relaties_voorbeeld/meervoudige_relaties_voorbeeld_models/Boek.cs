namespace meervoudige_relaties_voorbeeld_models
{
    public class Boek : Product
    {
        public string Auteur { get; set; }

        public Boek(string code, string beschrijving, double prijs, string auteur) :
            base(code, beschrijving, prijs)
        {
            this.Auteur = auteur;
        }

        public override string ToString()
        {
            return base.ToString() + " (" + this.Auteur + ")";
        }
    }
}