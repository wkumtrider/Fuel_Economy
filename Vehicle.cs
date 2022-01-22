using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelEconomy
{
    public class VehicleData
    {
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
        public int VehicleFuelEconomyCity { get; set; }
        public int VehicleFuelEconomyHW { get; set; }
        public int VehicleFuelEconomyCombined { get; set; }

    }
}