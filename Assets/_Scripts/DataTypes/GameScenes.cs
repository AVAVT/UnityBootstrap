public class GameScenes
{
  private static string[] values;
  public static string[] Values()
  {
    if (values == null)
    {
      values = new string[] {
        "TacticScene",
        "CombatScene"
      };
    }
    return values;
  }
  public const string TacticScene = "TacticScene";
  public const string CombatScene = "CombatScene";
}