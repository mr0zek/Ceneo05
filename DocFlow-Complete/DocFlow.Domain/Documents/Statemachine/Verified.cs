using System;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Statemachine
{
  internal class Verified : BaseDocumentState
  {
    public Verified(Document document, IDocumentValidator validator, IEventsPublisher publisher)
      : base(document, validator, publisher, DocumentStatus.VERIFIED)
    {
    }

    public override void ChangeTitle(string newTitle)
    {
      (_document as IDocumentInternal).SetStatus(DocumentStatus.DRAFT);
    }

    public override void Publish(ICostCalculator costCalculator)
    {
      (_document as IDocumentInternal).SetPrintingCost(costCalculator.Calculate(_document));
      var result = _validator.Validate(_document, DocumentStatus.PUBLISHED);
      if (result.Count > 0)
      {
        throw new DocumentOpeartionException(_document.Number, string.Join(Environment.NewLine, result));
      }
      (_document as IDocumentInternal).SetStatus(DocumentStatus.PUBLISHED);
      _publisher.Publish(new DocumentPublishedEvent(_document.Number));
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