using System.Collections.Generic;
using DocFlow.Domain.Documents.Statemachine;

namespace DocFlow.Domain.Documents.Validation.chain
{
  public abstract class BaseCriterion : IDocumentCriterion
  {
    private List<DocumentStatus> _supportedStatuses = new List<DocumentStatus>();

    public BaseCriterion(DocumentStatus[] supportedStatuses)
    {
      _supportedStatuses.AddRange(supportedStatuses);
    }

    public bool CanCheck(DocumentStatus desiredStatus)
    {
      return _supportedStatuses.Contains(desiredStatus);
    }

    public abstract DocumentProblem Check(Document document);
  }
}