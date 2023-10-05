using System.Collections.Generic;

namespace Dealerships.Models
{

  public class Makes
  {
    public int MakeId { get; set;  }
    public string Name {get; set; }
    public List<CarModels> CarModels {get; set; }
  }
}