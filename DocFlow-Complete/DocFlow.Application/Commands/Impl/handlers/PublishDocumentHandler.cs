using DocFlow.Application.Commands.Cmd;
using DocFlow.Application.Services;
using DocFlow.Domain.Documents;
using System;
using DocFlow.Domain.Documents.Cost;

namespace DocFlow.Application.Commands.impl.handlers
{
  public class PublishDocumentHandler : ICommandHandler<PublishDocumentCommand>
  {
    private readonly IFlowProcess _flowProcess;
    private IDocumentRepository _documentRepo;
    private CostCalculatorFactory _costCalculatorFactory;

    public object Handle(PublishDocumentCommand command)
    {
      Document document = _documentRepo.Get(new DocumentNumber(command.DocumentNumber));

      ICostCalculator calculator = _costCalculatorFactory.Create(document);

      document.Publish(calculator);

      _documentRepo.Save(document);
      return null;
    }
  }
}