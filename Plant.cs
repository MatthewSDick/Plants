using System;

namespace Plants

{

  public class Plant
  {
    public int Id { get; set; }
    public string Species { get; set; }
    public string LocatedPlanted { get; set; }
    public DateTime PlantedDate { get; set; } = DateTime.Now;
    public DateTime LastWateredDate { get; set; } = DateTime.Now;
    public int LightNeeded { get; set; }
    public int WaterNeeded { get; set; }

  }

}