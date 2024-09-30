using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Scooter: Vehicle
    {
        private static string typeOfVehicle = "Scooter";
        public Scooter(string typeOfVehicle) : base(typeOfVehicle, "N/A") // in the field of plate none
        {
            
        }
        
    }
}
