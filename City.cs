using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB4
{
    internal class City: Location, IComparable
    {  
        private float Budget;

        private float OldPeopleCoof, KidsPeopleCoof;
        private string[] Industry;
        public float taxes = 0f;
        public float spending;

        internal enum CitySizeDeter
        {
            Small,
            Medium,
            Large
        }

        public int Factories = 0 , Shop = 0, GasStation = 0, PowerStation = 0, Pharmaceutical = 0, ItCompanies = 0; 


        public City(string name, float budget, string geofeatures)
        {
            Name = name;
            Budget = budget;
            GeoFeatures = geofeatures;
         
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public float budget
        {
            get { return Budget; }
            set { Budget = value; }
        }
        public string geofeatures
        {
            get { return GeoFeatures; }
            set { GeoFeatures = value; }
        }
        public int population
        {
            get { return Population; }
            set { Population = value; }
        }
        public float oldPoeopleCoof
        {
            get { return OldPeopleCoof; }
            set { OldPeopleCoof = value; }
        }
        public float kidsPeopleCoof
        {
            get { return KidsPeopleCoof; }
            set { KidsPeopleCoof = value; }
        }
        public int size
        {
            get { return CitySize; }
            set { CitySize = value; }
        }

        public void OutputData(int PopulationIncrease)
        {
            Console.WriteLine($"\nCity:\nName: {Name}\nBudget: {Budget:F2} g\nGeographic features: {GeoFeatures}" +
                $"\nPopulation {Population} ({PopulationIncrease})\nOld People Coof {OldPeopleCoof * 10}%\nKids Coof: {KidsPeopleCoof}%");
        }

        public float OldPeopleCoofGeneration()
        {
            Random rand = new Random();
            float coof = rand.Next(1, 4);
            coof /= 10;
            return coof;
        }
        public float KidsPepoleCoofGeneration()
        {
            Random rand = new Random();
            float coof = rand.Next(5, 10);
            return coof;
        }
        public void AddIndustry(string newIndustry)
        {
            if (Industry == null)
            {
                Industry = new string[1];
                Industry[0] = newIndustry;
            }
            else
            {
                Array.Resize(ref Industry, Industry.Length + 1);
                Industry[Industry.Length - 1] = newIndustry;
               
            }
        }

        public float CalculateCoof(float coof)
        {
            if (Industry != null)
            {
                foreach (string industry in Industry)
                {
                    switch (industry)
                    {
                        case "Factories": //5
                            coof += 10f;
                            break;
                        case "Shops": //10
                            coof += 5f;
                            break;
                        case "Gas stations": // 4
                            coof += 15f;
                            break;
                        case "Power stations": // 1
                            coof += 40f;
                            break;
                        case "Pharmaceutical companies": // 2
                            coof += 50;
                            break;
                        case "IT companies": // 4
                            coof += 50;
                            break;
                    }
                }
            }
            return coof;
        }
        public float CalculateTaxes(float taxes, int population, float oldpeoplecoof)
        {
            taxes += population * 0.004f;
            taxes -= oldpeoplecoof * 10;
            taxes -= kidsPeopleCoof * 0.5f;

            return taxes;
        }

        public float SpendingMoneyEachDay(float spending)
        {
            spending += (Population * 0.001f) + Factories * 0.05f + Shop * 0.05f + GasStation * 0.05f + PowerStation + 0.05f +
                Pharmaceutical * 0.05f + ItCompanies * 0.05f;

            return spending;
        }

        public CitySizeDeter DetermineSize()
        {
            if (size < 20000)
            {
                return CitySizeDeter.Small;
            }
            else if (size < 40000)
            {
                return CitySizeDeter.Medium;
            }
            else
            {
                return CitySizeDeter.Large;
            }
        }

       

        public int CompareTo(object obj)
        {
            if (obj == null) return 1; 

            if (!(obj is City otherCity))
            {
                throw new ArgumentException("Object is not a City");
            }

            return DetermineSize().CompareTo(otherCity.DetermineSize());
        }
        internal class PopulationComparer : IComparer
        {
            public int Compare(Object x, Object y)
            {
                if (x == null || y == null)
                    throw new ArgumentException("Both objects must be non-null.");

                if (!(x is City) || !(y is City))
                    throw new ArgumentException("Objects must be of type City.");

                City cityX = (City)x;
                City cityY = (City)y;

                return cityX.Population.CompareTo(cityY.Population);
            }
        }

        internal class CityListOutput : IEnumerable
        {
            private City[] _cities;

            public CityListOutput(City[] cArray)
            {
                _cities = new City[cArray.Length];

                for (int i = 0; i < cArray.Length; i++)
                {
                    _cities[i] = cArray[i];
                }

                _cities = _cities.OrderBy(city => city.Population).ToArray();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public CityListOutputEnum GetEnumerator()
            {
                return new CityListOutputEnum(_cities);
            }
        }

        public class CityListOutputEnum : IEnumerator
        {
            public City[] _cities;
            int position = -1;

            public CityListOutputEnum(City[] list)
            {
                _cities = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _cities.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public City Current
            {
                get
                {
                    try
                    {
                        return _cities[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

    }
}
