using System;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Statemachine
{
  internal class Draft : BaseDocumentState
  {
    public Draft(Document document, IDocumentValidator validator, IEventsPublisher publisher)
      : base(document, validator, publisher, DocumentStatus.DRAFT)
    {
    }

    public override void ChangeTitle(string newTitle)
    {
      if (newTitle == _document.Title)
      {
        return;
      }
      (_document as IDocumentInternal).SetTitle(newTitle);      
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
      if (verifier.Equals(_document.Author))
      {
        throw new DocumentOpeartionException(_document.Number, "Can not verify by author");
      }
      var result = _validator.Validate(_document as Document, DocumentStatus.VERIFIED);
      if (result.Count > 0)
      {
        throw new DocumentOpeartionException(_document.Number, string.Join(Environment.NewLine, result));
      }
      (_document as IDocumentInternal).SetStatus(DocumentStatus.VERIFIED);
      _publisher.Publish(new DocumentVerifiedEvent(_document.Number));
    }
  }
}
