using Entitas;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DebugService : IDebugService
{
  Dictionary<string, Dictionary<int, List<string>>> histories = new Dictionary<string, Dictionary<int, List<string>>>();
  Contexts contexts;
  public DebugService(Contexts contexts)
  {
#if DEBUG
    this.contexts = contexts;
    foreach (IContext context in contexts.allContexts)
    {
      histories.Add(context.contextInfo.name, new Dictionary<int, List<string>>());
      context.OnEntityCreated += BindEntityEvents;
    }
#endif
  }

  public void PrintModificationHistory(IEntity entity)
  {
#if DEBUG
    string path = Application.persistentDataPath + "/log_" + entity.contextInfo.name + "_" + entity.creationIndex + ".log";

    using (FileStream fs = new FileStream(path, FileMode.Create))
    {
      using (StreamWriter writer = new StreamWriter(fs))
      {
        foreach (var history in histories[entity.contextInfo.name][entity.creationIndex])
        {
          writer.WriteLine(history);
        }

        Debug.Log("Entity history written to " + path);
      }
    }
#endif
  }

  public void BindEntityEvents(IContext context, IEntity entity)
  {
    histories[context.contextInfo.name].Add(
      entity.creationIndex,
      new List<string>() { (contexts.game.hasTime ? contexts.game.time.timeSinceLevelLoad : 0).ToString() + ": Entity " + entity.creationIndex + " created" }
    );

    entity.OnComponentAdded += OnComponentAdded;
    entity.OnComponentReplaced += OnComponentReplaced;
    entity.OnComponentRemoved += OnComponentRemoved;
  }

  public void OnComponentAdded(IEntity entity, int index, IComponent component)
  {
    histories[entity.contextInfo.name][entity.creationIndex].Add(
      (contexts.game.hasTime ? contexts.game.time.timeSinceLevelLoad : 0).ToString() + ": Entity " + entity.creationIndex + " ADDED " + component.ToString()
    );
  }

  public void OnComponentReplaced(IEntity entity, int index, IComponent component, IComponent replacement)
  {
    histories[entity.contextInfo.name][entity.creationIndex].Add(
      (contexts.game.hasTime ? contexts.game.time.timeSinceLevelLoad : 0).ToString() + ": Entity " + entity.creationIndex + " REPLACED " + component.ToString() + " from " + replacement.ToString()
    );
  }

  public void OnComponentRemoved(IEntity entity, int index, IComponent previousComponent)
  {
    histories[entity.contextInfo.name][entity.creationIndex].Add(
      (contexts.game.hasTime ? contexts.game.time.timeSinceLevelLoad : 0).ToString() + ": Entity " + entity.creationIndex + " REMOVED " + previousComponent.ToString()
    );
  }
}