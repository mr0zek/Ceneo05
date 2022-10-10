
using System;

namespace DocFlow.Application.Commands.Cmd
{
  public class PublishDocumentCommand : BaseCommand
  {
    public string DocumentNumber { get; private set; }

    
    public PublishDocumentCommand(Guid tennantId, string documentNumber) : base(tennantId)
    {
      DocumentNumber = documentNumber;
    }
  }
}

