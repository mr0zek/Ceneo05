using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  internal class ColorCalculator : ICostCalculator
  {
    public Money Calculate(Document doc)
    {
      if (doc.Type == DocumentType.PROCEDURE)
        return new Money(10d);

      return new Money(20d);
    }
  }
}