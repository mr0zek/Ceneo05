namespace DocFlow.Application.Commands
{
  public interface IGate
  {
    object Dispatch<T>(T command) where T : BaseCommand;
  }
}