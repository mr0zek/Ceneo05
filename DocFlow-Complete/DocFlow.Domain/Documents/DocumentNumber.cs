namespace DocFlow.Domain.Documents
{
  public class DocumentNumber
  {
    protected bool Equals(DocumentNumber other)
    {
      return string.Equals(Number, other.Number);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((DocumentNumber) obj);
    }

    public override int GetHashCode()
    {
      return (Number != null ? Number.GetHashCode() : 0);
    }

    public string Number { get; private set; }

    public DocumentNumber(string number)
    {
      Number = number;
    }

    public override string ToString()
    {
      return Number;
    }

    public bool Empty()
    {
      return string.IsNullOrWhiteSpace(Number);
    }
  }
}
