using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Documents.Validation.chain;
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
      ManagerDocumentValidator validator = new ManagerDocumentValidator();

      switch (configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          validator.AddCritetion(new NumberValidator(new[]
            {
              DocumentStatus.VERIFIED
            }));
          validator.AddCritetion(new ExpiryDateValidator(new[]
            {
              DocumentStatus.PUBLISHED
            }));
          break;

        case QualitySystemType.QEP:
          validator.AddCritetion(new AuthorValidator(new[]
            {
              DocumentStatus.DRAFT,
              DocumentStatus.VERIFIED,
              DocumentStatus.PUBLISHED,
              DocumentStatus.ARCHIVED
            }));
          validator.AddCritetion(new ExpiryDateValidator(new[]
            {
              DocumentStatus.DRAFT,
              DocumentStatus.VERIFIED,
              DocumentStatus.PUBLISHED,
              DocumentStatus.ARCHIVED,
            }));
          validator.AddCritetion(new BodyValidator(new[]
            {
              DocumentStatus.VERIFIED,
              DocumentStatus.PUBLISHED,
              DocumentStatus.ARCHIVED
            }));
          break;

        default:
          throw new ConfigurationException("Invalid quality system in configuration");
      }

      return validator;
    }
  }
}