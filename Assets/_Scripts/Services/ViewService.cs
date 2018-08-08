using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ViewService : IViewService
{
  public Transform HUDTransform { get { return HUDParentTransform; } }
  public Transform UITransform { get { return UIParentTransform; } }

  private Transform HUDParentTransform;
  private Transform UIParentTransform;
  private Dictionary<string, Transform> parentTransformList = new Dictionary<string, Transform>();

  public GameObject LoadAsset(Contexts contexts, IEntity entity, GameObject prefab, Transform parent = null)
  {
    var viewGo = prefab == null ? new GameObject("Game View") : GameObject.Instantiate(prefab);

    if (parent != null)
    {
      viewGo.transform.SetParent(parent);
      viewGo.transform.localScale = Vector3.one;
    }

    var viewController = viewGo.GetComponent<IViewController>();
    if (viewController != null) viewController.InitializeView(contexts, entity);

    var eventListeners = viewGo.GetComponents<IEventListener>();
    foreach (var listener in eventListeners) listener.RegisterListeners(contexts, entity);

    return viewGo;
  }

  public IViewController LoadCamera(Contexts contexts, IEntity entity)
  {
    var viewGo = Camera.main;
    var viewController = viewGo.GetComponent<IViewController>();
    if (viewController != null) viewController.InitializeView(contexts, entity);

    var eventListeners = viewGo.GetComponents<IEventListener>();
    foreach (var listener in eventListeners) listener.RegisterListeners(contexts, entity);

    return viewController;
  }

  public IViewController LoadGameAsset(Contexts contexts, IEntity entity, string parentTransformName = null)
  {
    GameObject prefab = null; // TODO
    if (parentTransformName != null)
    {
      if (!parentTransformList.ContainsKey(parentTransformName))
      {
        Transform newParentTransform = new GameObject(parentTransformName).transform;
        parentTransformList[parentTransformName] = newParentTransform;
      }

      return LoadAsset(contexts, entity, prefab, parentTransformList[parentTransformName]).GetComponent<IViewController>();
    }
    else
    {
      return LoadAsset(contexts, entity, prefab).GetComponent<IViewController>();
    }
  }

  public IViewController LoadHUDAsset(Contexts contexts, IEntity entity, bool isParent = false, string parentTransformName = null)
  {
    GameObject prefab = null; // TODO
    if (isParent)
    {
      HUDParentTransform = LoadAsset(contexts, entity, prefab).transform;
      return HUDParentTransform.GetComponent<IViewController>();
    }
    else if (parentTransformName != null)
    {
      if (!parentTransformList.ContainsKey(parentTransformName))
      {
        Transform newParentTransform = new GameObject(parentTransformName).transform;
        newParentTransform.SetParent(HUDParentTransform);
        newParentTransform.localScale = Vector3.one;
        parentTransformList[parentTransformName] = newParentTransform;
      }

      return LoadAsset(contexts, entity, prefab, parentTransformList[parentTransformName]).GetComponent<IViewController>();
    }
    else
    {
      return LoadAsset(contexts, entity, prefab, HUDParentTransform).GetComponent<IViewController>();
    }
  }

  public IViewController LoadUIAsset(Contexts contexts, IEntity entity, bool isParent = false, string parentTransformName = null)
  {
    GameObject prefab = null; // TODO
    if (isParent)
    {
      UIParentTransform = LoadAsset(contexts, entity, prefab).transform;
      return UIParentTransform.GetComponent<IViewController>();
    }
    else if (parentTransformName != null)
    {
      if (!parentTransformList.ContainsKey(parentTransformName))
      {
        Transform newParentTransform = new GameObject(parentTransformName).transform;
        newParentTransform.SetParent(UIParentTransform);
        newParentTransform.localScale = Vector3.one;
        parentTransformList[parentTransformName] = newParentTransform;
      }

      return LoadAsset(contexts, entity, prefab, parentTransformList[parentTransformName]).GetComponent<IViewController>();
    }
    else
    {
      return LoadAsset(contexts, entity, prefab, UIParentTransform).GetComponent<IViewController>();
    }
  }
}