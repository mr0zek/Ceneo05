using DocFlow.Domain.Documents.Validation.Criteria.QEP;

namespace DocFlow.Domain.Documents.Validation.Criteria
{
  public class ExpiryDateValidator : BaseChainValidator
  {
    private readonly DocumentStatus _supportedStatus;

    public ExpiryDateValidator(DocumentStatus supportedStatus, IDocumentValidator documentValidator)
      : base(documentValidator)
    {
      _supportedStatus = supportedStatus;
    }

    public override bool Validate(Document document, DocumentStatus desiredStatus)
    {
      if (desiredStatus == _supportedStatus && !document.ExpiryDate.HasValue)
      {
        return false;
      }
      return base.Validate(document, desiredStatus);
    }
  }
}