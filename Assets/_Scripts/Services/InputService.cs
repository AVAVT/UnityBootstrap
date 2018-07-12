using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
  private Vector2 controlDirection;
  public Vector2 ControlDirection { get { return controlDirection; } }

  private ClickEvent clickEvent;

  public ClickEvent ClickEvent
  {
    get
    {
      return clickEvent;
    }

    set
    {
      clickEvent = value;
    }
  }

  void Update()
  {
    Vector2Int direction = Vector2Int.zero;

#if !UNITY_EDITOR
    Vector2 mousePos = Input.mousePosition;
    float screenHeight = Screen.height;
    float screenWidth = Screen.width;

    direction += new Vector2Int(
      mousePos.x <= screenWidth * .01f
        ? -1
      : mousePos.x >= screenWidth * .99f
        ? 1
        : 0,
      mousePos.y <= screenHeight * .01f
        ? -1
      : mousePos.y >= screenHeight * .99f
        ? 1
        : 0
    );
#endif


    direction += new Vector2Int(
      Input.GetKey(KeyCode.LeftArrow)
        ? -1
      : Input.GetKey(KeyCode.RightArrow)
        ? 1
        : 0,
      Input.GetKey(KeyCode.DownArrow)
        ? -1
      : Input.GetKey(KeyCode.UpArrow)
        ? 1
        : 0
    );

    controlDirection = direction;

    if (Input.GetKeyUp(KeyCode.Escape))
    {
      // clickEvent = new ClickEvent(ClickEventType.Menu);
    }

    // if (clickEvent != null) Debug.Log(clickEvent.type);
  }
}