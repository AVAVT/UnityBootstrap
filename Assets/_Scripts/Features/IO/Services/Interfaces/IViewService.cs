
using Entitas;
using UnityEngine;

public interface IViewService
{
  IViewController LoadCamera(Contexts contexts, IEntity entity);
  IViewController LoadGameAsset(Contexts contexts, IEntity entity, string parentTransformName = null);
  IViewController LoadHUDAsset(Contexts contexts, IEntity entity, bool isParent = false, string parentTransformName = null);
  IViewController LoadUIAsset(Contexts contexts, IEntity entity, bool isParent = false, string parentTransformName = null);
}