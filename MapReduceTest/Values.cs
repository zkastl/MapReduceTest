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
    }

    public enum BusyStatus
    {
        Available,
        Busy,
        Away
    }
}