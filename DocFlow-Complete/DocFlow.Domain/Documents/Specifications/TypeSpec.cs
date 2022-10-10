using DocFlow.Domain.Shared.Specification;

namespace DocFlow.Domain.Documents.Specifications
{
  public class TypeSpec : CompositeSpecification<Document>
  {
    private readonly DocumentType _documentType;

    public TypeSpec(DocumentType documentType)
    {
      _documentType = documentType;
    }

    public override bool IsSatisfiedBy(Document candidate)
    {
      return candidate.Type == _documentType;
    }
  }
}