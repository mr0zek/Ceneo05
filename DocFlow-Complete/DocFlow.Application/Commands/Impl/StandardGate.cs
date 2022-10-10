using System;

namespace DocFlow.Application.Commands.impl
{
  public class StandardGate : IGate
  {
    private IHandlersProvider handlersProvider = new NaiveHandlersProvider();

    public object Dispatch<T>(T command) where T : BaseCommand
    {
      //TODO dodać: transakcje, bezpieczeńśtwo, logowanie, profilowanie

      ICommandHandler<T> handler = handlersProvider.Find<T>(command);
      object result = handler.Handle(command);

      return result;
    }
  }
}