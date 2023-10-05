using Microsoft.EntityFrameworkCore;

namespace Dealerships.Models
{
  public class DealershipsContext : DbContext
  {
    public DbSet<Makes> Makes { get; set; }
    public DbSet<CarModels> CarModels { get; set; }
    public DealershipsContext(DbContextOptions options) : base(options)
    {
      
    }
  }
}