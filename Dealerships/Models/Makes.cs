using System.Collections.Generic;

namespace Makes.Models
{

  public class Makes
  {
    public int MakeId { get; set;  }
    public string Name {get; set; }
    public list<CarModels> CarModels {get; set; }
  }
}