using System.Collections.Generic;
using DocFlow.Domain.Documents.Statemachine;

namespace DocFlow.Domain.Documents.Validation
{
  public interface IDocumentValidator
  {
    List<DocumentProblem> Validate(Document document, DocumentStatus desiredStatus);
  }
}