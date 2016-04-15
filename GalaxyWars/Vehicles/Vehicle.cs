using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Vehicles
{
  class Vehicle
  {
    public string name { get; set; }
    public string allowedDriverAffiliation { get; set; } // which allegiance can drive a given vehicle
    public int speed { get; set; }
    public string color { get; set; }
    private double _acceleration = 0;
    public double acceleration {
      get
      {
        return _acceleration;
      }
      set
      {
        if (value > 0)
        {
          _acceleration = value;
        }
      }
    }

    public virtual void accelerate()
    {
      acceleration = 5;
      Console.WriteLine("The vehicle's acceleration is at {0}", acceleration);
    }
  }
}

