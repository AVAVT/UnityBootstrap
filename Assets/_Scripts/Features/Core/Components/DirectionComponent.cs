using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;
using System.Linq;
using TKLibs;

[Game, Event(EventTarget.Self)]
public class DirectionComponent : IComponent
{
  public Vector2Int value;
}