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

        public City()
        {
            station = new PoliceStation();
            TaxisCity = new List<Taxi>();
        }

        private void AddTaxiPlate(string plate) 
        { 
            TaxisCity.Add(new Taxi(plate));
        }
        private void RetireTaxiPlate(string plate) // estoy modificando la lista a la vez
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
