using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Species.Interfaces
{
  interface IWarrior
  {
    int strength { get; set; }
    int armorRating { get; set; }
    string weapon { get; set; }
  }
}
