using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace MapReduceTest
{
    class Program
    {
        /// <summary>
        /// ----
        /// MapReduce Program
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
        public static void Main(string[] args)
        {
            // Create a cars database if 
            if (args?.Length > 0 && args[0] == "--create")
                Car.MakeRandomCarDatabases();

            // Create a map function to only select cars over 100000 miles. 
            Func<Car, bool> overHundredThousand = new Func<Car, bool>(x => x.Miles > 100000);

            // Pull the base cars from the database and map them over the predicate.
            Car[] cars1 = GetCarsFromFile(@".\Cars1.json").Where(overHundredThousand).ToArray();
            Car[] cars2 = GetCarsFromFile(@".\Cars2.json").Where(overHundredThousand).ToArray();
            Car[] cars3 = GetCarsFromFile(@".\Cars3.json").Where(overHundredThousand).ToArray();

            // Reduce the cars back to a single collection and display to the user.
            PrintOldCars(cars1.Union(cars2).Union(cars3).ToArray());

            Console.ReadKey();
        }

        /// <summary>
        /// Pulls cars from a json file. No error checking, will throw exceptions if there are issues.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Car[] GetCarsFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open)))
                return JsonConvert.DeserializeObject<Car[]>(sr.ReadToEnd());
        }

        /// <summary>
        /// Prints the cars to the user using the cars' pretty print function
        /// </summary>
        /// <param name="oldCars"></param>
        public static void PrintOldCars(Car[] oldCars)
        {
            Console.WriteLine("These cars have over 100000 miles:");
            foreach (Car c in oldCars)
                Console.WriteLine("    " + c.PrettyPrint());
        }
    }
}
