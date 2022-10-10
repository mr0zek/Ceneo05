using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Users;
using DocFlow.Domain.Users.Roles;
using System.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
  public class NumberGeneratorFactory
  {
    private static INumberGenerator CreateBase(IConfigurationData configurationData)
    {
      if (configurationData.QualitySystem == null)
      {
        throw new ConfigurationException("Invalid quality system in configuration");
      }

      switch (configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          //return new ExternalNumberGeneratorAdapter(new ExternalNumberGenerator());
          return new NumberGeneratorProxy(new IsoNumberGenerator(), new ExternalNumberGeneratorAdapter(new ExternalNumberGenerator()));

        case QualitySystemType.QEP:
          return new NumberGeneratorProxy(new QepNumberGenerator(), new ExternalNumberGeneratorAdapter(new ExternalNumberGenerator()));

        default:
          throw new ConfigurationException("Invalid quality system in configuration");
      }
    }

    public static INumberGenerator Create(User creator, IConfigurationData configurationData)
    {
      var result = CreateBase(configurationData);

      if (creator.HasRole<Auditor>())
      {
        creator.GetRole<Auditor>().Audit();
        result = new PrefixNumberGenerator(result, "Audit_");
      }

      if (configurationData.EnvName == null)
      {
        throw new ConfigurationException("Invalid EnvName");
      }
      switch (configurationData.EnvName.ToUpper())
      {
        case "DEMO":
          result = new PrefixNumberGenerator(result, "Demo_");
          break;

        case "PROD":
          break;

        default:
          throw new ConfigurationException("Invalid EnvName");
      }

      return result;
    }
  }
}