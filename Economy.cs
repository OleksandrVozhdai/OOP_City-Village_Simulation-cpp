using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OOP_LAB4
{
    internal class Economy
    {
        private static Random randPopulation = new Random();
        private static Random randomIndustry = new Random();
        private static Random randomcosts = new Random();
        private static int day = 1;
        private static int year = 2024;
        private static int monthnumber = 11;
        private static string[] months = { "January", "February", "March", "April", "May", "June",
                                           "July", "August", "September", "October", "November", "December" };

   
        private static System.Timers.Timer aTimer;
        private static Village village;
        private static City city;

        public static void InitializeVillage(Village v, City c)
        {
            village = v;
            city = c;
            SetTimerVillage();
        }

        public static void InitializeCity(Village v, City c)
        {
            village = v;
            city = c;
            SetTimerCity();
        }

        private static void SetTimerVillage()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEventVillage;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void SetTimerCity()
        {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEventCity;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEventVillage(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            
         
            Console.WriteLine("\n\n");
            if (day < 30)
            {
                day++;
            }
            else
            {
                day = 1;
                monthnumber++;
            }

            if (monthnumber == 12)
            {
                monthnumber = 0;
                year++;
            }

            int PopulationChanged = randPopulation.Next(-3, 6);
            int IndustryChanged = randomIndustry.Next(1, 6);

            Console.Write($"{day} {months[monthnumber]} of year: {year}\n");

            village.population += PopulationChanged;
            village.OutputData(PopulationChanged);

            switch (IndustryChanged)
            {
                case 1:
                    if (village.budget >= 3 && village.farms < 3)
                    {
                        village.budget -= 3;
                        village.farms++;
                        village.AddIndustry("Animal farm");
                      
                        Console.WriteLine("\nThe village built an animal farm... (-3 g)       ");
                    }
                    else
                    {
                        Console.WriteLine("\nThe village did not build anything...          ");
                    }
                    break;
                case 2:
                    if (village.budget >= 2 && village.fields < 3)
                    {
                        village.budget -= 2;
                        village.fields++;
                     
                        village.AddIndustry("Fields");
                        Console.WriteLine("\nThe village built a field... (-2 g)       ");
                    }
                    else
                    {
                        Console.WriteLine("\nThe village did not build anything...      ");
                    }
                    break;
                case 3:
                    if (village.budget >= 1 && village.fish < 3)
                    {
                        village.fish++;
                        village.budget -= 1;
                     
                        village.AddIndustry("Fishing");
                        Console.WriteLine("\nThe village built a fishing camp... (-1 g)        ");
                    }
                    else
                    {
                        Console.WriteLine("\nThe village did not build anything...      ");
                    }
                    break;
                case 4:
                    int RandomCosts = randomcosts.Next(1, 11);
                    Console.WriteLine($"\nRepair works (-{RandomCosts} g)");
                    village.budget -= RandomCosts;
                    break;
                case 5:
                    if (village.budget >= 90 && village.shop == 0)
                    {
                        village.shop++;
                      
                        village.budget -= 90;
                        village.AddIndustry("Shop");
                        Console.WriteLine("\nThe village built a shop... (-90 g)        ");
                    }
                    break;
            }
            village.budget = village.CalculateCoof(village.budget) + (village.CalculateTaxes(village.taxes,
                village.population, village.oldPoeopleCoof) / 2) - village.SpendingMoneyEachDay(village.spending);

            Console.WriteLine($"\nTaxes: {village.CalculateTaxes(village.taxes, village.population, village.oldPoeopleCoof) / 2:F2}" +
                              $"\nvillage expenses: {village.SpendingMoneyEachDay(village.spending):F2}" +
                              $"\n\nAnimal Farms: {village.farms}/3 (+ {village.farms * 0.4:F2} g)" +
                              $"\nFields: {village.fields}/3 (+ {village.fields * 0.3:F2} g)" +
                              $"\nFishing camp: {village.fish}/3 (+ {village.fish * 0.2:F2} g)" +
                              $"\nShop: {village.shop}/1 (+ 5 g)");
        }

        private static void OnTimedEventCity(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            if (day < 30)
            {
                day++;
            }
            else
            {
                day = 1;
                monthnumber++;
            }

            if (monthnumber == 12)
            {
                monthnumber = 0;
                year++;
            }

            int PopulationChanged = randPopulation.Next(-50, 301);
            int IndustryChanged = randomIndustry.Next(1, 8);

            Console.Write($"{day} {months[monthnumber]} of year: {year}\n");
            city.population += PopulationChanged;
            city.OutputData(PopulationChanged);

            switch (IndustryChanged)
            {
                case 1:
                    if (city.budget >= 90 && city.Shop < 10)
                    {
                        city.Shop++;
                        city.budget -= 90;
                        city.AddIndustry("Shop");
                        Console.WriteLine("\nThe city built a shop... (-90 g)        ");
                    }
                    else
                    {
                        Console.WriteLine("\nThe city did not build anything...      ");
                    }
                    break;
                case 2:
                    if (city.budget >= 120 && city.Factories < 5)
                    {
                        city.Factories++;
                        city.budget -= 120;
                        city.AddIndustry("Factories");
                        Console.WriteLine("\nThe city built a factory... (-120 g)        ");
                    }
                    else
                    {
                        Console.WriteLine("\nThe city did not build anything...      ");
                    }
                    break;
                case 3:
                    if (city.budget >= 150 && city.GasStation < 4)
                    {
                        city.GasStation++;
                        city.budget -= 150;
                        city.AddIndustry("GasStation");
                        Console.WriteLine("\nThe city built a gas station... (-150 g)        ");
                    }
                    else
                    {
                        Console.WriteLine("\nThe city did not build anything...      ");
                    }
                    break;
                case 4:
                    if (city.budget >= 400 && city.PowerStation < 1)
                    { 
                        city.PowerStation++;
                        city.budget -= 400;
                        city.AddIndustry("Power stations");
                        Console.WriteLine("\nThe city built a power station... (-400 g)");
                    }
                    else
                    {
                        Console.WriteLine("\nThe city did not build anything...      ");
                    }
                    break;
                case 5:
                    if (city.budget >= 350 && city.Pharmaceutical < 2)
                    { 
                        city.Pharmaceutical++;
                        city.budget -= 350;
                        city.AddIndustry("Pharmaceutical companies");
                        Console.WriteLine("\nThe city built a pharmaceutical company... (-350 g)");
                    }
                    else
                    {
                        Console.WriteLine("\nThe city did not build anything...      ");
                    }
                    break;
                case 6:
                    if (city.budget >= 300 && city.ItCompanies < 4)
                    {
                        city.ItCompanies++;
                        city.budget -= 300;
                        city.AddIndustry("IT companies");
                        Console.WriteLine("\nThe city built an IT company... (-300 g)");
                    }
                    else
                    {
                        Console.WriteLine("\nThe city did not build anything...      ");
                    }
                    break;
                case 7:
                    int RandomCosts = randomcosts.Next(50, 300);
                    Console.WriteLine($"\nRepair works (-{RandomCosts} g)");
                    city.budget -= RandomCosts;
                    break;

            }

            city.budget = city.CalculateCoof(city.budget) + (city.CalculateTaxes(city.taxes,
                city.population, city.oldPoeopleCoof) / 2) - city.SpendingMoneyEachDay(city.spending);

            Console.WriteLine($"\nTaxes: {city.CalculateTaxes(city.taxes, city.population, city.oldPoeopleCoof) / 2:F2}" +
                              $"\ncity expenses: {city.SpendingMoneyEachDay(city.spending):F2}" +
                              $"\n\nShops: {city.Shop}/10 (+ {city.Shop * 5:F2} g)" +
                              $"\nFactories: {city.Factories}/5 (+ {city.Factories * 10:F2} g)" +
                              $"\nGas station: {city.GasStation}/4 (+ {city.GasStation * 15:F2} g)" +
                              $"\nPharmaceutical companies: {city.Pharmaceutical}/2 (+ {city.Pharmaceutical * 50:F2} g)" +
                              $"\nPower stations: {city.PowerStation}/1 (+ {city.PowerStation * 40:F2} g)" +
                              $"\nIT companies: {city.ItCompanies}/4 (+ {city.ItCompanies * 50:F2}  g)");

            
        }
      
    }
}
