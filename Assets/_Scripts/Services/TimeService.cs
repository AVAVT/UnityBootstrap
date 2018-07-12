using UnityEngine;

public class TimeService : MonoBehaviour, ITimeService
{
  private float deltaTime;
  public float DeltaTime
  {
    get
    {
      return deltaTime;
    }
  }

  void Update()
  {
    deltaTime = Time.deltaTime;
  }
}