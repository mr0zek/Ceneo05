using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class CostCalculatorFactory
  {
    private readonly IConfigurationData _configurationData;

    public CostCalculatorFactory(IConfigurationData configurationData)
    {
      _configurationData = configurationData;
    }

    public ICostCalculator Create(Document documentInternal)
    {
      ICostCalculator calc = CreateBase();

      calc = new PageCountCostDecorator(calc, 100, new Money(40d)); 
      calc = new DocumentTypeCostDecorator(calc, DocumentType.QUALITY_BOOK, 30);

      return calc;
    }

    private ICostCalculator CreateBase()
    {
      if (!_configurationData.ColorPrintingEnabled)
      {
        return new BwCostCalulator();
      }

      return new ColorCalculator();
    }
  }
}