using System.Text.Json;
using Atributos.Entensions;
using Atributos.Enums;
using Atributos.Models;

namespace Atributos.Services
{
  public class CarroManager
  {
    private readonly Carro _carro = new("Carro velho", "Marca de carro velho");

    public void AbrirPorta(LadoEnum lado, RotacaoPortaEnum value)
    {
      Porta portaLado = _carro.Portas.First(x => x.Lado == lado);
      portaLado.Estado.ValidateExecutionOrder(TipoAcaoEnum.MoverPorta, value);
      portaLado.Estado = value;
    }

    public void PrintarEstadoAtual()
    {
      Console.WriteLine($"Estado atual: {JsonSerializer.Serialize(
        _carro,
        new JsonSerializerOptions { WriteIndented = true })}");
    }
  }
}
