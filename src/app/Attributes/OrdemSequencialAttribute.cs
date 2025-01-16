namespace AttributeExample.Attributes
{
  [AttributeUsage(AttributeTargets.Field)]
  public class OrdemSequencialAttribute(int order) : Attribute
  {
    public int Order { get; } = order;
  }
}
