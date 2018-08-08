using Entitas;
using System.Linq;
using TKLibs;

public class CoreFeature : Feature
{
  public CoreFeature(Contexts contexts) : base("CoreFeature")
  {
    // Initialization

    // Execution
    Add(new TimeKeeperSystem(contexts));
    Add(new UpdateYBasedSortingOrderSystem(contexts));
    // Cleanup
    Add(new DestroyEntitySystem(contexts));
  }
}