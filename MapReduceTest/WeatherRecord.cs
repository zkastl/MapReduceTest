using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            RDate.ToLongDateString() + ": Location - " + City + ", " + (!string.IsNullOrEmpty(State) ? (State + ", " + Country) : (Country)) + "--- " + TemperatureCelsius + "C/" + TemperatureFarenheit + "F\n";

        public static void MakeRandomWeatherDatabases(int numberDatabases=3, int numberOfCities=30)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < numberDatabases; i++)
            {
                string d = (i + 1).ToString();
                tasks.Add(new Task(new Action(() => { MakeRecords(numberOfCities, @"wr" + d.ToString() + ".json"); })));
            }

            foreach (Task t in tasks)
                t.Start();

            while (tasks.Where(t => t.IsCompleted).Count() < tasks.Count) continue;

            return;
        }

        private static void MakeRecords(int numberOfCities, string fileName)
        {
            Random rand = new Random();
            List<WeatherRecord> wr1 = new List<WeatherRecord>();
            for (int i = 0; i < 30; i++)
            {
                string[] parsed = Values.CityStateCountry[rand.Next(Values.CityStateCountry.Length)].Split(',');
                wr1.Add(
                    new WeatherRecord(
                        new DateTime(rand.Next(1980, 2018), rand.Next(1, 12), rand.Next(1, 28)),
                        rand.Next(CelsiusRange.Lowest, CelsiusRange.Highest),
                        parsed[0], parsed[2], parsed[1])
                );
            }

            using (StreamWriter sw = new StreamWriter(fileName))
                sw.Write(JsonConvert.SerializeObject(wr1));

        }
    }
}