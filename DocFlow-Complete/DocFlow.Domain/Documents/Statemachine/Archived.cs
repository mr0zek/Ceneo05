using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Statemachine
{
  internal class Archived : BaseDocumentState
  {
    public Archived(Document document, IDocumentValidator validator, IEventsPublisher publisher) : base(document, validator, publisher, DocumentStatus.ARCHIVED)
    {
    }

    public override void ChangeTitle(string newTitle)
    {
      throw new DocumentOpeartionException(_document.Number, "Can not change title if status is: " + _document.Status);
    }

    public override void Publish(ICostCalculator costCalculator)
    {
      throw new DocumentOpeartionException(_document.Number, "Can not publish if status is: " + _document.Status);
    }

    public override void Archive()
    {
      throw new DocumentOpeartionException(_document.Number, "Can not archive if status is: " + _document.Status);
    }

    public override void Verify(User verifier)
    {
      throw new DocumentOpeartionException(_document.Number, "Can not verify if status is: " + _document.Status);
    }
  }
}