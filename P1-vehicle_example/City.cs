using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class City: IMessageWritter
    {
        private List<Taxi> TaxisCity { get; set; }
        public PoliceStation station;
        public string cityName;
        public City(string name)
        {
            
            station = new PoliceStation();
            TaxisCity = new List<Taxi>();
            cityName = name;
        }

        public void AddTaxiPlate(Taxi taxi) 
        { 
            TaxisCity.Add(taxi);
        }
        public void RetireTaxiPlate(string plate) // With a foreach I modify the list at the same time
            // therefore using a basic for is needed to select first the  taxi and then remove
        {
            for(int i = 0; i < TaxisCity.Count; i++)
            {
                Taxi taxi = TaxisCity[i];
                if (taxi.GetPlate() == plate) 
                {
                    
                    TaxisCity.Remove(taxi);
                }

            } 
            station.StopChase(plate); // stop chasing if it has been removed
        }
        // implement interface
        public virtual string WriteMessage(string name)
        {
            return $"City {name} and station created.";
        }
    }
}
