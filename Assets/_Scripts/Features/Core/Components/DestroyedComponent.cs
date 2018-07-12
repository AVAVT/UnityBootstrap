using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Entitas.CodeGeneration.Attributes;
using System.Linq;
using TKLibs;

[Game, Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent { }