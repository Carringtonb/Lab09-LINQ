using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Lab09_LINQ.Classes;
using System.Collections.Concurrent;
using System.Linq;


namespace Lab09_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../data.JSON";
       

            JObject jObject = CreateJObject(path);
            //JObject cities = JObject.Parse(File.ReadAllText(path));
            RootObjects rootObject = new RootObjects();
            rootObject = jObject.ToObject<RootObjects>();
            Console.WriteLine("Hello World!");
            newQuery(rootObject);
        }

        // Question 1 ==========

        /// <summary>
        /// creates a JObject using streamreader
        /// </summary>
        /// <param name=“path”></param>
        /// <returns>JObject</returns>
        public static JObject CreateJObject(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                JObject jList = (JObject)JToken.ReadFrom(new JsonTextReader(sr));
                return jList;
            }
        }

        // Question 2 ============

        /// <summary>
        /// Queries the JSON file and outputs all neighborhoods that have a name
        /// </summary>
        /// <param name="rootObject"></param>
        static void newQuery(RootObjects rootObject)
        {
            var allNeighbor = rootObject.features.Select(x => x.properties.neighborhood);

                int count = 0;
            foreach (string neighborhood in allNeighbor)
            {
                if (neighborhood.Equals(""))
                {

                    Console.WriteLine("does not exist");
                }
                else
                {
                    count++;
                    Console.WriteLine($"{count}: {neighborhood}, \n");
                }
            }

            // Question 3 ============
            var filtered = allNeighbor.Distinct();
            count = 0;
            foreach (string filteredHoods in filtered)
            {
                if (filteredHoods.Equals(""))
                {
                    Console.WriteLine("does not exist");
                }
                else
                {
                    count++;
                    Console.WriteLine($"{count}: {filteredHoods}");
                };
            }

            // Question 4 ============
            var oneQuery = allNeighbor.Where(x => x != "").Distinct();
            count = 0;
            foreach (string neighborhood in oneQuery)
            {
                count++;
                Console.WriteLine($"{count}: { neighborhood}, \n");
            }

            //Question 5 ============

            var inlineQuery = (from item in rootObject.features where item.properties.neighborhood != "" select item.properties.neighborhood).Distinct();

            count = 0;
            foreach (string hood in inlineQuery)
            {
                count++;
                Console.WriteLine($"{count}: {hood}");
            }
        }

        
    }

}