using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Numbers
{
  public interface INumberGeneratorFactory
  {
    INumberGenerator Create(IConfigurationData configurationData, User currentUser);
  }
}