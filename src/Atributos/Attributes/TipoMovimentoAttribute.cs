using Atributos.Enums;

namespace Atributos.Attributes
{
  [AttributeUsage(AttributeTargets.Enum)]
  public class TipoMovimentoAttribute(TipoAcaoEnum acao) : Attribute
  {
    public TipoAcaoEnum Acao { get; } = acao;
  }
}
