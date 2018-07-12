public class GameSystems : Feature
{
  public GameSystems(Contexts contexts) : base("Systems")
  {
    Add(new CoreFeature(contexts));

    // Entitas Event systems
    Add(new GameEventSystems(contexts));
    // Add(new UIEventSystems(contexts));

    Add(new GameCleanupSystems(contexts));
  }
}