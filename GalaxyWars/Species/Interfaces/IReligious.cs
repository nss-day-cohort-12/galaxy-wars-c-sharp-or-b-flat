using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Species.Interfaces
{
  interface IReligious
  {
    int faithRating { get; set; }
    int autoHealRate { get; set; }
    string denomination { get; set; }
  }
}
