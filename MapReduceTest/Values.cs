/// <summary>
/// Collection of useful tools to help create random data.
/// </summary>
namespace MapReduceTest
{
    public abstract class Values
    {
        public static string[] Makes = new string[]
        {
            "Chevorlet",
            "Henry",
            "Honda",
            "Hyundei",
            "Voltswagon",
            "Subareu",
            "Toyota",
            "Porche",
            "Saab"
        };

        public static string[] Models = new string[]
        {
            "Silverado",
            "Fusion",
            "Mustang",
            "S110",
            "Cobalt",
            "Ram 1500",
            "Bug",
            "Camery",
            "Sonata",
            "Venture",
            "Equinox",
            "Solstice",
            "F150",
            "F250",
            "F350",
            "Sierra"
        };

        public static string[] Colors = new string[]
        {
            "Green",
            "Blue",
            "Red",
            "White",
            "Black",
            "Gray",
            "Yellow",
            "Champaine"
        };

        public static string[] CityStateCountry = new string[]
        {
            "Los Angeles,CA,US",
            "Salt Lake City,UT,US",
            "Oklahoma City,OK,US",

            "Orlando,FL,US",
            "Columubs,OH,US",
            "Honolulu,HI,US",

            "Las Vegas,NV,US",
            "New York City,NY,US",
            "Seattle,WA,US",

            "Birmingham,AL,US",
            "Minot,ND,US",
            "Tulsa,OK,US",

            "Tucson,AZ,US",
            "Burlington,OK,US",
            "Fresno,CA,US",

            "Chicago,IL,US",
            "Omaha,NB,US",
            "Lubbock,TX,US",

            "Philadelphia,PA,US",
            "Miami,FL,US",
            "New Orleans,LA,US",

            "Phoenix,AZ,US",
            "Lincoln,NB,US",
            "Atlanta,GA,US",

            "Boston,MA,US",
            "Palmdale,CA,US",
            "Cheyenne,WY,US",

            "Kansas City,MO,US",
            "Lexington,KY,US",
            "Virginia Beach,VA,US",

            "Indianapolis,IN,US",
            "Madison,WI,US",
            "Akron,OH,US",

            "Cancun,,MX",
            "London,,UK",
            "Vancouver,BC,CA",
            "Sochi,,RU",
            "Paris,,FR",
            "Sydney,NSW,AU",
            "Pyeongchang,,SK",
            "Edinburgh,,UK",
            "Rio de Janerio,,BR",
            "Reykjavik,,IS"
        };
    }

    public static class CelsiusRange
    {
        public static int Lowest = -89;
        public static int Highest = 59;
    }

    public enum BusyStatus
    {
        Available,
        Busy,
        Away
    }
}