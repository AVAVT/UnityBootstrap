using UnityEngine;

public struct DataStruct
{
  public string stringData;
  public int intData;
  public Vector2 vector2Data;
  public bool boolData;

  public DataStruct(string stringData = null, int intData = 0)
  {
    this.intData = intData;
    this.stringData = stringData;
    vector2Data = Vector2.zero;
    boolData = true;
  }

  public DataStruct(Vector2 vector2Data, string stringData = null, int intData = 0, bool boolData = true)
  {
    this.vector2Data = vector2Data;
    this.intData = intData;
    this.stringData = stringData;
    this.boolData = boolData;
  }
}