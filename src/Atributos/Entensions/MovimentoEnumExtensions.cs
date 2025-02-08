using System.Reflection;
using Atributos.Attributes;
using Atributos.Enums;

namespace Atributos.Entensions
{
  public static class MovimentoEnumExtensions
  {
    public static IEnumerable<T> ListaMovimentosDisponiveis<T>(
      this T value,
      TipoAcaoEnum commandType) where T : Enum
    {
      Type enumType = typeof(T);
      TipoMovimentoAttribute enumAttributes = enumType.GetCustomAttribute<TipoMovimentoAttribute>()
        ?? throw new Exception("A operação só é permitida para enumerados anotados com o atributo [TipoMovimentoAttribute]");

      if (enumAttributes.Acao != commandType)
      {
        throw new Exception($"A operação solicitada não é permitida para o campo do tipo [${enumType.Name}]");
      }

      int currentPositionOrder = value.GetAttributeOfType<OrdemSequencialAttribute>()?.Order
        ?? throw new Exception("O valor atual não está anotado com atributo [OrdemSequencialAttribute]");

      List<KeyValuePair<T, OrdemSequencialAttribute?>> moves = enumType.GetEnumNames()
              .ToList()
              .Select(enumValueName =>
              {
                MemberInfo[] memberInfoArray = enumType.GetMember(enumValueName);
                OrdemSequencialAttribute? currentSquenceOrderAttribute = memberInfoArray
                            .Select(memberInfo => memberInfo.GetCustomAttribute<OrdemSequencialAttribute>())
                            .FirstOrDefault();

                T enumValue = (T)Enum.Parse(enumType, enumValueName.AsSpan());
                return new KeyValuePair<T, OrdemSequencialAttribute?>(enumValue, currentSquenceOrderAttribute);
              })
              .ToList();

      return moves.Count == 0
        ? throw new Exception($"Nenhum valor anotado com o atributo [OrdemSequencialAttribute] foi identificado no tipo [{enumType.Name}]")
        : moves
          .Where(move => move.Value != null && Math.Abs(currentPositionOrder - move.Value.Order) == 1)
          .Select(x => x.Key)
          .Append(value);
    }
  }
}

