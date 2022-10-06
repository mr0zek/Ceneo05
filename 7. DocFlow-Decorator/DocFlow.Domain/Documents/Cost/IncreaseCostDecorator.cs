using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class PageCountCostDecorator : ICostCalculator
  {
    private readonly Money _costIncrease;
    private readonly ICostCalculator _decorated;

    public PageCountCostDecorator(ICostCalculator calc, Money costIncrease)
    {
      _decorated = calc;
     _costIncrease = costIncrease;
    }

    public Money Calculate()
    {
      return _decorated.Calculate().Add(_costIncrease);      
    }
  }
}