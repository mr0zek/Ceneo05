using System;
using DocFlow.Application.EventListeners;
using DocFlow.Application.Services;
using DocFlow.Domain.Documents;
using DocFlow.Infrastructure.Events;
using NUnit.Framework;

namespace DocFlow.Tests.AcceptanceTests
{
  [TestFixture]
  public class FlowProcessScenarioViaServices
  {
    private static DocumentType DOCUMENT_TYPE = DocumentType.PROCEDURE;

    private FlowProcess flowProcess = new FlowProcess();

    [SetUp]
    public void RegisterListeners()
    {
      EventsEngine.Instance.RegisterListener(new DocumentPublishedListener());
    }

    [Test]
    public void StandardProcess()
    {
      Guid creator = Guid.NewGuid();
      Guid verifier = Guid.NewGuid();

      //TODO: assembler
      DocumentNumber documentNumber = flowProcess.CreateDocument(creator, DOCUMENT_TYPE, "procedure 1");
      flowProcess.VerifyDocument(verifier, documentNumber);
      flowProcess.PublishDocument(documentNumber);
    }
  }
}