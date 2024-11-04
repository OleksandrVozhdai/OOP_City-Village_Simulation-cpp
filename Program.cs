using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Timers;
using static OOP_LAB4.City;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_LAB4
{
    class Program
    {
        static void Main(string[] args)
        {
            Village village = new Village("Village1", 10f, "Warm");

            City[] cities = new City[3];
            cities[0] = new City("Town1", 1000f, "Cold");
            cities[1] = new City("Town2", 940f, "Warm");
            cities[2] = new City("Town3", 1300f, "Warm");

            village.population = (village.geopopulation / 100) * 10;

            Random randPopul = new Random();
            Random randSize = new Random();

            for (int i = 0; i < cities.Length; i++)
            {
                int randPopulChange = randPopul.Next(-16000, 50000);
                int randomSize = randSize.Next(10000, 50000);
                cities[i].population = ((cities[i].geopopulation / 100) * 90) + randPopulChange + (randomSize / 2);
                cities[i].size = randomSize;
            }
            Console.WriteLine("Choose what to follow \n1. Village\n2. City\n-----------------------------\n3. Compare the cities");
            Console.WriteLine("             ____" +
                            "\n ____     * |    |" +
                            "\n|    |_   | |    |" +
                            "\n|    | |__|_|    |" +
                            "\n|    | |    |    |" +
                            "\n|    | |    |    |" +
                            "\nTTTTTTTTTTTTTTTTTT" +
                            "\n||||||||||||||||||" +
                            "\n------------------" +
                            "\n - - - - - - - - -" +
                            "\n------------------");
            int choose = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (choose)
            {
                case 1:
                    village.oldPoeopleCoof = village.OldPeopleCoofGeneration();
                    village.kidsPeopleCoof = village.KidsPepoleCoofGeneration();
                    Economy.InitializeVillage(village, cities[0]);
                    break;
                case 2:
                    Console.WriteLine($"What city do you want to simulate?\n");

                    for (int i = 0; i < cities.Length; i++)
                    {
                        Console.WriteLine($"{i+1}. {cities[i].Name} with population {cities[i].population} and size of {cities[i].size} km^2\n");
                    }

                    int ChooseCity = Convert.ToInt32(Console.ReadLine()) - 1;

                    cities[ChooseCity].oldPoeopleCoof = cities[ChooseCity].OldPeopleCoofGeneration();
                    cities[ChooseCity].kidsPeopleCoof = cities[ChooseCity].KidsPepoleCoofGeneration();
                    Economy.InitializeCity(village, cities[ChooseCity]);
                    break;
                case 3:
                    int comparisonResult;
                    for (int i = 0; i < cities.Length - 1; i++)
                    {
                        comparisonResult = cities[i].CompareTo(cities[i+1]);

                        if (comparisonResult < 0)
                        {
                            Console.WriteLine($"City {cities[i].Name} ({cities[i].size} km^2) is smaller than City {cities[i+1].Name}  ({cities[i+1].size} km^2)");
                        }
                        else if (comparisonResult > 0)
                        {
                            Console.WriteLine($"City {cities[i].Name} ({cities[i].size} km^2) is larger than City {cities[i+1].Name}  ({cities[i+1].size} km^2)");
                        }
                        else
                        {
                            Console.WriteLine($"City {cities[i].Name} ({cities[i].size} km^2) and City {cities[i+1].Name}  ({cities[i+1].size} km^2) are of the same size");
                        }
                    }

                    Console.WriteLine("---------------------------------------------------------------------------");

                    for (int i = 0; i < cities.Length - 1; i++) 
                    {
                        PopulationComparer comparer = new PopulationComparer();
                        int comparisonResultTwo = comparer.Compare(cities[i], cities[i + 1]); 

                        if (comparisonResultTwo < 0)
                        {
                            Console.WriteLine($"City {cities[i].Name} ({cities[i].Population} people) is smaller than City {cities[i + 1].Name} ({cities[i + 1].Population} people)");
                        }
                        else if (comparisonResultTwo > 0)
                        {
                            Console.WriteLine($"City {cities[i].Name} ({cities[i].Population} people) is larger than City {cities[i + 1].Name} ({cities[i + 1].Population} people)");
                        }
                        else
                        {
                            Console.WriteLine($"City {cities[i].Name} ({cities[i].Population} people) and City {cities[i + 1].Name} ({cities[i + 1].Population} people) have the same population");
                        }
                    }

                    CityListOutput citylistoutput = new CityListOutput(cities);

                    Console.WriteLine("---------------------------------------------------------------------------");

                    foreach (City city in citylistoutput)
                    {
                        Console.WriteLine($"City: {city.Name}, Population: {city.Population}");
                    }
                    break;
            }

            Console.ReadLine();
        }
    }
}
