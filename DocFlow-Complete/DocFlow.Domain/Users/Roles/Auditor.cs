namespace DocFlow.Domain.Users.Roles
{
  internal class Auditor : BaseUserRole
  {
    public Auditor(string name)
      : base("Auditor")
    {
    }

    public void Audit()
    {
    }
  }

  internal class Corrector : BaseUserRole
  {
    public Corrector(string name) : base(name)
    {
    }
  }
}