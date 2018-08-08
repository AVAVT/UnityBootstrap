using System.Collections.Generic;
using Entitas;
using UnityEngine;
using System.Linq;
using TKLibs;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
  Contexts contexts;
  IViewService viewService;
  public AddViewSystem(Contexts contexts) : base(contexts.game)
  {
    this.contexts = contexts;
    viewService = contexts.iO.viewService.instance;
  }

  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
  {
    return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Sprite, GameMatcher.Position).NoneOf(GameMatcher.View));
  }

  protected override bool Filter(GameEntity entity)
  {
    return entity.hasPosition && entity.hasSprite && !entity.hasView;
  }

  protected override void Execute(List<GameEntity> entities)
  {
    foreach (var entity in entities) entity.AddView(viewService.LoadGameAsset(contexts, entity));
  }
}