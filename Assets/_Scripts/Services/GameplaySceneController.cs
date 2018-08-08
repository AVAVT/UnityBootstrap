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

public class GameplaySceneController : MonoBehaviour
{
  private Systems _systems;
  private Contexts _contexts;

  #region Unity

  void Start()
  {
    // Cursor.lockState = CursorLockMode.Confined;

    Debug.LogWarning("REMEMBER TO CHECK TODO & FIXME");
    _contexts = Contexts.sharedInstance;
    SetConfigsData(_contexts);
    SetupIOServices(_contexts);

    _systems = new GameSystems(_contexts);

    _systems.Initialize();
  }

  void Update()
  {
    _systems.Execute();
    _systems.Cleanup();
  }
  #endregion

  private void SetConfigsData(Contexts contexts)
  {

  }
  private void SetupIOServices(Contexts contexts)
  {
    IOContext iOContext = contexts.iO;
    iOContext.SetViewService(new ViewService());
    iOContext.SetSoundService(new SoundService());
    iOContext.SetTimeService(GetComponent<TimeService>() ?? gameObject.AddComponent<TimeService>());
    iOContext.SetInputService(GetComponent<InputService>() ?? gameObject.AddComponent<InputService>());
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