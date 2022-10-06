using DocFlow.Domain.Documents.Validation.Criteria.ISO;

namespace DocFlow.Domain.Documents.Validation.Criteria.QEP
{
  public class AuthorValidator : BaseChainValidator
  {
    public AuthorValidator(IDocumentValidator next)
      : base(next)
    {
    }

    public override bool Validate(Document document, DocumentStatus desiredStatus)
    {
      if (desiredStatus == DocumentStatus.VERIFIED && document.Author == null)
      {
        return false;
      }
      return base.Validate(document, desiredStatus);
    }
  }
}