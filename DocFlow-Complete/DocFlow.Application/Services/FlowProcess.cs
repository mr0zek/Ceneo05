using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Copier;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Specifications;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Shared.Specification;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Events;
using DocFlow.Infrastructure.Repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DocFlow.Application.Services
{
  public class FlowProcess : IFlowProcess
  {
    private IDocumentRepository documentRepo = new FakeDocumentRepository();

    private IUserRepository userRepo = new FakeUserRepository();
    private IDocumentFactory _documentFactory = new DocumentFactory(NumberGeneratorFactory.Create(GetCurrentUser(), new ConfigBasedConfiguration()), EventsEngine.Instance, DocumentValidatorFactory.Create(new ConfigBasedConfiguration()));
    private CopierFactory _copierFactory;

    private CostCalculatorFactory costCalculatorFactory = new CostCalculatorFactory(new ConfigBasedConfiguration());

    public FlowProcess()
    {
      _copierFactory = new CopierFactory(_documentFactory);
    }

    private static User GetCurrentUser()
    {
      // returning current user
      return new User(Guid.NewGuid());
    }

    public DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title)
    {
      User creator = userRepo.Get(creatorId);

      Document document = _documentFactory.Create(type, creator);

      document.ChangeTitle(title);    

      documentRepo.Save(document);
      return document.Number;
    }

    public void VerifyDocument(Guid verifierId, DocumentNumber documentNumber)
    {
      Document document = documentRepo.Get(documentNumber);
      User verifier = userRepo.Get(verifierId);

      document.Verify(verifier);

      documentRepo.Save(document);
    }

    public void PublishDocument(DocumentNumber documentNumber)
    {
      Document document = documentRepo.Get(documentNumber);

      ICostCalculator calculator = costCalculatorFactory.Create(document);

      document.Publish(calculator);

      documentRepo.Save(document);

      //print
      //notify
      //...
    }

    public IEnumerable<Document> SearchDocumentToAudit(IEnumerable<Document> documents)
    {
      ISpecification<Document> spec = SpecificationFactory.Create();
      
      return documents.Where(f => spec.IsSatisfiedBy(f));
    }

    public DocumentNumber CreateNewVersion(DocumentNumber documentNumber)
    {
      Document document = documentRepo.Get(documentNumber);

      ISpecification<Document> doc =
       new TypeSpec(DocumentType.PROCEDURE)
       .And(new ExpiringSpec(10))
       .And(new AuthorsSpec(new User(Guid.NewGuid())));

      doc.IsSatisfiedBy(document);

      IDocumentCopier copier = _copierFactory.Create();
      Document newDocument = copier.Copy(document);

      documentRepo.Save(newDocument);
      return newDocument.Number;
    }

    public void Correct(Guid correctorId, DocumentNumber documentNumber)
    {
      User user = userRepo.Get(correctorId);
      //TODO sprawdzić czy user posiada rolę
    }
  }
}