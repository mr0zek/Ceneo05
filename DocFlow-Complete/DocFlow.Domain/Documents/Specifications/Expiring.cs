using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Shared.Specification;
using System;

namespace DocFlow.Domain.Documents.Specifications
{
  public class ExpiringSpec : CompositeSpecification<Document>
  {
    private int _days;

    public ExpiringSpec(int days)
    {
      _days = days;
    }

    public override bool IsSatisfiedBy(Document documentInternal)
    {
      return IsPublished(documentInternal) && Expires(documentInternal);
    }

    private bool Expires(Document documentInternal)
    {
      return documentInternal.ExpiryDate != null && documentInternal.ExpiryDate < DateTime.Now.AddDays(_days);
    }

    private bool IsPublished(Document documentInternal)
    {
      return documentInternal.Status == DocumentStatus.PUBLISHED;
    }
  }
}