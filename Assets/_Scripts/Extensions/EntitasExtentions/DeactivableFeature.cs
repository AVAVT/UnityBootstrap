using System.Collections.Generic;
using Entitas;

public class DeactivableFeature : Feature
{
  public DeactivableFeature(string name) : base(name) { }

  protected Dictionary<System.Type, ISystem> activableSystems = new Dictionary<System.Type, ISystem>();

  public override Systems Add(ISystem system)
  {
    base.Add(system);
    activableSystems.Add(system.GetType(), system);

    return this;
  }

  public void ActivateSystem(System.Type type)
  {
    try
    {
      ISystem system = activableSystems[type];
      if (system is IReactiveSystem) (system as IReactiveSystem).Activate();
    }
    catch (System.Collections.Generic.KeyNotFoundException e)
    {
      throw new System.Exception("System " + type + " is not in collection!\n" + e.StackTrace);
    }
  }
}