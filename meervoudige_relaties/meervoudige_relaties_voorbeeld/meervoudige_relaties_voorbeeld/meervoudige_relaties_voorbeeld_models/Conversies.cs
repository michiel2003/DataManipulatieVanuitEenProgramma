namespace meervoudige_relaties_voorbeeld_models
{
    public class Conversies
    {
        public static string ConverteerNumeriekNaarString(double waarde)
        {
            return waarde.ToString("0.00");
        }

        public static string ConverteerNumeriekNaarValuta(double waarde)
        {
            return waarde.ToString("c");
        }
    }
}