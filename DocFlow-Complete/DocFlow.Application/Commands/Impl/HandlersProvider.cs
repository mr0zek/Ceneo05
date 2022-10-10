namespace DocFlow.Application.Commands.impl
{
  public interface IHandlersProvider
  {
    ICommandHandler<T> Find<T>(T command) where T : BaseCommand;
  }
}