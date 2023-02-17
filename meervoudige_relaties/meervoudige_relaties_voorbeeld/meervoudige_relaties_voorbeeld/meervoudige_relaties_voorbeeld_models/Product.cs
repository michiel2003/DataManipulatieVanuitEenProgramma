using System.Collections.Generic;
using System.Text;

namespace meervoudige_relaties_voorbeeld_models
{
    public class Product
    {
        // Auto-implemented properties: prop tab tab
        public string Code { get; set; }

        public string Beschrijving { get; set; }
        public double Prijs { get; set; }

        // Constructor met parameters
        public Product(string code, string beschrijving, double prijs)
        {
            Code = code;
            Beschrijving = beschrijving;
            Prijs = prijs;
        }

        // Methodes
        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.Append(this.Code.PadRight(15) + Conversies.ConverteerNumeriekNaarValuta(Prijs).PadLeft(10) + string.Empty.PadLeft(5) + this.Beschrijving);
            return message.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Product product && Code == product.Code;
        }

        public override int GetHashCode()
        {
            return -434485196 + EqualityComparer<string>.Default.GetHashCode(Code);
        }
    }
}