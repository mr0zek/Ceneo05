using DocFlow.Application.Commands.Cmd;
using DocFlow.Application.Services;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;

namespace DocFlow.Application.Commands.impl.handlers
{
  public class CreateDocumentHandler : ICommandHandler<CreateDocumentCommand>
  {
    private IUserRepository _userRepo;
    private IDocumentFactory _documentFactory;
    private IDocumentRepository _documentRepo;

    public CreateDocumentHandler(IUserRepository userRepo, IDocumentFactory documentFactory, IDocumentRepository documentRepo)
    {
      _userRepo = userRepo;
      _documentFactory = documentFactory;
      _documentRepo = documentRepo;
    }

    public object Handle(CreateDocumentCommand command)
    {
      User creator = _userRepo.Get(command.CreatorId);

      Document document = _documentFactory.Create(command.Type, creator);

      document.ChangeTitle(command.Title);

      _documentRepo.Save(document);
      return document.Number;
    }
  }
}