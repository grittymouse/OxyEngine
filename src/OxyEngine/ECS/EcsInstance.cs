﻿using OxyEngine.Dependency;
using OxyEngine.Ecs.Entities;
using OxyEngine.Ecs.Systems;
using OxyEngine.Projects;

namespace OxyEngine.Ecs
{
  public class EcsInstance : GameInstance
  {
    private GameSystemManager _gameSystemManager;

    public EcsInstance(GameProject project) : base(project)
    {
      _gameSystemManager = new GameSystemManager(this);
    }

    public void SetRootEntity(BaseGameEntity rootEntity)
    {
      _gameSystemManager.InitializeSystems(rootEntity);
    }
  }
}