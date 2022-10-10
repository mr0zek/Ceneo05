using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Documents.Validation.chain;

namespace DocFlow.Domain.Documents.Validation.Criteria
{
  public class ExpiryDateValidator : BaseCriterion
  {
    public ExpiryDateValidator(DocumentStatus[] supportedStatuses) : base(supportedStatuses)
    {      
    }

    public override DocumentProblem Check(Document document)
    {
      if (!document.ExpiryDate.HasValue)
      {
        return new DocumentProblem("ExpiryDate not set", ProblemSeverity.STANDARD);
      }
      return null;
    }
  }
}