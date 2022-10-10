using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Documents.Validation.chain;

namespace DocFlow.Domain.Documents.Validation.Criteria.QEP
{
  public class AuthorValidator : BaseCriterion
  {
    public AuthorValidator(DocumentStatus[] supportedStatuses) : base(supportedStatuses)
    {      
    }
      
    public override DocumentProblem Check(Document document)
    {
      if (document.Author == null)
      {
        return new DocumentProblem("Author not set", ProblemSeverity.STANDARD);
      }
      return null;
    }
  }
}