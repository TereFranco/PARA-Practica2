﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Scooter: VehicleWithoutPlate
    {
        private static string typeOfVehicle = "Scooter";
        public Scooter() : base(typeOfVehicle) 
        {
            
        }
        
    }
}
