using System.Collections.Generic;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.Services
{
  public interface IDocumentQuery
  {
    IEnumerable<Document> Search(DocumentSearchCriteria criteria);
  }
}