using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocFlow.Domain.Documents;

namespace DocFlow.Application.Commands.Cmd
{
  public class CreateDocumentCommand : BaseCommand
  {
    public Guid CreatorId { get; private set; }

    public DocumentType Type { get; private set; }

    public string Title { get; private set; }

    public CreateDocumentCommand(Guid creatorId, DocumentType type, string title, Guid tennantId, bool asynch, bool unique)
      : base(tennantId, asynch, unique)
    {
      CreatorId = creatorId;
      Type = type;
      Title = title;
    }

    public CreateDocumentCommand(Guid creatorId, DocumentType type, string title, Guid tennantId)
      : base(tennantId)
    {
      CreatorId = creatorId;
      Type = type;
      Title = title;
    }
  }
}