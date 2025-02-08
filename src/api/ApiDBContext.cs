using Microsoft.EntityFrameworkCore;

namespace api;

public class ApiDBContext : DbContext
{
  public ApiDBContext(DbContextOptions<ApiDBContext> opts) : base(opts)
  {

  }

  public DbSet<WeatherForecast> WeatherForecastDbSet { get; set; }
}
