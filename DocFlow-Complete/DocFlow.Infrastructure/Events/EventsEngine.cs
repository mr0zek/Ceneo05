using System;
using System.Collections.Generic;
using DocFlow.Domain.Documents.Events;

namespace DocFlow.Infrastructure.Events
{
  public class EventsEngine : IEventsPublisher
  {
    public static EventsEngine Instance { get; private set; } 

    private IDictionary<Type, object> _listeners = new Dictionary<Type, object>();

    static EventsEngine()
    {
      Instance = new EventsEngine();
    }

    public void Publish<T>(T @event) where T : IEvent
    {
      List<IEventListener<T>> localCopy;
      lock (_listeners)
      {
        if (!_listeners.ContainsKey(@event.GetType()))
        {
          return;
        }
        localCopy = new List<IEventListener<T>>(_listeners[@event.GetType()] as List<IEventListener<T>>);
      }
      foreach (var handler in localCopy)
      {
        handler.Handle(@event);

        //dispatch on thread pool for added awesomeness
        //var handler1 = handler;
        //ThreadPool.QueueUserWorkItem(x => handler1.Handle(@event));
      }
    }

    public void RegisterListener<T>(IEventListener<T> handler) where T : IEvent
    {
      List<IEventListener<T>> handlers;
      if (!_listeners.ContainsKey(typeof(T)))
      {
        handlers = new List<IEventListener<T>>();
        handlers.Add(handler);
        _listeners.Add(typeof(T), handlers);
      }
      else
      {
        handlers = _listeners[typeof (T)] as List<IEventListener<T>>;
        handlers.Add(handler);
      }      
    }    
  }
}
