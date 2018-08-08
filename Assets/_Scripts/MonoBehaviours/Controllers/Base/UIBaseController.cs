using Entitas;
using Entitas.Unity;
using UnityEngine;
#if UNITY_EDITOR && DEBUG
using UnityEditor;
#endif

public class UIBaseController : MonoBehaviour, IViewController
{
  protected IOEntity uIEntity;
  public virtual void InitializeView(Contexts contexts, IEntity entity)
  {
    gameObject.Link(entity, contexts.iO);
    entity.OnDestroyEntity += OnDestroyEntity;
    uIEntity = entity as IOEntity;
  }

  protected virtual void OnDestroyEntity(IEntity entity)
  {
    gameObject.Unlink();
    Destroy(gameObject);
  }
}