using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyWars.Species.Interfaces;

namespace GalaxyWars.Species
{
  class NASA : Species, ISpaceFaring
  {
    public bool wearsLabCoat { get; set; }
    public int iq { get; set; }
    public string researchType { get; set; }

    public string averageBloodPressure { get; set; }
    public bool receivesGovFunding { get; set; }

    public NASA()
    {
      population = 1000000;
      allowedVehicle = "Space Bicycle";
      affiliation = "Science";
    }

    public NASA(string planet)
    {
      homePlanet = planet;
      population = 1000000;
      allowedVehicle = "Space Bicycle";
      affiliation = "Science";
    }
  }
}
