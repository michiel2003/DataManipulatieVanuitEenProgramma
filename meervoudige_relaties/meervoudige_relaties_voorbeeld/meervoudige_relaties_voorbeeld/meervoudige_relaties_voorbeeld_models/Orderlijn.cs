using System.Collections.Generic;

namespace meervoudige_relaties_voorbeeld_models
{
    public class Orderlijn
    {
        // Auto-implemented properties
        public Product Product { get; set; }  // Product is een navigatieProperty naar het object Product.

        public int Hoeveelheid { get; set; }

        //constructor
        public Orderlijn(Product product, int hoeveelheid)
        {
            this.Product = product;
            this.Hoeveelheid = hoeveelheid;
        }

        //methodes
        public double Subtotaal()
        {
            // Onderstaande is een ternary expression.
            // Een ternary expression heeft steeds de vorm "a ? b : c".
            // Dit kan gelezen worden als: "Als a dan b en anders c".
            return Product != null ? Product.Prijs * Hoeveelheid : 0;

            //// Verkort

            //// Enkel als product geinitialiseerd is -> prijs berekenen
            //if (Product != null)
            //{
            //    return Product.Prijs * Hoeveelheid;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public override string ToString()
        {
            if (Product != null)
            {
                return this.Hoeveelheid.ToString().PadLeft(3) + string.Empty.PadLeft(5)
                    + this.Product.Beschrijving.PadRight(20)
                    + Conversies.ConverteerNumeriekNaarValuta(Subtotaal()).PadLeft(10);
            }
            else
            {
                return "geen product gekend!";  // Als product niet geinitialiseerd is
            }
        }

        public override bool Equals(object obj)
        {
            // Producten moeten hetzelfde zijn -> equals bij klasse product
            return obj is Orderlijn orderlijn && this.Product.Equals(orderlijn.Product);
        }

        public override int GetHashCode()
        {
            return 680826068 + EqualityComparer<Product>.Default.GetHashCode(Product);
        }
    }
}