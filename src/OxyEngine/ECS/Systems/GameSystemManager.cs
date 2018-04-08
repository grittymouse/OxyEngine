﻿using OxyEngine.Dependency;
using OxyEngine.Ecs.Behaviours;
using OxyEngine.Ecs.Entities;
using OxyEngine.Events;
using OxyEngine.Events.Args;

namespace OxyEngine.Ecs.Systems
{
  public class GameSystemManager : IUpdateable, IDrawable
  {
    public LogicSystem LogicSystem { get; private set; }
    public DrawSystem DrawSystem { get; private set; }

    private GlobalEventsManager _events;
    private GameInstance _gameInstance;

    public GameSystemManager(GameInstance gameInstance)
    {
      _gameInstance = gameInstance;
      Container.Instance.RegisterByName("Api", _gameInstance.GetApi());

      _events = _gameInstance.GetApi().Events;
      _events.Global.StartListening(EventNames.Initialization.OnLoad, 
        (sender, args) => Load()
      );
      _events.Global.StartListening(EventNames.Gameloop.OnUpdate, 
        (sender, args) => Update((float)((EngineUpdateEventArgs)args).DeltaTime)
      );
      _events.Global.StartListening(EventNames.Graphics.OnDraw, 
        (sender, args) => Draw()
      );
    }

    public void InitializeSystems(BaseGameEntity rootEntity)
    {
      LogicSystem = new LogicSystem(rootEntity);
      DrawSystem = new DrawSystem(rootEntity);
    }

    public void Load()
    {
      LogicSystem?.Load();
    }
    
    public void Update(float dt)
    {
      LogicSystem?.Update(dt);
    }

    public void Draw()
    {
      DrawSystem?.Draw();
    }
  }
}