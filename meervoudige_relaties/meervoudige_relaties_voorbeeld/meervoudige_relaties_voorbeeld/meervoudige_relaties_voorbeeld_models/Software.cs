namespace meervoudige_relaties_voorbeeld_models
{
    public class Software : Product
    {
        // Auto-implemented property
        public string Versie { get; set; }

        public override string ToString()
        {
            return base.ToString() + " Version: " + this.Versie;
        }

        public Software(string code, string beschrijving, double prijs, string versie) :
            base(code, beschrijving, prijs)
        {
            this.Versie = versie;
        }
    }
}