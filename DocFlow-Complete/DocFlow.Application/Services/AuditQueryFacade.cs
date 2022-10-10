using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.Services
{
  public class AuditQueryFacade
  {
    private readonly IDocumentQuery _documentQuery;

    public AuditQueryFacade(IDocumentQuery documentQuery)
    {
      _documentQuery = documentQuery;
    }

    public IEnumerable<Document> GetDocumentsForAudit()
    {
      DocumentSearchCriteria criteria = new DocumentSearchCriteria();
      criteria.Published = true;
      criteria.WillExpireInWeek = true;
      criteria.AuthorId = GetLoggedUserId();
      return _documentQuery.Search(criteria);
    }

    private Guid GetLoggedUserId()
    {
      // Replace with correct UserId
      return Guid.NewGuid();
    }
  }
}
