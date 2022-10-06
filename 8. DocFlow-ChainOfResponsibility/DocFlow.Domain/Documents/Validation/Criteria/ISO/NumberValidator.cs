using System.Collections.Generic;

namespace DocFlow.Domain.Documents.Validation.Criteria.ISO
{
  public class NumberValidator : BaseChainValidator
  {
    public NumberValidator(IDocumentValidator next)
      : base(next)
    {
    }

    public override bool Validate(Document document, DocumentStatus desiredStatus)
    {
      if (desiredStatus == DocumentStatus.VERIFIED && document.Number == null)
      {
        return false;
      }
      return base.Validate(document, desiredStatus);
    }
  }
}