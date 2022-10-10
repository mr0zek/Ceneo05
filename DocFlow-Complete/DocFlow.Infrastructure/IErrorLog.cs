namespace DocFlow.Infrastructure
{
  public interface IErrorLog
  {
    void RegisterError(string message);
  }
}