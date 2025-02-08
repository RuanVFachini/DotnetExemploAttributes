using System.Text.Json.Serialization;
using Atributos.Enums;

namespace Atributos.Models
{
  public class Porta(LadoEnum lado)
  {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LadoEnum Lado { get; set; } = lado;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public RotacaoPortaEnum Estado { get; set; } = RotacaoPortaEnum.Fechada;
  }
}
