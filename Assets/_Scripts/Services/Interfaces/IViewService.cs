
using Entitas;
using UnityEngine;

public interface IViewService
{
  GameObject LoadAsset(Contexts contexts, IEntity entity, GameObject prefab, Transform parent = null);
  IViewController LoadCamera(Contexts contexts, IEntity entity);

  IViewController LoadGameAsset(Contexts contexts, IEntity entity, GameObject prefab, string parentTransformName = null);
  IViewController LoadHUDAsset(Contexts contexts, IEntity entity, GameObject prefab, bool isParent = false, string parentTransformName = null);
  IViewController LoadUIAsset(Contexts contexts, IEntity entity, GameObject prefab, bool isParent = false, string parentTransformName = null);
}