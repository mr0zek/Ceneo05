using DocFlow.Domain.Documents;

namespace DocFlow.Domain.Users.Roles
{
  public interface IDocumentCorrector : IUserRole
  {
    void Correct(Document documentInternal);
  }
}
