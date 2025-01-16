using AttributeExample.Attributes;

namespace AttributeExample.Enums
{
  [TipoMovimento]
  public enum RotacaoPortaEnum : int
  {
    [OrdemSequencial(0)]
    Fechada = 0,

    [OrdemSequencial(1)]
    PrimeiroEstagio = 1,

    [OrdemSequencial(2)]
    SegundoEstagio = 2
  }
}
