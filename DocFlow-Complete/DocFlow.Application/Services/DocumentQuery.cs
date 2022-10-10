using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Specifications;
using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Shared.Specification;
using DocFlow.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Application.Services
{
  public class DocumentQuery : IDocumentQuery
  {
    private IDocumentRepository _documentRepository;

    public DocumentQuery(IDocumentRepository documentRepository)
    {
      _documentRepository = documentRepository;
    }

    public IEnumerable<Document> Search(DocumentSearchCriteria criteria)
    {
      DocumentQueryAssembler assembler = new DocumentQueryAssembler();
      assembler.Expired = criteria.Expired;
      assembler.Published = criteria.Published;
      assembler.WillExpireInWeek = criteria.WillExpireInWeek;
      assembler.Type = criteria.Type;
      var cmd = assembler.Build();

      // cmd.ExecureReader ....
      return new Document[0];
    }

    public IEnumerable<Document> GetDocumentsForAudit()
    {
      ISpecification<Document> auditCriterion = new StatusSpec(DocumentStatus.ARCHIVED)
        .And(new TypeSpec(DocumentType.QUALITY_BOOK))
        .And(new StatusSpec(DocumentStatus.DRAFT).Not())
        .And(new AuthorsSpec(CurrentUser()));

      IEnumerable<Document> documents = _documentRepository.GetAll();

      List<Document> result = new List<Document>();
      foreach (Document document in documents)
      {
        if (auditCriterion.IsSatisfiedBy(document))
        {
          result.Add(document);
        }
      }
      return result;
    }

    private User CurrentUser()
    {
      //Returning current user;
      return new User(Guid.NewGuid());
    }
  }
}