﻿using System;
using System.Collections.Generic;
using OxyEngine.Events.Args;
using OxyEngine.Events.Handlers;
using OxyEngine.Interfaces;
using OxyEngine.Loggers;

namespace OxyEngine.Events
{
  /// <summary>
  ///   Represents simple event system for games
  /// </summary>
  public class EventSystem : IUniqueObject
  {
    public Guid Id { get; }
    
    private Dictionary<string, EngineEventHandler> _registry;

    public bool LogEventCalls { get; set; }
    public bool LogListenerRegistration { get; set; }
    
    public EventSystem()
    {
      Id = Guid.NewGuid();
      _registry = new Dictionary<string, EngineEventHandler>();
    }
    
    public void StartListening(string eventName, EngineEventHandler handler)
    {
      if (!_registry.ContainsKey(eventName))
      {
        _registry[eventName] = handler;
      }
      else
      {
        _registry[eventName] += handler;
      }

      if (LogListenerRegistration)
      {
        LogManager.Log($"Start listening event '{eventName}'',\n\t  event system '{Id}'");
      }
    }

    public void AddListenersFromAttributes(object obj)
    {
      var type = obj.GetType();
      var attributes = type.GetCustomAttributes(typeof(ListenEventAttribute), true);

      foreach (ListenEventAttribute attribute in attributes)
      {
        var method = type.GetMethod(attribute.MethodName);
        _registry.Add(attribute.EventName, 
          (EngineEventHandler)Delegate.CreateDelegate(typeof(EngineEventHandler),
          method ?? throw new NullReferenceException(nameof(attribute.MethodName))));
      }
    }
    
    public void StopListening(string eventName, EngineEventHandler handler)
    {
      if (!_registry.ContainsKey(eventName))
        throw new Exception($"No handlers for event with name '{eventName}'',\n\t  event system '{Id}'");
      
      _registry[eventName] -= handler;
    }

    public void Invoke(string eventName, EngineEventArgs args, bool checkEventExists = false)
    {
      if (!_registry.ContainsKey(eventName))
      {
        if (checkEventExists)
          throw new Exception($"No handlers for event with name '{eventName}'',\n\t  event system '{Id}'");
        
        // If no listeners and checkEventExists == false, then log and ignore call
        LogManager.Warning($"No listeners for event with name '{eventName}'',\n\t  event system '{Id}'");
        return;
      }

      // If handler == null, remove it
      if (_registry[eventName] == null)
      {
        _registry.Remove(eventName);
        return;
      }

      _registry[eventName].Invoke(this, args);
    }
  }
}