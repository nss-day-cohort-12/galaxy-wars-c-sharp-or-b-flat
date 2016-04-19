﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWars.Species;
using System.Reflection;
using System.Threading;

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

        string spaceship1 = @"    __";
        string spaceship2 = @"    \ \_____";
        string spaceship3 = @" ###[==_____>";
        string spaceship4 = @"    /_/";
        int spaces = 2;

        string[] spaceshipLines = { spaceship1, spaceship2, spaceship3, spaceship4 };

        while (spacePope.population > 0 && nasa.population > 0 && stormTroopers.population > 0)
        {
            Thread.Sleep(500);
            Console.Clear();

            // Move spaceship
            if (year % 4 == 0)
            { 
                for (int i = 0; i < 4; i++)
                { 
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j <= spaces; j++)
                    {
                        builder.Append(" ");
                    }
                    foreach (var c in spaceshipLines[i])
                    {
                        builder.Append(c);
                    }
                    spaceshipLines[i] = builder.ToString();
                    
                }
                    spaces += 2;
                }

            // Console Output
            Console.WriteLine("\n         G  A  L  A  X  Y      W  A  R  S");

            Console.WriteLine(spaceshipLines[0]);
            Console.WriteLine(spaceshipLines[1]);
            Console.WriteLine(spaceshipLines[2]);
            Console.WriteLine(spaceshipLines[3]);
            Console.WriteLine("");

            Console.WriteLine("It is year {0}.\n", year);
            Console.WriteLine("             Space Popes     NASA       Stormtroopers");
            Console.WriteLine("             -----------     ------     -------------");
            Console.WriteLine("Population:  {0}          {1}     {2}\n", spacePope.population, nasa.population, stormTroopers.population);
            

            if (year > 1) // if at least one year has passed, grant bonus pop to science type
            {
                foreach (AlienSpecies species in speciesList)
                {
                    if (species.affiliation == "Science")
                    {
                        species.population += 5000;
                    }
                }
            }
            if (year % 25 == 0)
            {
                Console.WriteLine("The rules of the universe are changing!");
                Random rnd = new Random(); // generate random number to choose random battle rule
                int randomInt = rnd.Next(0,3);

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
                foreach (AlienSpecies currDefender in speciesList) // let each species defend once against each attacker
                    {   
                        if (currAttacker.name != currDefender.name) // apply bonus attack from battle rules
                        {
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
                                }
                            }
                        }

                    if (currAttacker.affiliation == "Warrior" && currDefender.affiliation != "Warrior") // add warrior type bonus
                    {
                        currDefender.population -= 10000;
                    }
                    if (currAttacker.affiliation == "Religion" && currDefender.affiliation != "Religion")
                    {
                        double bonus = Math.Floor(currDefender.population * .01);
                        currAttacker.population += bonus; // religious attacker gains some population from defender
                        currDefender.population -= bonus; // defender loses population to religious attacker
                    }                
                }
            }

            // base population decline
            foreach (AlienSpecies species in speciesList)
            {
                species.population -= 20000;
                    if (species.population <= 0)
                    {
                        species.population = 0;
                        Console.Clear();
                        Console.WriteLine("\n         G  A  L  A  X  Y      W  A  R  S");
                        Console.WriteLine(spaceshipLines[0]);
			            Console.WriteLine(spaceshipLines[1]);
			            Console.WriteLine(spaceshipLines[2]);
			            Console.WriteLine(spaceshipLines[3]);
			            Console.WriteLine("");
                        Console.WriteLine("It is year {0}.\n", year);
                        Console.WriteLine("             Space Popes     NASA       Stormtroopers");
                        Console.WriteLine("             -----------     ------     -------------");
                        Console.WriteLine("Population:  {0}          {1}          {2}\n", spacePope.population, nasa.population, stormTroopers.population);
                        Console.WriteLine("***{0} is dead! GAME OVER***\n", species.name);
                    }
            }
            year++;  
      }
    }
  }
}
