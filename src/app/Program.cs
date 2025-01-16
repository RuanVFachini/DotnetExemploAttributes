using System.Text.Json;
using AttributeExample.Enums;
using AttributeExample.Models;
using AttributeExample.Services;

//Inicaliza object
Carro carro = new("Onix", "Chevrolet");
PrintarEstadoAtual(carro);

MovimentoService.AbrirPorta(carro, LadoEnum.Direito, RotacaoPortaEnum.PrimeiroEstagio);
PrintarEstadoAtual(carro);

MovimentoService.AbrirPorta(carro, LadoEnum.Direito, RotacaoPortaEnum.SegundoEstagio);
PrintarEstadoAtual(carro);

static void PrintarEstadoAtual(Carro carroState)
{
  JsonSerializerOptions options = new();
  System.Text.Json.Serialization.JsonStringEnumConverter stringEnumConverter = new();
  options.Converters.Add(stringEnumConverter);
  Console.WriteLine($"Estado atual: {JsonSerializer.Serialize(carroState)}");
}


