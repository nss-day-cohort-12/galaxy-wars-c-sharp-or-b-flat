using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Vehicles
{
  class IntergalacticSubmarine : Vehicle
  {
    public bool operatesUnderwater = true;
    public bool hasPeriscope = true;
    public string windowShape = "round";

    public override void accelerate()
    {
      Console.WriteLine("The submarine is accelerating.");
    }

    public IntergalacticSubmarine()
    {
      name = "Intergalactic Submarine";
      allowedDriverAffiliation = "Warfare";
    }
  }
}
