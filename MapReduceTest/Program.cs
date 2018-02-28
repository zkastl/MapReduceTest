using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace MapReduceTest
{
    class Program
    {
        /// <summary>
        /// Driver for programs
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //CarsProgram(args);
            WeatherProgram(args);

            Console.ReadKey();
        }

        private static void WeatherProgram(string[] args)
        {
            // Create a map function to only select cars over 100000 miles. 
            Func<WeatherRecord, bool> belowFreezing = new Func<WeatherRecord, bool>(x => x.TemperatureCelsius < 0);

            // Create a weather record database if arguments are passed
            if (args?.Length > 0 && args[0] == "--create")
                WeatherRecord.MakeRandomWeatherDatabases();

            // Pull the base records from the database and map them over the predicate.
            WeatherRecord[] db1 = GetDataFromFile<WeatherRecord>(@".\wr1.json").Where(belowFreezing).ToArray();
            WeatherRecord[] db2 = GetDataFromFile<WeatherRecord>(@".\wr2.json").Where(belowFreezing).ToArray();
            WeatherRecord[] db3 = GetDataFromFile<WeatherRecord>(@".\wr3.json").Where(belowFreezing).ToArray();

            // Reduce the cars back to a single collection and display to the user.
            WeatherRecord[] records = db1.Union(db2).Union(db3).OrderBy(x => x.RDate).ToArray();
            Console.WriteLine("These cities were recorded below freezing (0C):");
            foreach (WeatherRecord r in records)
                Console.WriteLine("    " + r.PrettyPrint());
        }



        /// <summary>
        /// ----
        /// Car MapReduce Program
        /// 
        /// Thie Program simulate the basic concept of MapReduce on "shards" of
        /// three JSON files. These files contain many car entries consisting of:
        ///     make,
        ///     model,
        ///     year,
        ///     color,
        ///     miles
        /// This program will pull the shard files into memory, map each "shard"
        /// across a Predicate function that only accepts cars with 100000 miles or more,
        ///  and reduce the sub-shards into one array. This will be displayed to the user.
        ///  
        /// This program can also accept an argument to create/add new, random cars to the
        /// databases.
        /// ----
        /// </summary>
        /// <param name="args"></param>
        private static void CarsProgram(string[] args)
        {
            // Create a map function to only select cars over 100000 miles. 
            Func<Car, bool> overHundredThousand = new Func<Car, bool>(x => x.Miles > 100000);

            // Create a weather record database if arguments are passed
            if (args?.Length > 0 && args[0] == "--create")
                Car.MakeRandomCarDatabases();

            // Pull the base cars from the database and map them over the predicate.
            Car[] cars1 = GetDataFromFile<Car>(@".\Cars1.json").Where(overHundredThousand).ToArray();
            Car[] cars2 = GetDataFromFile<Car>(@".\Cars2.json").Where(overHundredThousand).ToArray();
            Car[] cars3 = GetDataFromFile<Car>(@".\Cars3.json").Where(overHundredThousand).ToArray();

            // Reduce the cars back to a single collection and display to the user.
            Car[] oldCars = cars1.Union(cars2).Union(cars3).ToArray();
            Console.WriteLine("These cars have over 100000 miles:");
            foreach (Car c in oldCars)
                Console.WriteLine("    " + c.PrettyPrint());
        }

        /// <summary>
        /// Pulls cars from a json file. No error checking, will throw exceptions if there are issues.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static T[] GetDataFromFile<T>(string fileName)
        {
            using (StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open)))
                return JsonConvert.DeserializeObject<T[]>(sr.ReadToEnd());
        }
    }
}
