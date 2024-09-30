using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class City 
    {
        private List<Taxi> TaxisCity { get; set; }
        private PoliceStation station;

        public City(PoliceStation station)
        {
            
            this.station = station;
            TaxisCity = new List<Taxi>();
        }

        public void AddTaxiPlate(Taxi taxi) 
        { 
            TaxisCity.Add(taxi);
        }
        public void RetireTaxiPlate(string plate) // estoy modificando la lista a la vez
        {
            foreach (Taxi taxi in TaxisCity) 
            {
                if (taxi.GetPlate() == plate) 
                {
                    TaxisCity.Remove(taxi);
                }

            }   
        }
    }
}
