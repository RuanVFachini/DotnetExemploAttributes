using System.Reflection;
using AttributeExample.Attributes;
using AttributeExample.Exceptions;

namespace AttributeExample.Extensions
{
  public static class TipoMovimentoExtensions
  {
    public static IEnumerable<T> ListaMovimentosDisponiveis<T>(this T value) where T : Enum
    {
      int currentPositionOrder = value.GetCurrentEnumValueOrder();
      Type enumType = typeof(T);

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

      return moves
          .Where(move => move.Value != null && Math.Abs(currentPositionOrder - move.Value.Order) == 1)
          .Select(x => x.Key)
          .Append(value);
    }

    public static int GetCurrentEnumValueOrder<T>(this T enumValue) where T : Enum
    {
      return enumValue.GetAttributeOfType<OrdemSequencialAttribute>()?.Order
          ?? throw new OrdemSequencialMissConfigurationException();
    }
  }
}
