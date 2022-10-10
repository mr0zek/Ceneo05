using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Statemachine
{
  internal abstract class BaseDocumentState : IDocumentState
  {
    protected readonly Document _document;
    protected readonly IDocumentValidator _validator;
    protected readonly IEventsPublisher _publisher;

    public BaseDocumentState(Document document, IDocumentValidator validator, IEventsPublisher publisher, DocumentStatus status)
    {
      Status = status;
      _document = document;
      _validator = validator;
      _publisher = publisher;
    }

    public abstract void ChangeTitle(string newTitle);
    public abstract void Publish(ICostCalculator costCalculator);
    public abstract void Archive();
    public abstract void Verify(User verifier);
    public DocumentStatus Status { get; private set; }
  }
}