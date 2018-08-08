using System.Collections.Generic;
using Entitas;
using UnityEngine;
using System.Linq;
using TKLibs;

public class DestroyEntitySystem : ReactiveSystem<GameEntity>
{
  Contexts _contexts;
  public DestroyEntitySystem(Contexts contexts) : base(contexts.game)
  {
    _contexts = contexts;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.Destroyed);
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.isDestroyed;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities) entity.Destroy();
  }
}