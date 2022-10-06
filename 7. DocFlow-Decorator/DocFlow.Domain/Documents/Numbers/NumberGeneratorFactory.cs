using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Users;
using DocFlow.Domain.Users.Roles;
using System;
using System.Configuration;

namespace DocFlow.Domain.Documents.Numbers
{
  public class NumberGeneratorFactory : INumberGeneratorFactory
  {
    public INumberGenerator Create(IConfigurationData configurationData, User currentUser)
    {
      INumberGenerator result;

      result = CreateBase(configurationData);

      if (currentUser.HasRole<Auditor>())
      {
        result = new SufixNumberDecorator(result, "Audit_");
      }

      switch (configurationData.EnvType)
      {
        case EnvironmentType.DEMO:
          return new PrefixNumberDecorator(result, "Demo_");

        case EnvironmentType.PROD:
          break;
      }
      return result;
    }

    private INumberGenerator CreateBase(IConfigurationData configurationData)
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