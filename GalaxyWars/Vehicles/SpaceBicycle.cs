using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Vehicles
{
  class SpaceBicycle : Vehicle
  {
    public int numberOfWheels = 2;

    public override void accelerate()
    {
      acceleration += 2;
      Console.WriteLine("The bicycle is accelerating at a rate of {0}.", acceleration);
    }

    public SpaceBicycle()
    {
      name = "Space Bicycle";
      allowedDriverAffiliation = "Science";
    }
  }
}
