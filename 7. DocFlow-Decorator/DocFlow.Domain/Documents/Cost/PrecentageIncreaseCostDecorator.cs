using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class DocumentTypeCostDecorator : BaseCostDecorator
  {
    private readonly int _costIncreasePercentage;
    
    public DocumentTypeCostDecorator(ICostCalculator calc, int costIncreasePercentage)
      : base(calc)
    {
      _costIncreasePercentage = costIncreasePercentage;      
    }

    public override Money Calculate()
    {
      Money result = _decorated.Calculate();
      result.MultiplyBy(((double)100+_costIncreasePercentage)/100);
      return result;
    }
  }
}