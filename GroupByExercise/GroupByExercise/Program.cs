using System;
using System.Collections.Generic;

namespace GroupByExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();
            Random rng = new Random();
            for( int i = 0; i < 1000000; i++)
            {
                allPeople.Add(new Person(rng.Next(), (City)rng.Next(81)));
            }

            var groupedPeopleByCity = GroupByCity(allPeople);

            foreach( City homeCity in groupedPeopleByCity.Keys)
            {
                Console.WriteLine( homeCity + " contains " + groupedPeopleByCity[homeCity].Count + " people."  );
            }

        }

        private static Dictionary<City, List<Person>> GroupByCity(List<Person> allPeople)
        {
            Dictionary<City, List<Person>> toReturn = new Dictionary<City, List<Person>>();

            for(int i = 0; i < allPeople.Count; i++)
            {
                if (toReturn.ContainsKey(allPeople[i].HomeCity))
                {
                    toReturn[allPeople[i].HomeCity].Add(allPeople[i]);
                }
                else
                {
                    toReturn.Add(allPeople[i].HomeCity, new List<Person> { allPeople[i]});
                }
            }

            return toReturn;
        }
    }
}
