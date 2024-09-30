namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            // have to add messages to all creations
            PoliceStation station = new PoliceStation(); 
            City city = new City(station); // because city has a station, if created only inside city..
                                           // I have to access to city to call station methods
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            Taxi taxi3 = new Taxi("0003 CCC");
            city.AddTaxiPlate(taxi1.GetPlate());
            city.AddTaxiPlate(taxi2.GetPlate());
            city.AddTaxiPlate(taxi3.GetPlate());
            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(taxi3.WriteMessage("Created"));
            

            PoliceCar policeCar1 = new PoliceCar("0001 CNP",true);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP",true);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP",false);
            PoliceCar policeCar4 = new PoliceCar("0004 CNP", true);
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
    

