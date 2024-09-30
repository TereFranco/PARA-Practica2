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

        public PoliceCar(string plate,bool hasRadar) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            this.hasRadar = hasRadar;
            if (hasRadar)
            {
                speedRadar = new SpeedRadar();
            }
            else
            {
                speedRadar = null; 
            }
            station = new PoliceStation();  
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);
                    string meassurement = speedRadar.GetLastReading();
                    if (meassurement == "Catched above legal speed.") // if the vehicle is catched
                    {
                        station.alert = true; // notify the alarm
                        Console.WriteLine(WriteMessage($"Advised PoliceStation of illegal driving, car with plate {vehicle. GetPlate()}"));
                        this.station.DetectedInfractor(vehicle.GetPlate()); // chasing is managed in PoliceStation

                    }
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
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