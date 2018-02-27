using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MapReduceTest
{
    [Serializable]
    class WeatherRecord
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime RDate { get; set; }
        public double TemperatureCelsius { get; set; }
        public double TemperatureFarenheit { get { return TemperatureCelsius * 1.8 + 32; } }

        public WeatherRecord()
        {
            City = "Oklahoma City";
            State = "OK";
            Country = "US";
            RDate = DateTime.Now;
            TemperatureCelsius = 37;
        }

        public WeatherRecord(DateTime rdate, double tempC, string city, string country, string state = "")
        {
            City = city;
            State = state;
            Country = country;
            RDate = rdate;
            TemperatureCelsius = tempC;
        }

        public string PrettyPrint() =>
            RDate.ToLongDateString() + ": Location - " + City + ", " + (!string.IsNullOrEmpty(State) ? (State + ", " + Country) : (Country)) + "---" + TemperatureCelsius + "C/" + TemperatureFarenheit + "F\n";

        public static async void MakeRandomWeatherDatabasesAsync(int numberDatabases, int numberOfCities)
        {
            await Task.Run(new Action(() =>
            {

            }))


            Random rand = new Random();
            List<WeatherRecord> wr1 = new List<WeatherRecord>();
            List<WeatherRecord> wr2 = new List<WeatherRecord>();
            List<WeatherRecord> wr3 = new List<WeatherRecord>();

            

            for (int i = 0; i < 30; i++)
            {
                string[] parsed = Values.CityStateCountry[rand.Next(Values.CityStateCountry.Length)].Split(',');
                wr2.Add(
                    new WeatherRecord(
                        new DateTime(rand.Next(1980, 2018), rand.Next(1, 12), rand.Next(1, 28)),
                        rand.Next(CelsiusRange.Lowest, CelsiusRange.Highest),
                        parsed[0], parsed[2], parsed[1])
                        );
            }

            for (int i = 0; i < 30; i++)
            {
                string[] parsed = Values.CityStateCountry[rand.Next(Values.CityStateCountry.Length)].Split(',');
                wr3.Add(
                    new WeatherRecord(
                        new DateTime(rand.Next(1980, 2018), rand.Next(1, 12), rand.Next(1, 28)),
                        rand.Next(CelsiusRange.Lowest, CelsiusRange.Highest),
                        parsed[0], parsed[2], parsed[1])
                        );
            }

            using (StreamWriter sw = new StreamWriter(@".\wr2.json"))
                sw.Write(JsonConvert.SerializeObject(wr2));

            using (StreamWriter sw = new StreamWriter(@".\wr3.json"))
                sw.Write(JsonConvert.SerializeObject(wr3));

            return;
        }

        private static void MakeRecords(int numberOfCities, string fileName)
        {
            Random rand = new Random();
            for (int i = 0; i < 30; i++)
            {
                List<WeatherRecord> wr1 = new List<WeatherRecord>();
                string[] parsed = Values.CityStateCountry[rand.Next(Values.CityStateCountry.Length)].Split(',');
                wr1.Add(
                    new WeatherRecord(
                        new DateTime(rand.Next(1980, 2018), rand.Next(1, 12), rand.Next(1, 28)),
                        rand.Next(CelsiusRange.Lowest, CelsiusRange.Highest),
                        parsed[0], parsed[2], parsed[1])
                        );

                using (StreamWriter sw = new StreamWriter(fileName))
                    sw.Write(JsonConvert.SerializeObject(wr1));
            }

        }
    }
}