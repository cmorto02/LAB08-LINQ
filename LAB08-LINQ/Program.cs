using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace LAB08_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("No dupes or blanks---------------------");
            AllThree();
            Console.WriteLine("No dupes---------------------");
            RemoveDuplicates();
            Console.WriteLine("No blanks---------------------");
            FilterNeighborhoods();
            Console.WriteLine("Raw---------------------");
            GetAllNeighborhoods();


        }
        /// <summary>
        /// This method deserializes json data and then applies a LINQ query to get the neighborhood info
        /// </summary>
        static void GetAllNeighborhoods()
        {
            string path = "../../../data.json";
            var JSONData = "";
            using (StreamReader sr = File.OpenText(path))
            {
                JSONData = sr.ReadToEnd();
            }
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(JSONData);
            var query = from neighborhoods in root.features
                        select neighborhoods.properties.neighborhood;
            foreach(string neighborhood in query)
            {
                Console.WriteLine(neighborhood);
            }

        }
        /// <summary>
        /// This method deserializes json data and then applies a LINQ query to get the neighborhood info without places that dont have a name
        /// </summary>
        static void FilterNeighborhoods()
        {
            string path = "../../../data.json";
            var JSONData = "";
            using (StreamReader sr = File.OpenText(path))
            {
                JSONData = sr.ReadToEnd();
            }
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(JSONData);
            var query = from neighborhoods in root.features
                        where (neighborhoods.properties.neighborhood != "")
                        select neighborhoods.properties.neighborhood;
            foreach(string neighborhood in query)
            {
                Console.WriteLine(neighborhood);
            }
        }
        /// <summary>
        /// This method deserializes json data and then applies a LINQ query to get the neighborhood info without duplicates
        /// </summary>
        static void RemoveDuplicates()
        {
            string path = "../../../data.json";
            var JSONData = "";
            using (StreamReader sr = File.OpenText(path))
            {
                JSONData = sr.ReadToEnd();
            }
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(JSONData);
            var query = from neighborhoods in root.features
                        select neighborhoods.properties.neighborhood;
            foreach (string neighborhood in query.Distinct())
            {
                Console.WriteLine(neighborhood);
            }
        }
        /// <summary>
        /// This method deserializes json data and then applies a LINQ query to get the neighborhood info without duplicates and without places with no name
        /// </summary>
        static void AllThree()
        {
            string path = "../../../data.json";
            var JSONData = "";
            using (StreamReader sr = File.OpenText(path))
            {
                JSONData = sr.ReadToEnd();
            }
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(JSONData);
            var query = from neighborhoods in root.features
                        where (neighborhoods.properties.neighborhood != "")
                        select neighborhoods.properties.neighborhood;
            foreach (string neighborhood in query.Distinct())
            {
                Console.WriteLine(neighborhood);
            }
        }

        /// <summary>
        /// This method deserializes json data and then applies a LINQ query to get the neighborhood info without duplicates
        /// </summary>
        static void RemoveDupesOtherWay()
        {
            string path = "../../../data.json";
            var JSONData = "";
            using (StreamReader sr = File.OpenText(path))
            {
                JSONData = sr.ReadToEnd();
            }
            Rootobject root = JsonConvert.DeserializeObject<Rootobject>(JSONData);

            var query = root.features.Select(n => n.properties.neighborhood).Distinct();

            foreach (var n in query)
            {
                Console.WriteLine(n);
            }
        }
    }
}
