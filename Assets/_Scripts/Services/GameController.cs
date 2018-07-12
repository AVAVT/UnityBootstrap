using Entitas;
using UnityEngine;
using Entitas.Unity;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

public class GameController : MonoBehaviour, IGameControllerService
{
  private Systems _systems;
  private Contexts _contexts;

  private Services _services;

  #region Unity

  void Start()
  {
    // Cursor.lockState = CursorLockMode.Confined;

    Debug.LogWarning("REMEMBER TO CHECK TODO & FIXME");
    _contexts = Contexts.sharedInstance;
    _services = CreateServices();
    SetConfigsData(Contexts.sharedInstance.config);
    SetMetaData(Contexts.sharedInstance.meta);
    _systems = new GameSystems(_contexts);

    _systems.Initialize();
  }

  void Update()
  {
    _systems.Execute();
    _systems.Cleanup();
  }
  #endregion

  private Services CreateServices()
  {
    Services services = new Services(
      new ViewService(),
      GetComponent<TimeService>() ?? gameObject.AddComponent<TimeService>(),
      GetComponent<InputService>() ?? gameObject.AddComponent<InputService>(),
      new SoundService(),
      new DebugService(_contexts)
    );

    return services;
  }

  private void SetConfigsData(ConfigContext configContext)
  {

  }

  private void SetMetaData(MetaContext metaContext)
  {
    metaContext.SetGameControllerService(this);
    metaContext.SetViewService(_services.viewService);
    metaContext.SetTimeService(_services.timeService);
    metaContext.SetInputService(_services.inputService);
    metaContext.SetDebugService(_services.debugService);
  }

  public void QuitGame()
  {
    StopAllSystems();
    StartCoroutine(DelayedQuit());
  }

  IEnumerator DelayedQuit()
  {
    yield return null;
    Application.Quit();
  }

  void StopAllSystems()
  {
    _systems.TearDown();
    _systems.DeactivateReactiveSystems();
    _systems.ClearReactiveSystems();
    _systems = new Feature();
  }

  private void ResetContexts()
  {
    _contexts.Reset();
  }
}