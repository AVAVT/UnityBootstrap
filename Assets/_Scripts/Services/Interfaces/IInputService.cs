using UnityEngine;
using Entitas;

public interface IInputService
{
  Vector2 ControlDirection { get; }
  ClickEvent ClickEvent { get; set; }
}

public class ClickEvent
{
  public IEntity entity;
  public string type;
  public DataStruct data;

  public ClickEvent(string type)
  {
    this.type = type;
    data = new DataStruct();
  }

  public ClickEvent(string type, DataStruct data)
  {
    this.type = type;
    this.data = data;
  }

  public ClickEvent(string type, IEntity entity)
  {
    this.entity = entity;
    this.type = type;
    this.data = new DataStruct();
  }

  public ClickEvent(string type, IEntity entity, DataStruct data)
  {
    this.entity = entity;
    this.type = type;
    this.data = data;
  }
}