using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Vehicles
{
  class GalacticChariot : Vehicle
  {
    public bool hasSpaceHorses = true;
    public bool isAerodynamic = false;
    public bool isCosmodynamic = true;

    public override void accelerate()
    {
      Console.WriteLine("The chariot is accelerating.");
    }

    public GalacticChariot()
    {
      name = "Galactic Chariot";
      allowedDriverAffiliation = "Religion";
    }
  }
}
