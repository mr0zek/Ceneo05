using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Users;

namespace DocFlow.Domain.Documents.Statemachine
{
  public interface IDocumentState
  {
    void ChangeTitle(string newTitle);
    void Publish(ICostCalculator costCalculator);
    void Verify(User verifier);
    DocumentStatus Status { get; }
  }
}