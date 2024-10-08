﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    abstract class VehicleWithoutPlate : IMessageWritter // we need another more abstract class vehicle to respect SOLID

    {
        private string typeOfVehicle;
        private float speed;

        public VehicleWithoutPlate(string typeOfVehicle)
        {
            this.typeOfVehicle = typeOfVehicle;
            speed = 0f;
        }

        //Override ToString() method with class information
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()}";
        }

        public string GetTypeOfVehicle()
        {
            return typeOfVehicle;
        }

        
        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        //Implment interface with Vechicle message structure
        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
