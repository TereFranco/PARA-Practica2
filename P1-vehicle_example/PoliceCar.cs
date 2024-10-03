using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;

namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar; // if a question mark is added it can be made null
        public bool chasing;
        private PoliceStation station;
        private bool hasRadar;

        public PoliceCar(string plate,bool hasRadar,PoliceStation myStation) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            this.hasRadar = hasRadar;
            this.station = myStation;
            if (hasRadar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null; 
            }
              
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    bool catched = meassurement.EndsWith("Catched above legal speed.");
                    
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                    if (catched) 
                    {
                        string plate = speedRadar.GetPlateLastReading();
                        ActivateAlert(plate);
                    }   
                }
                else 
                {
                    Console.WriteLine(WriteMessage($"This PoliceCar hasn't got radar"));
                }
               
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

      
        public void ActivateAlert(string plate)
        {
            this.station.StartChase(plate);
        }

        public void ChaseCar(bool chase) // send him to stop or to start
        {
            this.chasing = chase;

        }
        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            if (speedRadar!= null)
            {
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }

            }
            
        }
    }
}