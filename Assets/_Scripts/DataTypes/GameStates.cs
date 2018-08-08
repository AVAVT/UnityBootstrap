public class GameStates
{
  private static string[] values;
  public static string[] Values()
  {
    if (values == null)
    {
      values = new string[] {
        "Initialize",
        "Tactic",
        "Combat"
      };
    }
    return values;
  }
  public const string Tactic = "Tactic";
  public const string Combat = "Combat";
}