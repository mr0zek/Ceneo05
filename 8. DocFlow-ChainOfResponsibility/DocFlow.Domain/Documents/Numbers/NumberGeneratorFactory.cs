using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Users;
using DocFlow.Domain.Users.Roles;
using System;
using System.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
  public class NumberGeneratorFactory
  {
    internal static INumberGenerator Create(IConfigurationData configurationData)
    {
      INumberGenerator result;

      result = CreateBase(configurationData);

      result = new SufixNumberGenerator(result, "Audit_");

      switch (configurationData.EnvType)
      {
        case EnvironmentType.DEMO:
          return new PrefixNumberGenerator(result, "Demo_");

        case EnvironmentType.PROD:
          break;
      }
      return result;
    }

    private static INumberGenerator CreateBase(IConfigurationData configurationData)
    {
      switch (configurationData.QualitySystem)
      {
        case QualitySystemType.ISO:
          return new IsoNumberGenerator();

        case QualitySystemType.QEP:
          return new QepNumberGenerator();
      }
      throw new ConfigurationException();
    }

    private static User GetCurrentUser()
    {
      return new User(Guid.NewGuid());// returnin current logged user;
    }
  }
}