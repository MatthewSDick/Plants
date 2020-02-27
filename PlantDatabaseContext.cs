using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Plants
{
  public partial class PlantDatabaseContext : DbContext
  {

    public DbSet<Plant> Plants { get; set; }
    public DbSet<Garden> Gardens { get; set; }

    public void ViewPlants()
    {
      var orderedPlantLocation = Plants.OrderBy(p => p.LocatedPlanted);
      Console.Clear();
      Console.WriteLine($"You currently have the following plants.");
      foreach (var plant in orderedPlantLocation)
      {
        Console.WriteLine($"Plant number {plant.Id} is {plant.Species} located in the {plant.LocatedPlanted} garden.");
      }
      // View All the current plants
      //    this command will show the all the plants in a the list, ordered by LocationPlanted
    }
    public void AddPlant(string newSpecies, string newLocation, int newSunlight, int newWater)
    {
      // Plant a new plant
      //    This command will let the user type in the information for a plant and add it to the list
      Plants.Add(new Plant { Species = newSpecies, LocatedPlanted = newLocation, LightNeeded = newSunlight, WaterNeeded = newWater });
      SaveChanges();
      Console.WriteLine($"Your {newSpecies} were planted in the {newLocation} garden.");
    }
    public void RemovePlant(int id)
    {
      var plantForRemoval = Plants.FirstOrDefault(p => p.Id == id);
      //var removalName = Plants.Find(p => )
      Plants.Remove(plantForRemoval);
      SaveChanges();
      Console.WriteLine($"I removed the {plantForRemoval.Species} and gave it to the groundhog to eat.");
    }
    public void WaterPlant(int id)
    {
      // Water
      //    This will update the plant's LastWateredDate to the Current Time. The user will select the plant by Id
      var plantToWater = Plants.FirstOrDefault(p => p.Id == id);
      plantToWater.LastWateredDate = DateTime.Now;
      SaveChanges();
      Console.WriteLine($"I watered the {plantToWater.Species}. It is no longer thirsty.");
    }
    public void ThirstyPlants()
    {
      Console.Clear();
      var notWateredToday = Plants.Where(p => p.LastWateredDate < DateTime.Today);
      Console.WriteLine("Here are the plants that need water.");
      foreach (var plant in notWateredToday)
      {
        Console.WriteLine($"Plant number {plant.Id} is {plant.Species} last watered on {plant.LastWateredDate} garden.");
      }

      // View all the plants that have not been watered today
    }

    public void NeedWater()
    {
      Console.Clear();

      var notWateredToday = Plants.Where(p => DateTime.Compare(DateTime.Now, p.LastWateredDate) > p.WaterFrequency);
      foreach (var plant in notWateredToday)
      {
        Console.WriteLine($"{plant.Species} needs watered.");
      }

      // View all the plants that have not been watered today
    }
    public void ShowByLocation(string theLocation)
    {
      var plantLocation = Plants.Where(p => p.LocatedPlanted == theLocation);
      Console.Clear();
      Console.WriteLine($"Here are the plants in {theLocation}.");
      foreach (var plant in plantLocation)
      {
        Console.WriteLine($"Plant number {plant.Id} is {plant.Species}.");
      }
    }
    public void GetLocations()
    {
      //var plantLocations = Plants.Distinct();

      var plantLocations = Plants.Select(p => p.LocatedPlanted).Distinct();

      foreach (var plant in plantLocations)
      {
        Console.WriteLine($"{plant}");
      }
    }














    public PlantDatabaseContext()
    {
    }

    public PlantDatabaseContext(DbContextOptions<PlantDatabaseContext> options)
      : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseNpgsql("server=localhost;database=PlantDatabase");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
