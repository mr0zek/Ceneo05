
using System;

namespace DocFlow.Application.Commands.Cmd
{
  public class VerifyDocumentCommand : BaseCommand
  {
    public string DocumentNumber { get; private set; }

    public Guid VerifierId { get; private set; }

    public VerifyDocumentCommand(Guid tennantId, Guid verifierId, string documentNumber)
      : base(tennantId)
    {
      VerifierId = verifierId;
      DocumentNumber = documentNumber;      
    }
  }
}

