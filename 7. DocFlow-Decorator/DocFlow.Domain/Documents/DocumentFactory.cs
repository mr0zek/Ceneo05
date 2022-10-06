using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Users;
using System;

namespace DocFlow.Domain.Documents
{
  public class DocumentFactory : IDocumentFactory
  {
    private readonly INumberGeneratorFactory _numberGeneratorFactory;

    public DocumentFactory(INumberGeneratorFactory numberGeneratorFactory)
    {
      _numberGeneratorFactory = numberGeneratorFactory;
    }

    public Document Create(DocumentType type, User author)
    {
      var generator = _numberGeneratorFactory.Create(new ConfigurationData(), author);
      var number = generator.Generate();
      return new Document(type, author, number);
    }
  }
}