using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace modellenbureau_models
{
    public class ModellenBureau
    {

		List<FotoModel> Modellen = new List<FotoModel>();

		private String _naamBedrijf;

		public ModellenBureau(string naamBedrijf)
		{
			NaamBedrijf = naamBedrijf;
		}

		public String NaamBedrijf
		{
			get { return _naamBedrijf; }
			set {
				if (String.IsNullOrEmpty(value))
					throw new Exception("Bedrijfsnaam is niet ingevuld!");
				_naamBedrijf = value; 
			}
		}

		public override string ToString()
		{
			String text = $"Bureau {this.NaamBedrijf}\n";
			Modellen.ForEach(Model => text += Model.ToString() + "\n");
			return text;
		}

		public String DrukSlank()
		{
			String text = $"{this.NaamBedrijf}\n heeft de volgende superslanke modellen in dienst:";
			Modellen.Where(Model => Model.IdeaalGewicht() < 60)
				.ToList()
				.ForEach(Model => text += Model.Naam + "\n");
			return text;
		}

		public void voegToe(FotoModel model)
		{
			Modellen.Add(model);
		}

		public void voegToe(String naam, double pols, double lengte)
		{
			Modellen.Add(new FotoModel(naam, pols, lengte));
		}
	}
}
