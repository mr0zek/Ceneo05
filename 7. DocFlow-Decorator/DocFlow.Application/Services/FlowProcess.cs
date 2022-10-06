using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Repo;
using System;

namespace DocFlow.Application.Services
{
  public class FlowProcess
  {
    private readonly IDocumentRepository documentRepo = new FakeDocumentRepository();
    private readonly IUserRepository userRepo = new FakeUserRepository();
    private readonly ICostCalculatorFactory _costCalculatorFactory;
    private readonly IDocumentFactory _documentFactory;

    public FlowProcess(IDocumentFactory documentFactory, ICostCalculatorFactory costCalculatorFactory)
    {
      _documentFactory = documentFactory;
      _costCalculatorFactory = costCalculatorFactory;
    }

    public DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title)
    {
      User creator = userRepo.Load(creatorId);

      Document document = _documentFactory.Create(type, creator);
      document.changeTitle(title);

      documentRepo.Save(document);
      return document.Number;
    }

    public void VerifyDocument(Guid verifierId, DocumentNumber documentNumber)
    {
      Document document = documentRepo.Load(documentNumber);
      User verifier = userRepo.Load(verifierId);

      document.Verify(verifier);

      documentRepo.Save(document);
    }

    public void PublishDocument(DocumentNumber documentNumber)
    {
      Document document = documentRepo.Load(documentNumber);

      var costCalculator = _costCalculatorFactory.Create(document);

      document.Publish(costCalculator);

      documentRepo.Save(document);

      //print
      //notify
      //...
    }
  }
}