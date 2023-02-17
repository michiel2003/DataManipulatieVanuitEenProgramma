using System;
using System.Collections.Generic;

namespace meervoudige_relaties_voorbeeld_models
{
    public class Order
    {
        // Auto-implemented property
        public string Ordernummer { get; set; }

        //// Bovenstaande lijn komt overeen met onderstaande in commentaar
        //private string _ordernummer;
        //public string Ordernummer
        //{
        //    get { return _ordernummer; }
        //    set
        //    {
        //        _ordernummer = value;
        //    }
        //}

        // READ-ONY AUTO-IMPLEMENTED PROPERTY: Enkel de constructor kan deze instellen
        public List<Orderlijn> Orderlijnen { get; }

        public Order()
        {
            // Initialiseer de Orderlijnen, anders krijgen we NullPointerExceptions
            this.Orderlijnen = new List<Orderlijn>();
            this.Ordernummer = Guid.NewGuid().ToString();
        }

        public void ToevoegenOrderlijn(Orderlijn orderlijn)
        {
            // Voeg een orderlijn toe als deze nog niet bestaat
            // Contains maakt gebruik van Equals,
            // in dit geval wordt er gezocht naar de Equals methode van de klasse Orderlijn.
            // Als de klasse Orderlijn de methode Equals niet implementeert, dan wordt de Equals van de klasse Object gebruikt.
            // Equals van de klasse Object vergelijkt op basis van pointer (locatie in het geheugen)!
            // Dit is kan voor problemen zorgen, zo zullen
            //  Orderlijn orderlijn1 = new Orderlijn(new Product("vb1", "vb1", 10.5), 1)); en
            //  Orderlijn orderlijn2 = new Orderlijn(new Product("vb1", "vb1", 10.5), 1));
            // niet gelijk zijn volgens de default implementatie van Equals in de klasse Object.
            if (!Orderlijnen.Contains(orderlijn))
            {
                Orderlijnen.Add(orderlijn);
            }
            else
            {
                Orderlijnen.Find(x => x.Equals(orderlijn)).Hoeveelheid += orderlijn.Hoeveelheid;
            }
        }

        public void VerwijderenOrderlijn(Orderlijn orderlijn)
        {
            // Remove maakt gebruik van Equals,
            // in dit geval wordt er gezocht naar de Equals methode van de klasse Orderlijn.
            // Als de klasse Orderlijn de methode Equals niet implementeert, dan wordt de Equals van de klasse Object gebruikt.
            // Equals van de klasse Object vergelijkt op basis van pointer (locatie in het geheugen)!
            Orderlijnen.Remove(orderlijn);
        }

        public double Totaal()
        {
            double totaal = 0;

            // lambda expressie
            Orderlijnen.ForEach(x => totaal += x.Subtotaal());

            // Doorloop elk orderlijn in de lijst via een foreach.
            // De lambda expressie als de foreach zijn equivalent.
            //foreach (Orderlijn orderlijn in Orderlijnen)
            //{
            //    //tel bij het totaal het subtotaal van orderlijn op
            //    totaal += orderlijn.Subtotaal();
            //}
            return totaal;

            // Onderstaande code is een derde alternatief.
            // De Aggregate methode neemt 2 parameters, de eerste is een startwaarde, in dit geval 0.0.
            // De tweede paramter is een functie die op elke element in de collectie losgelaten wordt, één per één.
            // Deze functie heeft op zijn beurt ook 2 parameters, de eerste is de vorige waarde, initieel 0.
            // De tweede is het huidige item in de lijst, het resultaat van de functie wordt de eerste parameter
            // voor de volgende keer dat de functie uitgevoerd wordt. Als er geen items meer in de lijst zijn,
            // dan wordt het resultaat van de functie als eindresultaat gegeven.
            // Om deze syntax te gebruiken moet je System.Linq gebruiken.
            //return Orderlijnen.Aggregate(0.0, (totaal, orderlijn) => totaal + orderlijn.Subtotaal());
        }

        public override string ToString()
        {
            string tekst = "";
            tekst += "Order " + Ordernummer + Environment.NewLine;
            tekst += "bevat de volgende orderlijnen:" + Environment.NewLine;
            Orderlijnen.ForEach(x => tekst += x.ToString());
            tekst += Environment.NewLine;
            tekst += "Totaal: " + Conversies.ConverteerNumeriekNaarValuta(Totaal());
            return tekst;

            // Voor de geintereseerden
            // Als je veel wijzigingen doet aan een string, bijvoorbeeld in een lus,
            // dan is een StringBuilder regelmatig efficienter.
            // In bovenstaand voormeeld wordt voor elke keer dat tekst += gebruikt wordt,
            // een nieuwe string aangemaakt (nieuw object).
            // Onderstaande code maakt slechts één string aan en is veel efficienter
            // als er veel producten in de orderlijn zitten.

            //StringBuilder sb = new StringBuilder();
            //sb.Append($"Order {Ordernummer}");
            //sb.Append(Environment.NewLine);
            //sb.Append("bevat de volgende orderlijnen:");
            //sb.Append(Environment.NewLine);
            //Orderlijnen.ForEach(x => sb.Append(x.ToString()));
            //sb.Append(Environment.NewLine);
            //sb.Append($"Totaal: {Conversies.ConverteerNumeriekNaarValuta(Totaal())}");

            //return sb.ToString();
        }
    }
}