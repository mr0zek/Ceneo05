using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;

namespace DocFlow.Tests.Domain.Documents
{
  public class FakeConfigurationData : IConfigurationData
  {
    public QualitySystemType QualitySystem { get; set; }
    public string EnvName { get; set; }
    public bool ColorPrintingEnabled { get; set; }
  }
}