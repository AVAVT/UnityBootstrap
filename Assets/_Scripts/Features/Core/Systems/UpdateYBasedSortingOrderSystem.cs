using System.Collections.Generic;
using Entitas;
using UnityEngine;
using System.Linq;
using TKLibs;

public class UpdateYBasedSortingOrderSystem : ReactiveSystem<GameEntity>
{
  public UpdateYBasedSortingOrderSystem(Contexts contexts) : base(contexts.game)
  {
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.YBasedSortingOrder));
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasPosition && entity.isYBasedSortingOrder;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities)
    {
      entity.ReplaceSortingOrder(-(int)entity.position.value.y);
    }
  }
}