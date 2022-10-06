using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Users;
using System;

namespace DocFlow.Domain.Documents
{
  public class DocumentFactory //: IDocumentFactory
  {
    IConfigurationData _configurationData;

    public DocumentFactory(IConfigurationData configData)
    {
      _configurationData = configData
    }
    public static Document Create(DocumentType type, User author)
    {
      var generator = NumberGeneratorFactory.Create(new ConfigurationData());
      return new Document(
        type,
        author,
        generator.Generate(), 
        Validation.DocumentValidatorFactory.Create(_configurationData));
    }
  }
}