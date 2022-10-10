using System.Collections.Generic;
using DocFlow.Domain.Documents.Statemachine;

namespace DocFlow.Domain.Documents.Validation.chain
{
  public class ManagerDocumentValidator : IDocumentValidator
  {
    private IList<IDocumentCriterion> _criterions = new List<IDocumentCriterion>();

    public void AddCritetion(IDocumentCriterion criterion)
    {
      _criterions.Add(criterion);
    }

    public List<DocumentProblem> Validate(Document document, DocumentStatus desiredStatus)
    {
      List<DocumentProblem> result = new List<DocumentProblem>();
      foreach (IDocumentCriterion documentCriterion in _criterions)
      {
        if (documentCriterion.CanCheck(desiredStatus))
        {
          var check = documentCriterion.Check(document);
          if (check != null)
          {
            result.Add(check);
          }
        }
      }
      return result;
    }

  }
}