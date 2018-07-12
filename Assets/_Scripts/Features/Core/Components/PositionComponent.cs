using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;
using System.Linq;
using TKLibs;

[Game, UI, Event(EventTarget.Self)]
public class PositionComponent : IComponent
{
  public Vector2 value;
}