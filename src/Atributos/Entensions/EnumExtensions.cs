namespace Atributos.Entensions
{
  public static class EnumExtensions
  {
    public static T? GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
    {
      Type type = enumVal.GetType();
      System.Reflection.MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
      object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
      return attributes.Length > 0 ? (T)attributes[0] : null;
    }
  }
}
