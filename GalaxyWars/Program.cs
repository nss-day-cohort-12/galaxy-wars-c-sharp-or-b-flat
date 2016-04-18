using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWars.Species;
using System.Reflection;

namespace GalaxyWars
{
  class Program
  {
    static void Main(string[] args)
    {
        SpacePope spacePope = new SpacePope(); // create instance of space pope species
        NASA nasa = new NASA(); // create instance of NASA species
        StormTroopers stormTroopers = new StormTroopers(); // create instance of storm trooper species

        //var speciesArray = new Species[] { spacePope, nasa, stormTroopers };
        List<AlienSpecies> speciesList = new List<AlienSpecies> { spacePope, nasa, stormTroopers };

        //Dictionary<string, string> battleRules = new Dictionary<string, string>
        //{
        //    { "Science", "Religion" },
        //    { "Religion", "Warfare" },
        //    { "Warfare", "Science" }
        //};

        var battleRules = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string> ("Science", "Religion"),
            new KeyValuePair<string, string> ("Religion", "Warfare"),
            new KeyValuePair<string, string> ("Warfare", "Science")
        };

        int year = 2;

            //while (spacePope.population > 0 && nasa.population > 0 && stormTroopers.population > 0)
            //{
                if (year > 1) // if at least one year has passed, grant bonus pop to science type
                {
                    foreach (AlienSpecies species in speciesList)
                    {
                        if (species.affiliation == "Science")
                        {
                            species.population += 5000;
                        }
                        Console.WriteLine("{0} has {1} population.", species.name, species.population);
                        Console.ReadLine();
                    }
                }
            //if (year % 25 == 0)
            {
                Random rnd = new Random(); // generate random number to choose random battle rule
                int randomInt = rnd.Next(0,2);

                KeyValuePair<string, string> ruleToChange = battleRules[randomInt];

                string newKey = "";
                string newValue = "";

                newKey = ruleToChange.Value; // create references for new key value pair
                newValue = ruleToChange.Key;

                battleRules.Remove(ruleToChange); // remove old rule
                battleRules.Add(new KeyValuePair<string, string>(newKey, newValue)); // add new reversed rule

                foreach (KeyValuePair<string, string> rule in battleRules)
                {
                    Console.WriteLine(rule); 
                }
                Console.ReadLine();

            }

                //    year++;  
                //}


            }
  }
}
