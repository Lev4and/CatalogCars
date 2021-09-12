namespace CatalogCars.Model.Formatters.String
{
    public class Declension
    {
        public static string DeclensionByNumeral(int value, string[] words, bool showNumeral = true)
        {
            var result = "";
            var numeral = value % 100;

            if (numeral > 19)
            {
                numeral %= 10;
            }

            if (words != null ? words.Length == 3 : false)
            {
                result = showNumeral ? $"{value} " : "";

                switch (value)
                {
                    case 1:
                        {
                            result += words[0];
                        }
                        break;
                    case 2:
                    case 3:
                    case 4:
                        {
                            result += words[1];
                        }
                        break;
                    default:
                        {
                            result += words[2];
                        }
                        break;
                }
            }

            return result;
        }
    }
}
