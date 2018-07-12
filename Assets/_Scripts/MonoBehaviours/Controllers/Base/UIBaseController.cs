using Entitas;
using Entitas.Unity;
using UnityEngine;
#if UNITY_EDITOR && DEBUG
using UnityEditor;
#endif

public class UIBaseController : MonoBehaviour, IViewController
{
  protected UIEntity uIEntity;
  public virtual void InitializeView(Contexts contexts, IEntity entity)
  {
    gameObject.Link(entity, contexts.uI);
    entity.OnDestroyEntity += OnDestroyEntity;
    uIEntity = entity as UIEntity;
  }

  protected virtual void OnDestroyEntity(IEntity entity)
  {
    gameObject.Unlink();
    Destroy(gameObject);
  }

#if UNITY_EDITOR && DEBUG
  public void PrintDebug()
  {
    Contexts.sharedInstance.meta.debugService.instance.PrintModificationHistory(uIEntity);
  }
#endif
}

#if UNITY_EDITOR && DEBUG
[CustomEditor(typeof(UIBaseController), true)]
public class UIDebugButtonEditor : Editor
{
  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();

    if (GUILayout.Button("Print Debug History"))
    {
      (target as UIBaseController).PrintDebug();
    }
  }
}
#endif