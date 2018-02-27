using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MapReduceTest
{
    [Serializable]
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Miles { get; set; }
        public int Id { get; private set; }

        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = 2018;
            Color = "White";
            Miles = 0;
            Id = GetHashCode();
        }

        public Car(string make, string model, int year, string color, int miles)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Miles = miles;
            Id = GetHashCode();
        }

        public string PrettyPrint() =>
            Color + ", " + Year + " " + Make + " " + Model + " with " + Miles + " miles";

        public static void MakeRandomCarDatabases()
        {
            Random rand = new Random();
            List<Car> cars1 = new List<Car>();
            List<Car> cars2 = new List<Car>();
            List<Car> cars3 = new List<Car>();
            for (int i = 0; i < rand.Next(1000); i++)
            {
                cars1.Add(new Car(Values.Makes[rand.Next(1000) % Values.Makes.Length],
                    Values.Models[rand.Next(1000) % Values.Models.Length], rand.Next(1995, 2018),
                    Values.Colors[rand.Next(1000) % Values.Colors.Length], rand.Next(150000)));
            }

            for (int i = 0; i < rand.Next(1000); i++)
            {
                cars2.Add(new Car(Values.Makes[rand.Next(1000) % Values.Makes.Length],
                    Values.Models[rand.Next(1000) % Values.Models.Length], rand.Next(1995, 2018),
                    Values.Colors[rand.Next(1000) % Values.Colors.Length], rand.Next(150000)));
            }

            for (int i = 0; i < rand.Next(1000); i++)
            {
                cars3.Add(new Car(Values.Makes[rand.Next(1000) % Values.Makes.Length],
                    Values.Models[rand.Next(1000) % Values.Models.Length], rand.Next(1995, 2018),
                    Values.Colors[rand.Next(1000) % Values.Colors.Length], rand.Next(150000)));
            }

            using (StreamWriter sw = new StreamWriter(@".\Cars1.json"))
                sw.Write(JsonConvert.SerializeObject(cars1));

            using (StreamWriter sw = new StreamWriter(@".\Cars2.json"))
                sw.Write(JsonConvert.SerializeObject(cars2));

            using (StreamWriter sw = new StreamWriter(@".\Cars3.json"))
                sw.Write(JsonConvert.SerializeObject(cars3));

            return;
        }
    }
}
