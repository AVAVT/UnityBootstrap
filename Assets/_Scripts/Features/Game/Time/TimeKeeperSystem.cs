using Entitas;

public class TimeKeeperSystem : IInitializeSystem, IExecuteSystem
{
  GameContext gameContext;
  IOContext iOContext;
  public TimeKeeperSystem(Contexts contexts)
  {
    gameContext = contexts.game;
    iOContext = contexts.iO;
  }

  public void Initialize()
  {
    if (!gameContext.hasTime) gameContext.SetTime(0, 0, 0);
  }

  public void Execute()
  {
    if (gameContext.isPause)
    {
      gameContext.ReplaceTime(0, gameContext.time.timeSinceLevelLoad, gameContext.time.frameCount);
    }
    else
    {
      gameContext.ReplaceTime(
        iOContext.timeService.instance.DeltaTime,
        gameContext.time.timeSinceLevelLoad + iOContext.timeService.instance.DeltaTime,
        gameContext.time.frameCount + 1
      );
    }
  }
}