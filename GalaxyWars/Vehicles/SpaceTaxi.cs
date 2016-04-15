using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Vehicles
{
  class SpaceTaxi : Vehicle
  {
    public bool canBeDriven = false;
    public bool requiresFare = true;

    public SpaceTaxi()
    {
      name = "Space Taxi";
      allowedDriverAffiliation = null;
    }
  }
}
