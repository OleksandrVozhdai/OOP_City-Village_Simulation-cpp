using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB4
{
    interface ILocation
    {
        int size { get; }
        string settlementlocation { get; }
        int geopopulation { get; }

        public void output()
        {
            Console.WriteLine($"\nLocation:\nSize: {size}\nGeopopulation: {geopopulation}\n Settlement location: {settlementlocation}");
        }

    }

    abstract class Location : ILocation
    {
        private string SettlementLocation;
        private int GeoPopulation, Size;

        public string Name { get; set; }
        public string GeoFeatures { get; set; }
        public int Population { get; set; }
        public int CitySize { get; set; }
        


        public Location()
        {
            Size = 0;
            GeoPopulation = 60000;
            SettlementLocation = string.Empty;
        }

        public Location(string name, string geofeatures, int population)
        {
           Name = name;
           GeoFeatures = geofeatures;
           Population = population;
        }

        public int size
        {
            get { return Size; }
            set { Size = value; }
        }
        public int geopopulation
        {
            get { return GeoPopulation; }
            set { GeoPopulation = value; } 
        }
        public string settlementlocation
        {
            get { return SettlementLocation; }
            set { SettlementLocation = value; }
        }
    }
}
