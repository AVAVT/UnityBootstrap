using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;
using System.Linq;
using TKLibs;

[Game, Unique]
public class TimeComponent : IComponent
{
  public float deltaTime;
  public float timeSinceLevelLoad;
  public long frameCount;
}