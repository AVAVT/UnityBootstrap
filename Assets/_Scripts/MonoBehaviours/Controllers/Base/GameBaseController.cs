using Entitas;
using Entitas.Unity;
using UnityEngine;
#if UNITY_EDITOR && DEBUG
using UnityEditor;
#endif

public class GameBaseController : MonoBehaviour, IViewController
{
  protected GameEntity gameEntity;
  public virtual void InitializeView(Contexts contexts, IEntity entity)
  {
    gameObject.Link(entity, contexts.game);
    entity.OnDestroyEntity += OnDestroyEntity;
    gameEntity = entity as GameEntity;
  }

  protected virtual void OnDestroyEntity(IEntity entity)
  {
    gameObject.Unlink();
    Destroy(gameObject);
  }
}