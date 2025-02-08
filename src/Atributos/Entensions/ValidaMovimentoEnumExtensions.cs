using Atributos.Enums;

namespace Atributos.Entensions
{
  public static class ValidaMovimentoEnumExtensions
  {
    public static void ValidateExecutionOrder<T>(this T state, TipoAcaoEnum commandType, T value)
        where T : Enum
    {
      IEnumerable<T> availableMoves = state.ListaMovimentosDisponiveis(commandType);

      if (!availableMoves.Contains(value))
      {
        throw new Exception($"O movimento [{commandType}] solicitado não é possível! Estado atual: {state} | Estado solicitado: {value}");
      }
    }
  }
}
