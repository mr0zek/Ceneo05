using System;
using System.Collections.Generic;
using DocFlow.Application.Commands.Cmd;
using DocFlow.Application.Commands.impl.handlers;
using DocFlow.Application.Services;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Events;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Documents.Validation;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Repo;

namespace DocFlow.Application.Commands.impl
{
  public class NaiveHandlersProvider : IHandlersProvider
  {
    private IDictionary<Type, object> mapping = new Dictionary<Type, object>();
    private IConfigurationData _configurationData;
    private IEventsPublisher _eventPublisher;
    private User _creator;

    public NaiveHandlersProvider()
    {
      RegisterHandler(new CreateDocumentHandler(
        new FakeUserRepository(), 
        new DocumentFactory(NumberGeneratorFactory.Create(_creator, _configurationData),
          _eventPublisher,
          DocumentValidatorFactory.Create(_configurationData)),new FakeDocumentRepository()));
      RegisterHandler(new VerifyDocumentHandler());
      RegisterHandler(new PublishDocumentHandler());
    }

    private void RegisterHandler<T>(ICommandHandler<T> commandHandler) where T : BaseCommand
    {
      mapping.Add(typeof(T), commandHandler);
    }

    public ICommandHandler<T> Find<T>(T command) where T : BaseCommand
    {
      //TODO: dodać wersjonowanie API per tennantId, dodać dekorowanie handlerów 
      return mapping[typeof(T)] as ICommandHandler<T>;
    }
  }
}