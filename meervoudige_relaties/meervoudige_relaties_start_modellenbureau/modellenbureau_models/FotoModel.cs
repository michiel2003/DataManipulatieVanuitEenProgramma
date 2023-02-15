using System;
using System.Collections.Generic;
using System.Text;

namespace modellenbureau_models
{
    public class FotoModel
    {

        public FotoModel(string naam, double pols, double lengte)
        {
            Naam = naam;
            Pols = pols;
            Lengte = lengte;
        }

        private double _lengte;

		public double Lengte
		{
			get { return _lengte; }
			set {
                if (value < 170 && value > 195)
                    throw new Exception("De ideale lengte is tussen de 170 en 195 cm.");
                _lengte = value;
			}
		}

		private String _naam;

		public String Naam
		{
			get { return _naam; }
			set {
				if (String.IsNullOrEmpty(value))
					throw new Exception("Model is niet ingevuld!");
				_naam = value;
			}
		}

		private double _pols;

		

		public double Pols
		{
			get { return _pols; }
			set {

                if (value < 10 && value > 20)
                    throw new Exception("De ideale polsmomtrek is tussen 10 en 20 cm.");
                _pols = value; 

			}
		}

		public double IdeaalGewicht()
		{
			return (this.Lengte + 4 * this.Pols - 100) / 2;
		}

		public override string ToString()
		{
			String text = $"Naam: {this.Naam} Lengte: {this.Lengte} Polsomtrek: {this.Pols} IdeaalGewicht: {Math.Round(this.IdeaalGewicht(), 1)}";
			return text;
		}

		public override bool Equals(object obj)
		{
			return obj is FotoModel model &&
				   Naam == model.Naam;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Naam);
		}
	}
}
