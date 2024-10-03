using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class PoliceStation : IMessageWritter
    {
        public List<PoliceCar> StationCars { get; private set; }
        public bool alert;

        public PoliceStation()
        {
            this.alert = false;
            StationCars = new List<PoliceCar>();
        }
        // Register a police car
        public void RegisterPoliceCar(PoliceCar police) 
        { 
            StationCars.Add(police);
        }

        // If alarm is activated all police chases car
        public void StartChase(string plate) 
        {
            this.alert = true;
            Console.WriteLine(WriteMessage(plate));
            foreach (PoliceCar car in StationCars) 
            {
                if (car.IsPatrolling())
                {
                    car.ChaseCar(true);
                    
                }
            }

        }
        
        public void StopChase(string plate) 
        {
            this.alert = false;
            Console.WriteLine(WriteMessage(plate));
            foreach (PoliceCar car in StationCars)
            {
                if (car.IsPatrolling())
                {
                    car.ChaseCar(false);

                }
            }
        }

        // implement interface
        public virtual string WriteMessage(string plate)
        {
            string message = "";
            if (this.alert)
            {
                 message = "start";
            }
            else
            {
                 message = "stop";
            }
            return $"All PoliceCars patrolling {message} chasing vehicle with plate {plate}";
        }

    }
}
