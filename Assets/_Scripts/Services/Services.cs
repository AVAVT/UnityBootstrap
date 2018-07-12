public class Services
{
  public readonly IViewService viewService;
  public readonly ITimeService timeService;
  public readonly IInputService inputService;
  public readonly ISoundService soundService;
  public readonly IDebugService debugService;

  public Services(
    IViewService viewService,
    ITimeService timeService,
    IInputService inputService,
    ISoundService soundService,
    IDebugService debugService
  )
  {
    this.viewService = viewService;
    this.timeService = timeService;
    this.inputService = inputService;
    this.soundService = soundService;
    this.debugService = debugService;
  }
}