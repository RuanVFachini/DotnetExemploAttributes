using AttributeExample.Enums;
using AttributeExample.Extensions;
using AttributeExample.Models;

namespace AttributeExample.Services;

public static class MovimentoService
{
  public static void AbrirPorta(Carro carro, LadoEnum lado, RotacaoPortaEnum value)
  {
    var portaLado = carro.Ports.First(x => x.Lado == lado);
    portaLado.Estado.ValidateExecutionOrder(TipoAcaoEnum.MoverPorta, value);
    portaLado.Estado = value;
  }
}
