using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api;

public class WeatherForecast
{
  [Key]
  public int Codigo { get; set; }

  public DateOnly Date { get; set; }

  public int TemperatureC { get; set; }

  [NotMapped]
  public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

  [NotMapped]
  public string? PropriedadeQueNaoEhSalva { get; set; }

  [MaxLength(10)]
  public string? Summary { get; set; }
}
