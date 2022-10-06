using DocFlow.Domain.Documents.Validation.Criteria.ISO;

namespace DocFlow.Domain.Documents.Validation.Criteria.QEP
{
  public class BodyValidator : BaseChainValidator
  {
    public BodyValidator(IDocumentValidator next)
      : base(next)
    {
    }

    public override bool Validate(Document document, DocumentStatus desiredStatus)
    {
      if (desiredStatus == DocumentStatus.PUBLISHED && document.Body != null)
      {
        return false;
      }
      return base.Validate(document, desiredStatus);
    }
  }
}