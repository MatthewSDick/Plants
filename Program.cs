using System;

namespace Plants
{
  class Program
  {
    static void Main(string[] args)
    {

      static int verifyNumber(string toCheck)
      {

        int returnNumber;
        while (!Int32.TryParse(toCheck, out returnNumber))
        {
          Console.WriteLine("Please enter a number.");
          toCheck = Console.ReadLine().ToLower();
        }
        return returnNumber;
      }

      var plantDatabase = new PlantDatabaseContext();

      Console.Clear();
      Console.WriteLine("Welcome to Party Thyme.");

      var isRunning = true;

      while (isRunning)
      {
        Console.WriteLine();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine(" (View) - View the current plants by location.");
        Console.WriteLine(" (Plant) - Plant a new plant.");
        Console.WriteLine(" (Remove) - Remove a plant.");
        Console.WriteLine(" (Water) - Water a plant.");
        Console.WriteLine(" (Need) - Plants that need watered.");
        Console.WriteLine(" (Thirsty) - View plants that have not been watered today.");
        Console.WriteLine(" (Location) - List plants by location.");
        Console.WriteLine(" (Quit) - Quit the application.");
        var selectedAction = Console.ReadLine().ToLower();

        switch (selectedAction)
        {
          case "view":
            plantDatabase.ViewPlants();
            break;

          case "plant":
            // Plant a new plant
            //    This command will let the user type in the information for a plant and add it to the list
            Console.Clear();
            Console.Write("Why is the species of the plant you want to add? ");
            var newSpecies = Console.ReadLine().ToLower();
            Console.Write("Where are you planting said plant? ");
            var newLocation = Console.ReadLine().ToLower();
            Console.Write("WHow many hours of light does the plant need? ");
            var sunLight = Console.ReadLine().ToLower();
            int newSunlight = verifyNumber(sunLight);
            Console.Write("How much water is needed? ");
            var water = Console.ReadLine().ToLower();
            int newWater = verifyNumber(water);
            plantDatabase.AddPlant(newSpecies, newLocation, newSunlight, newWater);
            break;

          case "remove":
            // Remove a plant
            //    This will delete a plant by Id
            Console.Clear();
            Console.Write("Here is a list of your plants.");
            plantDatabase.ViewPlants();
            Console.Write("Tell me the number of the plant you want to remove. ");
            var removalPlant = Console.ReadLine().ToLower();
            int removePlant = verifyNumber(removalPlant);
            plantDatabase.RemovePlant(removePlant);
            break;

          case "water":
            Console.Clear();
            plantDatabase.ViewPlants();
            Console.Write("Tell me the number of the plant you want to water. ");
            var waterPlant = Console.ReadLine().ToLower();
            int plantToWater = verifyNumber(waterPlant);
            plantDatabase.WaterPlant(plantToWater);

            // Water
            //    This will update the plant's LastWateredDate to the Current Time. The user will select the plant by Id
            break;

          case "need":
            plantDatabase.NeedWater();

            // Water
            //    This will update the plant's LastWateredDate to the Current Time. The user will select the plant by Id
            break;

          case "thirsty":
            // View all the plants that have not been watered today
            plantDatabase.ThirstyPlants();
            break;

          case "location":
            Console.WriteLine("Here are the garden locations");
            plantDatabase.GetLocations();
            Console.WriteLine("Please type the location you would like to view.");
            var theLocation = Console.ReadLine().ToLower();
            plantDatabase.ShowByLocation(theLocation);
            // Show Locations
            // Choose location

            // Location summary
            //    This will show all the plants that are in given location
            break;

          case "quit":
            isRunning = false;
            break;
        }





      }




    }
  }
}
