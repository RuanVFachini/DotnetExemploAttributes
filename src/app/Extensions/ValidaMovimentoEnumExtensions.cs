using AttributeExample.Enums;
using AttributeExample.Exceptions;

namespace AttributeExample.Extensions;

public static class ValidaMovimentoEnumExtensions
{
  public static void ValidateExecutionOrder<T>(this T state, TipoAcaoEnum commandType, T value)
      where T : Enum
  {
    var availableMoves = state.ListaMovimentosDisponiveis();

    if (!availableMoves.Contains(value))
    {
      throw new MovimentoInvalidoException();
    }
  }
}
