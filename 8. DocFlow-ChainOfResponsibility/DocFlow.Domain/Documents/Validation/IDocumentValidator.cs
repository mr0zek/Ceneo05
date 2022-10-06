namespace DocFlow.Domain.Documents.Validation
{
  public interface IDocumentValidator
  {
    bool Validate(Document document, DocumentStatus desiredStatus);
  }
}