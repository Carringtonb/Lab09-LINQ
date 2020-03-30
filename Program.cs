﻿using System;
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
            string path = @"/Users/carringtonbeard/codefellows/401/Lab09-LINQ/Lab09-LINQ/data.JSON";
       

            JObject jObject = CreateJObject(path);
            //JObject cities = JObject.Parse(File.ReadAllText(path));
            RootObjects rootObject = new RootObjects();
            rootObject = jObject.ToObject<RootObjects>();
            Console.WriteLine("Hello World!");
            newQuery(rootObject);
        }
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
        }

        
    }

}