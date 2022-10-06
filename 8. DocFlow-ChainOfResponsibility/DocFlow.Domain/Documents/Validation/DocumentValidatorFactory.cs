using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Validation.Criteria;
using DocFlow.Domain.Documents.Validation.Criteria.ISO;
using DocFlow.Domain.Documents.Validation.Criteria.QEP;
using System.Configuration;

namespace DocFlow.Domain.Documents.Validation
{
  public class DocumentValidatorFactory
  {
    public static IDocumentValidator Create(IConfigurationData configurationData)
    {
      switch (configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          return new NumberValidator(new ExpiryDateValidator(DocumentStatus.PUBLISHED, null));

        case QualitySystemType.QEP:
          return new AuthorValidator(new ExpiryDateValidator(DocumentStatus.VERIFIED, new BodyValidator(null)));

        default:
          throw new ConfigurationException("Invalid quality system in configuration");
      }
    }
  }
}