using DocFlow.Domain.Shared.Specification;
using DocFlow.Domain.Users;
using System.Linq;

namespace DocFlow.Domain.Documents.Specifications
{
  public class AuthorsSpec : CompositeSpecification<Document>
  {
    private readonly User[] _authors;

    public AuthorsSpec(params User[] authors)
    {
      _authors = authors;
    }

    public override bool IsSatisfiedBy(Document candidate)
    {
      return _authors.Any(f => f.Equals(candidate.Author));
    }
  }
}