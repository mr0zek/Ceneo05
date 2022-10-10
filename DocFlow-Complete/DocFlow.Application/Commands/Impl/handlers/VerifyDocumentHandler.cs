using System;
using DocFlow.Application.Commands.Cmd;
using DocFlow.Application.Services;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;

namespace DocFlow.Application.Commands.impl.handlers
{
  public class VerifyDocumentHandler : ICommandHandler<VerifyDocumentCommand>
  {
    private IDocumentRepository _documentRepo;
    private IUserRepository _userRepo;

    public object Handle(VerifyDocumentCommand command)
    {
      Document document = _documentRepo.Get(new DocumentNumber(command.DocumentNumber));
      User verifier = _userRepo.Get(command.VerifierId);

      document.Verify(verifier);

      _documentRepo.Save(document);
      return null;
    }
  }
}