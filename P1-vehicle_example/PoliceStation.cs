using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class PoliceStation
    {
        public List<PoliceCar> StationCars { get; private set; }
        public bool alert;

        public PoliceStation()
        {
            this.alert = false;
            StationCars = new List<PoliceCar>();
        }
        // Register a police car
        public void RegisterPoliceCar(string plate) 
        { 
            StationCars.Add(new PoliceCar(plate));
        }
        // If alarm is activated all police chases car
        public void DetectedInfractor(string plate) 
        {
            this.alert = true;
            foreach (PoliceCar car in StationCars) 
            {
                if (car.IsPatrolling())
                {
                    car.chasing = true;
                    
                }
            }

        }
    }
}
