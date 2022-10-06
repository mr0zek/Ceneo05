namespace DocFlow.Domain.Documents.Validation.Criteria
{
  public abstract class BaseChainValidator : IDocumentValidator
  {
    private readonly IDocumentValidator _next;

    public BaseChainValidator(IDocumentValidator next)
    {
      _next = next;
    }

    public virtual bool Validate(Document document, DocumentStatus desiredStatus)
    {
      if (_next != null)
      {
        return _next.Validate(document, desiredStatus);
      }
      return true;
    }
  }
}