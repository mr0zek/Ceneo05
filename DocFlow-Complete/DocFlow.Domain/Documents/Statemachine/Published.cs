using System;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Statemachine
{
  internal class Published : BaseDocumentState
  {
    public Published(Document document, IDocumentValidator validator, IEventsPublisher publisher)
      : base(document, validator, publisher, DocumentStatus.PUBLISHED)
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
      var result = _validator.Validate(_document, DocumentStatus.ARCHIVED);
      if (result.Count > 0)
      {
        throw new DocumentOpeartionException(_document.Number, string.Join(Environment.NewLine, result));
      }
      (_document as IDocumentInternal).SetStatus(DocumentStatus.ARCHIVED);
      _publisher.Publish(new DocumentArchivedEvent(_document.Number));
    }

    public override void Verify(User verifier)
    {
      throw new DocumentOpeartionException(_document.Number, "Can not verify if status is: " + _document.Status);
    }
  }
}