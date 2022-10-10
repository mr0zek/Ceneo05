using System;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents
{
  public class DocumentFactory : IDocumentFactory
  {
    private readonly INumberGenerator _numberGenerator;
    private readonly IEventsPublisher _eventsPublisher;
    private readonly IDocumentValidator _validator;

    public DocumentFactory(INumberGenerator numberGenerator, IEventsPublisher eventsPublisher, IDocumentValidator validator)
    {
      _numberGenerator = numberGenerator;
      _eventsPublisher = eventsPublisher;
      _validator = validator;
    }

    public Document Create(DocumentType type, User author)
    {
      var number = _numberGenerator.Generate();
      return new Document(type, author, number, DateTime.Now, _validator, _eventsPublisher);
    }

    public Document Create(DocumentType type, User author, DocumentNumber number, DateTime calculateExpiryDate)
    {
      return new Document(type, author, number, DateTime.Now, _validator, _eventsPublisher);
    }
  }
}