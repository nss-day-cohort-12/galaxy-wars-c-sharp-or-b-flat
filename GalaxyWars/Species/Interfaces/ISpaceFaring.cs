using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyWars.Species.Interfaces
{
  interface ISpaceFaring
  {
    bool wearsLabCoat { get; set; }
    int iq { get; set; }
    string researchType { get; set; }
  }
}
