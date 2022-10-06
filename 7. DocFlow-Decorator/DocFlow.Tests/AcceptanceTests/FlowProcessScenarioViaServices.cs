using DocFlow.Application.Services;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Numbers;
using System;
using Xunit;

namespace DocFlow.Infrastructure.Repo
{
  public class FlowProcessScenarioViaServices
  {
    private static DocumentType DOCUMENT_TYPE = DocumentType.PROCEDURE;

    private FlowProcess flowProcess = new FlowProcess(new DocumentFactory(new NumberGeneratorFactory()),new CostCalculatorFactory(new ConfigurationData()));

    [Fact]
    public void StandardProcess()
    {
      Guid creator = Guid.NewGuid();
      Guid verifier = Guid.NewGuid();

      DocumentNumber documentNumber = flowProcess.CreateDocument(creator, DOCUMENT_TYPE, "procedure 1");
      flowProcess.VerifyDocument(verifier, documentNumber);
      flowProcess.PublishDocument(documentNumber);
    }
  }
}