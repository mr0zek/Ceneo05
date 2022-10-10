using System;
using DocFlow.Application.Commands;
using DocFlow.Application.Commands.Cmd;
using DocFlow.Application.Commands.impl;
using DocFlow.Domain.Documents;
using NUnit.Framework;

namespace DocFlow.Tests.AcceptanceTests
{
  [TestFixture]
  public class FlowProcessScenarioViaGate
  {
    private IGate gate = new StandardGate();

    [Test]
    public void StandardProcess()
    {
      Guid tennantId = Guid.NewGuid();
      Guid creatorId = Guid.NewGuid();
      Guid verifierId = Guid.NewGuid();

      CreateDocumentCommand createDocumentCommand = new CreateDocumentCommand(creatorId, DocumentType.PROCEDURE, "title 1",tennantId );
      string documentNumber = gate.Dispatch(createDocumentCommand).ToString();

      VerifyDocumentCommand verifyDocumentCommand = new VerifyDocumentCommand(tennantId, verifierId, documentNumber);
      gate.Dispatch(verifyDocumentCommand);

      PublishDocumentCommand publishDocumentCommand = new PublishDocumentCommand(tennantId,  documentNumber);
      gate.Dispatch(publishDocumentCommand);      
    }
  }
}
