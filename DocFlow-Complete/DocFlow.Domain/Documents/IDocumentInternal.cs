using DocFlow.Domain.Documents.Statemachine;
using DocFlow.Domain.Shared;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents
{
  internal interface IDocumentInternal
  {
    void SetStatus(DocumentStatus documentStatus);
    void SetPrintingCost(Money cost);
    void SetTitle(string newTitle);

    DocumentNumber Number { get; }
    User Author { get; }
    string Title { get; }   
  }
}