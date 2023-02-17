using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using meervoudige_relaties_voorbeeld_models;

namespace meervoudige_relaties_voorbeeld_dal
{
    public class FileOperations
    {
        public static List<Product> BestandInlezen(string bestand)
        {
            List<Product> lijst = new List<Product>();
            List<string> gegevens = null;
            Product p = null;
            using (StreamReader reader = new StreamReader(bestand))
            {
                while (!reader.EndOfStream)
                {
                    gegevens = reader.ReadLine().Split(';').ToList();
                    try
                    {
                        switch (gegevens[0])
                        {
                            case "Product":
                                p = new Product(gegevens[1], gegevens[2], double.Parse(gegevens[3]));
                                break;

                            case "Boek":
                                p = new Boek(gegevens[1], gegevens[2], double.Parse(gegevens[3]), gegevens[4]);
                                break;

                            case "Software":
                                p = new Software(gegevens[1], gegevens[2], double.Parse(gegevens[3]), gegevens[4]);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        //fouten opvangen van double.parse
                    }
                    lijst.Add(p);
                }
            }

            return lijst;
        }

        public static void AddProduct(string bestand, Product product)
        {
            using (StreamWriter writer = new StreamWriter("Producten.txt", true))
            {
                writer.Write(product.GetType().Name.ToString() + ";" + product.Code + ";" + product.Beschrijving + ";" + product.Prijs + ";");

                if (product is Boek boek)
                {
                    writer.Write(boek.Auteur);
                }
                else if (product is Software software)
                {
                    writer.Write(software.Versie);
                }
                writer.WriteLine();
            }
        }
    }
}