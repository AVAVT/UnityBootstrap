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

#if UNITY_EDITOR && DEBUG
  public void PrintDebug()
  {
    Contexts.sharedInstance.meta.debugService.instance.PrintModificationHistory(gameEntity);
  }
#endif
}

#if UNITY_EDITOR && DEBUG
[CustomEditor(typeof(GameBaseController), true)]
public class GameDebugButtonEditor : Editor
{
  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();

    if (GUILayout.Button("Print Debug History"))
    {
      (target as GameBaseController).PrintDebug();
    }
  }
}
#endif