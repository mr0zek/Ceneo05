using DocFlow.Domain.Documents;

namespace DocFlow.Domain.Users.Roles
{
  public class StandardCorrector : BaseUserRole, IDocumentCorrector
  {

    public StandardCorrector() : base("Corector")
    {      
    }

    public void Correct(Document documentInternal)
    {
      // TODO Auto-generated method stub

    }
  }
}