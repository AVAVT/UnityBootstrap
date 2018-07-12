using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Linq;
using TKLibs;

[Game, UI, Event(EventTarget.Self), Event(EventTarget.Self, EventType.Removed)]
public class ActiveComponent : IComponent { }