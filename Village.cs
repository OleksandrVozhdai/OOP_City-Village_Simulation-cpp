using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB4
{
    internal class Village : Location
    {
        private float Budget = 0f, OldPeopleCoof, KidsPeopleCoof;
        private string[] Industry;
        public int farms = 0, fields = 0, fish = 0, shop = 0;
        public float taxes = 0f;
        public float spending;

        public Village(string name, float budget, string geofeatures)
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
        public string geoFeatures
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

        public void OutputData(int PopulationIncrease)
        {
            Console.WriteLine($"\nVillage:\nName: {Name}\nBudget: {Budget:F2} g\nGeographic features: {GeoFeatures}" +
                $"\nPopulation {Population} ({PopulationIncrease})\nOld People Coof {OldPeopleCoof * 10}%\nKids Coof: {KidsPeopleCoof}%");
        }

        public float OldPeopleCoofGeneration()
        {
            Random rand = new Random();
            float coof = rand.Next(2, 5);
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
                        case "Animal farm":
                            coof += 0.4f;
                            break;
                        case "Fields":
                            coof += 0.3f;
                            break;
                        case "Fishing":
                            coof += 0.2f;
                            break;
                        case "Shop":
                            coof += 5f;
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
            spending += (Population * 0.001f) + farms * 0.05f + fish * 0.05f + fields * 0.05f;

            return spending;
        }

       

    }
}
