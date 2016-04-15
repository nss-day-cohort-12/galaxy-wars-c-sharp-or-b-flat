using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWars.Species.Interfaces;

namespace GalaxyWars.Species
{
  class SpacePope : Species, IReligious
  {
    public int faithRating { get; set; }
    public int autoHealRate { get; set; }
    public string denomination { get; set; }

    public string averageHeight { get; set; }
    public bool hasTallHats { get; set; }

    public SpacePope()
    {
      population = 1000000;
      allowedVehicle = "Galactic Chariot";
      affiliation = "Religion";
    }

    public SpacePope(string planet)
    {
      homePlanet = planet;
      population = 1000000;
      allowedVehicle = "Galactic Chariot";
      affiliation = "Religion";
    }
  }
}
