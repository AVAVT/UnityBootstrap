using Entitas;

public class TimeKeeperSystem : IInitializeSystem, IExecuteSystem
{
  GameContext _context;
  MetaContext _metaContext;
  public TimeKeeperSystem(Contexts contexts)
  {
    _context = contexts.game;
    _metaContext = contexts.meta;
  }

  public void Initialize()
  {
    if (!_context.hasTime) _context.SetTime(0, 0, 0);
  }

  public void Execute()
  {
    if (_context.isPause)
    {
      _context.ReplaceTime(0, _context.time.timeSinceLevelLoad, _context.time.frameCount);
    }
    else
    {
      _context.ReplaceTime(
        _metaContext.timeService.instance.DeltaTime,
        _context.time.timeSinceLevelLoad + _metaContext.timeService.instance.DeltaTime,
        _context.time.frameCount + 1
      );
    }
  }
}