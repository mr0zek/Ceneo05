using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Shared;

namespace DocFlow.Domain.Documents.Cost
{
  public class CostCalculatorFactory : ICostCalculatorFactory
  {
    private readonly IConfigurationData _configurationData;

    public CostCalculatorFactory(IConfigurationData configurationData)
    {
      _configurationData = configurationData;
    }

    public ICostCalculator Create(Document document)
    {
      ICostCalculator costCalculator = null;
      if (!_configurationData.ColorPrintingEnabled)
      {
        costCalculator = new BwCostCalulator();
      }
      else
      {
        costCalculator = new ColorCalculator();
      }

      if (document.PageCount > 100)
      {
        costCalculator = new PageCountCostDecorator(costCalculator, new Money(40d));
      }

      if (document.Type == DocumentType.QUALITY_BOOK)
      {
        costCalculator = new DocumentTypeCostDecorator(costCalculator, 30);
      }

      return costCalculator;
    }
  }
}