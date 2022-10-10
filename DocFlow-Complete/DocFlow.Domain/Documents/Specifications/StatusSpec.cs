using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Shared.Specification;

namespace DocFlow.Domain.Documents.Specifications
{
  public class StatusSpec : CompositeSpecification<Document>
  {
    private readonly DocumentStatus _status;

    public StatusSpec(DocumentStatus status)
    {
      _status = status;
    }

    public override bool IsSatisfiedBy(Document candidate)
    {
      return candidate.Status == _status;
    }
  }
}