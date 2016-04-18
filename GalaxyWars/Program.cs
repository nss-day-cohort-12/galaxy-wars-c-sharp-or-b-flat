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

        List<AlienSpecies> speciesList = new List<AlienSpecies> { spacePope, nasa, stormTroopers };

        var battleRules = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string> ("Science", "Religion"),
            new KeyValuePair<string, string> ("Religion", "Warrior"),
            new KeyValuePair<string, string> ("Warrior", "Science")
        };

        int year = 1;

        while (spacePope.population > 0 && nasa.population > 0 && stormTroopers.population > 0)
        {
            Console.WriteLine("It is year {0}.", year);
            if (year > 1) // if at least one year has passed, grant bonus pop to science type
            {
                foreach (AlienSpecies species in speciesList)
                {
                    if (species.affiliation == "Science")
                    {
                        species.population += 5000;
                        Console.WriteLine("{0} gained a 5000 population bonus.", species.name);
                    }
                }
            }
            if (year % 25 == 0)
            {
                Console.WriteLine("The rules of the universe are changing!");
                Random rnd = new Random(); // generate random number to choose random battle rule
                int randomInt = rnd.Next(0,2);

                KeyValuePair<string, string> ruleToChange = battleRules[randomInt];

                string newKey = "";
                string newValue = "";

                newKey = ruleToChange.Value; // create references for new key value pair
                newValue = ruleToChange.Key;

                battleRules.Remove(ruleToChange); // remove old rule
                battleRules.Add(new KeyValuePair<string, string>(newKey, newValue)); // add new reversed rule
            }

            foreach (AlienSpecies currAttacker in speciesList) // let each species attack once
            {
                Console.WriteLine("{0} is attacking!", currAttacker.name);
                foreach (AlienSpecies currDefender in speciesList) // let each species defend once against each attacker
                    {   
                        if (currAttacker.name != currDefender.name) // apply bonus attack from battle rules
                        {
                            Console.WriteLine("{0}'s current opponent is {1}.", currAttacker.name, currDefender.name);
                            var whoAttackerBeats = new List<string> { };
                            foreach (KeyValuePair<string, string> rule in battleRules) // loop through rules
                            {
                                if (rule.Key == currAttacker.affiliation) // add each type attacker defeats to list
                                {
                                    whoAttackerBeats.Add(rule.Value);
                                }
                            }
                            foreach (string defenderType in whoAttackerBeats)
                            {
                                if (currDefender.affiliation == defenderType)
                                {
                                    currDefender.population -= Math.Floor(currDefender.population * .02);
                                    Console.WriteLine("{0} attacks {1}. Their population is reduced to {2}.", currAttacker.name, currDefender.name, currDefender.population);
                                }
                                // make sure no one is dead
                            }
                        }

                    if (currAttacker.affiliation == "Warrior") // add warrior type bonus
                    {
                        currDefender.population -= 10000;
                        Console.WriteLine("{0}, the warriors, kill extra 10000. {1}'s population is now {2}.", currAttacker.name, currDefender.name, currDefender.population);
                        // make sure no one is dead
                    }
                    if (currAttacker.affiliation == "Religion" && currDefender.affiliation != "Religion")
                    {
                        double bonus = Math.Floor(currDefender.population * .01);
                        currAttacker.population += bonus; // religious attacker gains some population from defender
                        currDefender.population -= bonus; // defender loses population to religious attacker
                        Console.WriteLine("{0}, the religious type, convert some {1} to their side. Religious type now has {2} population. Defender now has {3} population.", currAttacker.name, currDefender.name, currAttacker.population, currDefender.population);
                        // make sure no one is dead
                    }                
                }
            }

            // base population decline
            foreach (AlienSpecies species in speciesList)
            {
                species.population -= 20000;
                Console.WriteLine("As a result of war, all populations lose 20000 points.");
                    if (species.population <= 0)
                    {
                    Console.WriteLine("***{0} is dead! GAME OVER***", species.name);
                    }
                // make sure no one is dead
            }
            Console.ReadLine();
            year++;  
      }
    }
  }
}
