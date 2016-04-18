using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWars.Species.Interfaces;

namespace GalaxyWars.Species
{
  class StormTroopers : AlienSpecies, IWarrior
  {
    public int strength { get; set; }
    public int armorRating { get; set; }
    public string weapon { get; set; }

    public string averageWeight { get; set; }
    public bool hasWhiteUniform { get; set; }

    public StormTroopers()
    {
      name = "Storm Troopers";
      population = 1000000;
      allowedVehicle = "Intergalactic Submarine";
      affiliation = "Warrior";
    }

    public StormTroopers(string planet)
    {
      name = "Space Pope";
      homePlanet = planet;
      population = 1000000;
      allowedVehicle = "Intergalactic Submarine";
      affiliation = "Warrior";
    }
  }
}
