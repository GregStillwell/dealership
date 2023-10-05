namespace Dealerships.Models
{
  public class CarModels
  {
    public int CarModelId {  get; set; }
    public string Name {  get; set; }
    public string Type {  get; set; }
    public int MakeId {  get; set; }
    public Makes Makes {  get; set; }
  }
}