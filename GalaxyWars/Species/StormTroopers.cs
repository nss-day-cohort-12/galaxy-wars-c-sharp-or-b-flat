using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWars.Species.Interfaces;

namespace GalaxyWars.Species
{
  class StormTroopers : Species, IWarrior
  {
    public int strength { get; set; }
    public int armorRating { get; set; }
    public string weapon { get; set; }

    public string averageWeight { get; set; }
    public bool hasWhiteUniform { get; set; }

    public StormTroopers()
    {
      population = 1000000;
      allowedVehicle = "Intergalactic Submarine";
      affiliation = "Warrior";
    }

    public StormTroopers(string planet)
    {
      homePlanet = planet;
      population = 1000000;
      allowedVehicle = "Intergalactic Submarine";
      affiliation = "Warrior";
    }
  }
}
