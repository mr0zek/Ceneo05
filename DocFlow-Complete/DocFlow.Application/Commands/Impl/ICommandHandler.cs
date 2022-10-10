namespace DocFlow.Application.Commands.impl
{
  public interface ICommandHandler<T> where T : BaseCommand
  {
    object Handle(T command);
  }
}
