using System.Text.Json.Serialization;
using AttributeExample.Enums;

namespace AttributeExample.Models
{
  public class Porta(LadoEnum lado)
  {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LadoEnum Lado { get; set; } = lado;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RotacaoPortaEnum Estado { get; set; } = RotacaoPortaEnum.Fechada;
  }
}
