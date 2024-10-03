namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            // have to add messages to all creations
            City city = new City("Madrid"); //created only inside city..
                                            // I have to access to city to call station methods
            PoliceStation station = city.station;
            Console.WriteLine(city.WriteMessage(city.cityName));
            

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            Taxi taxi3 = new Taxi("0003 CCC");
            city.AddTaxiPlate(taxi1);
            city.AddTaxiPlate(taxi2);
            city.AddTaxiPlate(taxi3);
            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(taxi3.WriteMessage("Created"));
            

            PoliceCar policeCar1 = new PoliceCar("0001 CNP",true,station);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP",true ,station);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP",false,station);
            PoliceCar policeCar4 = new PoliceCar("0004 CNP", true,station);
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));
            Console.WriteLine(policeCar3.WriteMessage("Created"));
            Console.WriteLine(policeCar4.WriteMessage("Created"));

            // Trial of using radar when hasn't got.
            policeCar3.StartPatrolling();
            policeCar3.UseRadar(taxi1);

            // Alerting the PoliceStation because one car found speeding
            taxi2.StartRide();
            policeCar2.StartPatrolling(); 
            policeCar2.UseRadar(taxi2); //here the sation should be advised and the message seen of advising 
            taxi2.StopRide();
            city.RetireTaxiPlate(taxi2.GetPlate());

        }
    }
}
    

